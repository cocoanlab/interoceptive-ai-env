using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.Linq;
using Unity.MLAgents;

using System.Drawing;
using OpenCvSharp;

// FieldThermoGridGenerator 스크립트로 만든 그리드 역할을 하는 각 큐브에
// 지형 온도를 대응시키기 위해 만든 스크립트
// Field 게임 오브젝트에 부착함
// 가장자리 쪽으로 갈수록 지형 온도가 차가워지는 경향이 있는데 smoothing 식을 뜯어볼 필요가 있음
// smoothing을 하는 kernel (3 x 3)이 가장자리에서는 해당 작업을 하지 않기 때문인 듯함
// padding 느낌으로 그리드 크기를 agent가 활동하는 범위보다 더 늘리는 것이 대안이 될 수 있음
// 지금 당장 급한 것은 아니라 해당 문제는 리포트만 해두고 보류함
// http://nic-gamedev.blogspot.com/2013/02/simple-terrain-smoothing.html
public class AreaTemp : MonoBehaviour
{
        public GameObject Field;
        public GameObject Cave;
        // Variables for code
        private EnvironmentParameters m_ResetParams;
        public double[,] areaTemp;
        private int areaWidth;
        private int areaDepth;
        private double oldLow;
        private double oldHigh;
        private double newLow;
        private double newHigh;
        public double[,] normalizedAreaTemp;

        [Header("Field Temperature parameters")]
        public float hotSpotCount = 300;
        public float objectSpotCount = 1;
        public int smoothingRepetition = 10;
        public float hotSpotTempLow = 60.0f;
        public float hotSpotTempHigh = 60.0f;
        public float fieldDefaultTempLow = -60.0f;
        public float fieldDefaultTempHigh = -60.0f;
        public float objectTemp = 80.0f;

        private int numberOfCubeX;
        private int numberOfCubeZ;
        public int kernelSizeX = 7;
        public int kernelSizeY = 7;
        public float sigmaX = 10.0f;
        public float sigmaY = 10.0f;


        private double[,] smoothed;
        private double[,] normalizedSmoothed;

        public void Awake()
        {
                Academy.Instance.OnEnvironmentReset += SetParameters;
                numberOfCubeX = Field.GetComponent<FieldThermoGrid>().numberOfGridCubeX;
                numberOfCubeZ = Field.GetComponent<FieldThermoGrid>().numberOfGridCubeZ;
        }

        private void SetParameters()
        {
                m_ResetParams = Academy.Instance.EnvironmentParameters;
                hotSpotCount = m_ResetParams.GetWithDefault("hotSpotCount", hotSpotCount);
                smoothingRepetition = System.Convert.ToInt32(m_ResetParams.GetWithDefault("smoothingRepetition", smoothingRepetition));

                fieldDefaultTempLow = m_ResetParams.GetWithDefault("fieldDefaultTempLow", fieldDefaultTempLow);
                fieldDefaultTempHigh = m_ResetParams.GetWithDefault("fieldDefaultTempHigh", fieldDefaultTempHigh);
                hotSpotTempLow = m_ResetParams.GetWithDefault("hotSpotTempLow", hotSpotTempLow);
                hotSpotTempHigh = m_ResetParams.GetWithDefault("hotSpotTempHigh", hotSpotTempHigh);
                objectTemp = m_ResetParams.GetWithDefault("objectTemp", objectTemp);
        }

        public void EpisodeAreaSmoothing()
        {
                areaTemp = new double[numberOfCubeX, numberOfCubeZ];

                // for (int x = 0; x < 100; ++x)
                // {
                //     for (int z = 0; z < 100; ++z)
                //     {
                //         if (x >= 70 && x <= 90 && z >= 70 && z <= 90)
                //         {
                //             areaTemp[x, z] = 48.0f;
                //         }
                //         else if (x >= 10 && x < 20)
                //         {
                //             areaTemp[x, z] = -16.0f;
                //         }
                //         else if (x >= 30 && x < 40)
                //         {
                //             areaTemp[x, z] = -8.0f;
                //         }
                //         else if (x >= 50 && x < 60)
                //         {
                //             areaTemp[x, z] = 8.0f;
                //         }
                //         else if (x >= 70 && x < 80)
                //         {
                //             areaTemp[x, z] = 16.0f;
                //         }
                //         else
                //         {
                //             areaTemp[x, z] = 0.0f;
                //         }
                //     }
                // }

                // 임의로 범위를 지정해서 영역별로 지형 온도를 나눔
                // 만약 fieldDefaultTempLow와 fieldDefaultTempHigh를 똑같이 설정하면 모두 똑같은 지형 온도
                // 지금 시점 (2023.02.09)에서는 모든 영역의 지형 온도를 똑같이 한 다음
                // hotSpot을 여러 곳으로 지정하여 영역별 온도를 달리하였음
                for (int x = 0; x < numberOfCubeX; ++x)
                {
                        for (int z = 0; z < numberOfCubeZ; ++z)
                        {
                                // if (x >= 40 && x < 60 && z >= 40 && z < 60)
                                // {
                                //         areaTemp[x, z] = Random.Range(fieldDefaultTempLow, fieldDefaultTempHigh);
                                // }
                                // else if (x >= 0 && x < 50 && z >= 0 && z < 50)
                                // {
                                //         areaTemp[x, z] = Random.Range(fieldDefaultTempLow, fieldDefaultTempHigh);
                                // }
                                // else if (x >= 0 && x < 50 && z >= 50 && z < 100)
                                // {
                                //         areaTemp[x, z] = Random.Range(fieldDefaultTempLow, fieldDefaultTempHigh);
                                // }
                                // else if (x >= 50 && x < 100 && z >= 0 && z < 50)
                                // {
                                //         areaTemp[x, z] = Random.Range(fieldDefaultTempLow, fieldDefaultTempHigh);
                                // }
                                // else if (x >= 50 && x < 100 && z >= 50 && z < 100)
                                // {
                                //         areaTemp[x, z] = Random.Range(fieldDefaultTempLow, fieldDefaultTempHigh);
                                // }
                                // else
                                // {
                                //         areaTemp[x, z] = 0;
                                // }
                                areaTemp[x, z] = Random.Range(fieldDefaultTempLow, fieldDefaultTempHigh);
                        }
                }

                for (int tempCount = 0; tempCount < hotSpotCount; ++tempCount)
                {
                        MakeBonfire(Random.Range(2, numberOfCubeX - 2), Random.Range(2, numberOfCubeZ - 2));
                }

                //object(cave)의 개수만큼 MakeObjectHotspot 메소드를 실행시켜줌

                for (int tempCount = 0; tempCount < objectSpotCount; ++tempCount)
                {
                        if (objectSpotCount > 0) //objectSpotCount의 개수가 0이면 실행 안되게 해줌.
                        {
                                MakeObjectHotspot(Random.Range(2, numberOfCubeX - 2), Random.Range(2, numberOfCubeZ - 2));
                        }
                }

                areaWidth = numberOfCubeX;
                areaDepth = numberOfCubeZ;
                // SmoothingAreaTemp(smoothingRepetition, areaTemp, areaWidth, areaDepth);
                SmoothingAreaTemp();

                // 지형 온도의 정규화를 구현함
                // 0~1의 값으로 적외선 카메라 화면처럼 HeatMap을 구현하기 위함임
                normalizedAreaTemp = new double[numberOfCubeX, numberOfCubeZ];
                oldLow = areaTemp.Cast<double>().Min();
                oldHigh = areaTemp.Cast<double>().Max();
                newLow = 0.0f;
                newHigh = 1.0f;
                for (int x = 0; x < numberOfCubeX; ++x)
                {
                        for (int z = 0; z < numberOfCubeZ; ++z)
                        {
                                normalizedAreaTemp[x, z] = Remap(areaTemp[x, z], oldLow, oldHigh, newLow, newHigh);
                        }
                }

        }

        public double GetAreaTemp(int x, int z)
        {
                return areaTemp[x, z];
        }

        public void SetAreaTemp(float temp)
        {
                for (int x = 0; x < numberOfCubeX; ++x)
                {
                        for (int z = 0; z < numberOfCubeZ; ++z)
                        {
                                areaTemp[x, z] = areaTemp[x, z] + temp;
                        }
                }
        }

        // hotSpot은 100 x 100 그리드에서 5 x 5 그리드만큼 차지하게 됨
        public void MakeBonfire(int x, int z)
        {
                // private float bonfireTemp;
                float hotSpotTemp = Random.Range(hotSpotTempLow, hotSpotTempHigh);

                for (int i = x - 2; i < x + 3; ++i)
                {
                        for (int j = z - 2; j < z + 3; ++j)
                        {
                                areaTemp[i, j] = hotSpotTemp;
                        }
                }

                // // Making 5x5 size of bonfire
                // areaTemp[x - 2, z - 2] = hotSpotTemp;
                // areaTemp[x - 2, z - 1] = hotSpotTemp;
                // areaTemp[x - 2, z] = hotSpotTemp;
                // areaTemp[x - 2, z + 1] = hotSpotTemp;
                // areaTemp[x - 2, z + 2] = hotSpotTemp;

                // areaTemp[x - 1, z - 2] = hotSpotTemp;
                // areaTemp[x - 1, z - 1] = hotSpotTemp;
                // areaTemp[x - 1, z] = hotSpotTemp;
                // areaTemp[x - 1, z + 1] = hotSpotTemp;
                // areaTemp[x - 1, z + 2] = hotSpotTemp;

                // areaTemp[x, z - 2] = hotSpotTemp;
                // areaTemp[x, z - 1] = hotSpotTemp;
                // areaTemp[x, z] = hotSpotTemp;
                // areaTemp[x, z + 1] = hotSpotTemp;
                // areaTemp[x, z + 2] = hotSpotTemp;

                // areaTemp[x + 1, z - 2] = hotSpotTemp;
                // areaTemp[x + 1, z - 1] = hotSpotTemp;
                // areaTemp[x + 1, z] = hotSpotTemp;
                // areaTemp[x + 1, z + 1] = hotSpotTemp;
                // areaTemp[x + 1, z + 2] = hotSpotTemp;

                // areaTemp[x + 2, z - 2] = hotSpotTemp;
                // areaTemp[x + 2, z - 1] = hotSpotTemp;
                // areaTemp[x + 2, z] = hotSpotTemp;
                // areaTemp[x + 2, z + 1] = hotSpotTemp;
                // areaTemp[x + 2, z + 2] = hotSpotTemp;
        }

        //Game Object 영역의 온도를 올려주는 메소드
        public void MakeObjectHotspot(int a, int b)
        {
                //areaTemp의 x,z는 0~100으로 설정되어있는데, 실제 scene에서의 transform의 x좌표가 약 -70~30으로 지정되어있음.
                //따라서 object의 transform을 받아와서 +70을 해줘야 areaTemp에서 위치가 알맞게 지정됨.

                a = (int)Cave.transform.position.x + 70;
                b = (int)Cave.transform.position.z;

                // private float objectSpotTemp;
                float objectSpotTemp = objectTemp;

                // Making 10a10 sibe of objectSpot
                if (objectSpotCount > 0)
                {
                        for (int i = -5; i < 5; ++i)
                        {
                                for (int j = 0; j < 10; ++j)
                                {
                                        areaTemp[a + i, b + j] = objectSpotTemp;
                                }
                        }
                }
        }

        public double GetNormalizedAreaTemp(int x, int z)
        {
                return normalizedAreaTemp[x, z];
        }

        public double GetNormalizedGuassian(int x, int z)
        {
                return normalizedSmoothed[x, z];
        }

        public static double Remap(double input, double oldLow, double oldHigh, double newLow, double newHigh)
        {
                double t = Mathf.InverseLerp((float)oldLow, (float)oldHigh, (float)input);
                return Mathf.Lerp((float)newLow, (float)newHigh, (float)t);
        }

        public void SmoothingAreaTemp()
        {

                var mat = new Mat(numberOfCubeX, numberOfCubeZ, MatType.CV_64FC1);
                for (int i = 0; i < numberOfCubeX; i++)
                {
                        for (int j = 0; j < numberOfCubeZ; j++)
                        {
                                mat.Set<double>(i, j, areaTemp[i, j]);
                        }
                }

                Cv2.GaussianBlur(mat, mat, new OpenCvSharp.Size(kernelSizeX, kernelSizeX), sigmaX: sigmaX, sigmaY: sigmaY);


                // Convert the smoothed Mat object back to a 2D array
                // smoothed = new double[100, 100];
                for (int i = 0; i < numberOfCubeX; i++)
                {
                        for (int j = 0; j < numberOfCubeZ; j++)
                        {
                                areaTemp[i, j] = mat.At<double>(i, j);
                        }
                }
        }
}
