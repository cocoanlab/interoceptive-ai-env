using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.Linq;
using Unity.MLAgents;

using System.Drawing;
using OpenCvSharp;

// GameObject인 FoodCollectorArea에 부착함
// 그리드 역할을 할 cube를 100 x 100
// 총 10000개 생성하고 각각에 좌표를 이용하여 명명함
// 별도로 Inspector 창에서 tag로 "cube" 추가해야 함
public class FieldThermoGrid : MonoBehaviour
{
        public int numberOfCubeX = 100;
        public int numberOfCubeZ = 100;
        public Vector3 sizeOfCube = new Vector3(1, 5, 1);
        public Vector3 positionOfCenter = new Vector3(0.0f, 0.0f, 0.0f);

        // public bool useThermalObs = false;
        public InteroceptiveAgent agent;


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

        public int kernelSizeX = 7;
        public int kernelSizeY = 7;
        public float sigmaX = 10.0f;
        public float sigmaY = 10.0f;


        private double[,] smoothed;
        private double[,] normalizedSmoothed;

        public void Awake()
        {
                Academy.Instance.OnEnvironmentReset += SetParameters;

                Vector3 count = new Vector3(numberOfCubeX, 0.0f, numberOfCubeZ);
                if (agent.useThermalObs)
                {
                        generateCube(count, positionOfCenter);
                }
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

        private void generateCube(Vector3 count, Vector3 position)
        {
                // var layer = LayerMask.NameToLayer("cube");
                Transform parent = new GameObject().transform;
                GameObject newCube = null;

                for (int x = 0; x < numberOfCubeX; ++x)
                {
                        for (int z = 0; z < numberOfCubeZ; ++z)
                        {
                                // 게임 오브젝트 클래스에 내장되어 있는 CreatePrimitive 스태틱 함수를 이용하여 큐브 생성
                                newCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                                // newCube.transform.localScale = sizeOfCube;
                                newCube.transform.localScale = sizeOfCube;
                                newCube.transform.position = new Vector3(x * sizeOfCube.x, 0.0f, z * sizeOfCube.z) + positionOfCenter;


                                newCube.GetComponent<Renderer>().enabled = false;

                                newCube.name = string.Format("{0},0,{1}", x, z);
                                newCube.transform.SetParent(parent);
                                // newCube.layer = layer;
                                newCube.tag = "cube";

                                Collider collider = newCube.GetComponent<Collider>();
                                collider.isTrigger = true;
                        }
                }

                parent.name = string.Format("Cube groups : {0}x0x{1}", count.x, count.z);
                parent.position = position;
                parent.transform.parent = transform;
                // parent.gameObject.layer = layer;
        }

        public void EpisodeAreaSmoothing()
        {
                areaTemp = new double[numberOfCubeX, numberOfCubeZ];

                for (int x = 0; x < numberOfCubeX; ++x)
                {
                        for (int z = 0; z < numberOfCubeZ; ++z)
                        {
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
