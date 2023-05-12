using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.Linq;
using Unity.MLAgents;

using System.Drawing;
using OpenCvSharp;

// GameObject인 Field 부착함
// 그리드 역할을 할 cube를 numberOfCubeX x numberOfCubeZ
// 생성하고 각각에 좌표를 이용하여 명명함
// 별도로 Inspector 창에서 tag로 "cube" 추가해야 함
public class FieldThermoGrid : MonoBehaviour
{
        public int numberOfCubeX = 25;
        public int numberOfCubeZ = 25;
        public Vector3 sizeOfCube = new Vector3(4, 5, 4);
        public Vector3 positionOfCenter = new Vector3(-25.0f, 0.0f, -25.0f);

        public struct HeatGridCube
        {
                public GameObject gridCube;
                public Vector2 arrayIndex;
        }
        private List<HeatGridCube> heatGridCubes = new List<HeatGridCube>();

        public InteroceptiveAgent agent;

        public GameObject[] heatObjectList;


        // Variables for code
        private EnvironmentParameters m_ResetParams;
        public double[,] areaTemp;
        public double[,] normalizedAreaTemp;

        [Header("Field Temperature parameters")]
        public bool useObjectHotSpot = true;
        public bool useRandomHotSpot = true;
        public float fieldDefaultTemp = -60.0f;

        public float hotSpotCount = 15;
        // public float objectSpotCount = 1;
        public float hotSpotTemp = 60.0f;
        // public float hotSpotTempHigh = 60.0f;
        public float heatMapMaxTemp = 60.0f;
        public float heatMapMinTemp = -60.0f;
        // public float objectTemp = 80.0f;

        public int smoothingKernelSizeX = 5;
        public int smoothingKernelSizeY = 5;
        public float smoothingSigmaX = 10.0f;
        public float smoothingSigmaY = 10.0f;

        public void Awake()
        {
                Academy.Instance.OnEnvironmentReset += SetParameters;

                Vector3 count = new Vector3(numberOfCubeX, 0.0f, numberOfCubeZ);
                if (agent.useThermalObs)
                {
                        generateCube(count, positionOfCenter);
                }

                heatObjectList = GameObject.FindGameObjectsWithTag("heatObject");
                // Debug.Log(heatObjectList);
                // Debug.Log("Number of heatObjects = " + heatObjectList.Length);
                // Debug.Log(heatObjectList[0].GetComponent<ThermalObject>().temperature);
        }

        private void SetParameters()
        {
                m_ResetParams = Academy.Instance.EnvironmentParameters;
                hotSpotCount = m_ResetParams.GetWithDefault("hotSpotCount", hotSpotCount);

                fieldDefaultTemp = m_ResetParams.GetWithDefault("fieldDefaultTemp", fieldDefaultTemp);
                hotSpotTemp = m_ResetParams.GetWithDefault("hotSpotTemp", hotSpotTemp);
                // objectTemp = m_ResetParams.GetWithDefault("objectTemp", objectTemp);
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
                                newCube.transform.localScale = sizeOfCube;
                                newCube.transform.position = new Vector3(x * sizeOfCube.x, 0.0f, z * sizeOfCube.z) + positionOfCenter;

                                newCube.GetComponent<Renderer>().enabled = false;

                                newCube.name = string.Format("{0},0,{1}", x, z);
                                newCube.transform.SetParent(parent);
                                // newCube.layer = layer;
                                newCube.tag = "cube";

                                Collider collider = newCube.GetComponent<Collider>();
                                collider.isTrigger = true;

                                HeatGridCube heatgridcube = new HeatGridCube();
                                heatgridcube.gridCube = newCube;
                                heatgridcube.arrayIndex = new Vector2(x, z);
                                heatGridCubes.Add(heatgridcube);
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

                // Setting default temperature
                for (int x = 0; x < numberOfCubeX; ++x)
                {
                        for (int z = 0; z < numberOfCubeZ; ++z)
                        {
                                areaTemp[x, z] = fieldDefaultTemp;
                        }
                }

                if (useRandomHotSpot)
                {
                        // Placing random position for hot spot
                        for (int hotSpotCount = 0; hotSpotCount < this.hotSpotCount; ++hotSpotCount)
                        {
                                int x = Random.Range(0, numberOfCubeX);
                                int z = Random.Range(0, numberOfCubeZ);
                                areaTemp[x, z] = hotSpotTemp;
                        }
                }

                // Adding temperature where Heat objects are located
                if (useObjectHotSpot)
                {
                        if (heatObjectList.Length > 0)
                        {
                                for (int objectCount = 0; objectCount < heatObjectList.Length; ++objectCount)
                                {
                                        Vector2 cubeIndex = FindCloseGridCube(heatObjectList[objectCount], heatGridCubes);
                                        float temperature = heatObjectList[objectCount].GetComponent<ThermalObject>().temperature;

                                        Vector3 sizeOfObject = heatObjectList[objectCount].transform.lossyScale;
                                        Vector3 sizeOfGridCube = heatGridCubes[0].gridCube.transform.lossyScale;

                                        int relativeSizeX = (int)Mathf.Ceil(sizeOfObject.x / sizeOfGridCube.x);
                                        int relativeSizeZ = (int)Mathf.Ceil(sizeOfObject.z / sizeOfGridCube.z);

                                        // areaTemp[(int)cubeIndex.x, (int)cubeIndex.y] += temperature;

                                        int startIndexI = Mathf.Max((int)cubeIndex.x - (int)relativeSizeX / 2, 0);
                                        int startIndexJ = Mathf.Max((int)cubeIndex.y - (int)relativeSizeZ / 2, 0);
                                        int endIndexI = Mathf.Min((int)cubeIndex.x + (int)relativeSizeX / 2, numberOfCubeX);
                                        int endIndexJ = Mathf.Min((int)cubeIndex.y + (int)relativeSizeZ / 2, numberOfCubeZ);

                                        for (int i = startIndexI; i < endIndexI; i++)
                                        {
                                                for (int j = startIndexJ; j < endIndexJ; j++)
                                                {
                                                        areaTemp[i, j] += temperature;
                                                }
                                        }

                                }
                        }
                }
                areaTemp = GaussianSmoothingAreaTemp(areaTemp);

                // 지형 온도의 정규화를 구현함
                // 0~1의 값으로 적외선 카메라 화면처럼 HeatMap을 구현하기 위함임
                normalizedAreaTemp = new double[numberOfCubeX, numberOfCubeZ];
                for (int x = 0; x < numberOfCubeX; ++x)
                {
                        for (int z = 0; z < numberOfCubeZ; ++z)
                        {
                                normalizedAreaTemp[x, z] = (areaTemp[x, z] - heatMapMinTemp) / (heatMapMaxTemp - heatMapMinTemp);
                        }
                }
        }

        public double[,] GaussianSmoothingAreaTemp(double[,] areaTempMatrix)
        {

                var mat = new Mat(numberOfCubeX, numberOfCubeZ, MatType.CV_64FC1);
                for (int i = 0; i < numberOfCubeX; i++)
                {
                        for (int j = 0; j < numberOfCubeZ; j++)
                        {
                                mat.Set<double>(i, j, areaTempMatrix[i, j]);
                        }
                }

                // BorderType reference: https://docs.opencv.org/3.4/d2/de8/group__core__array.html#ga209f2f4869e304c82d07739337eae7c5
                Cv2.GaussianBlur(mat, mat, new OpenCvSharp.Size(smoothingKernelSizeX, smoothingKernelSizeX), sigmaX: smoothingSigmaX, sigmaY: smoothingSigmaY, borderType: OpenCvSharp.BorderTypes.Reflect101);


                // Convert the smoothed Mat object back to a 2D array
                for (int i = 0; i < numberOfCubeX; i++)
                {
                        for (int j = 0; j < numberOfCubeZ; j++)
                        {
                                areaTempMatrix[i, j] = mat.At<double>(i, j);
                        }
                }

                return areaTempMatrix;
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

        public double GetNormalizedAreaTemp(int x, int z)
        {
                return normalizedAreaTemp[x, z];
        }

        public Vector2 FindCloseGridCube(GameObject heatobject, List<HeatGridCube> heatGridCubes)
        {
                float minDistance = Mathf.Infinity;
                int minDistCubeIndex = 0;

                for (int i = 0; i < heatGridCubes.Count; ++i)
                {
                        float distance = Vector3.Distance(heatobject.gameObject.transform.position, heatGridCubes[i].gridCube.transform.position);
                        if (distance < minDistance)
                        {
                                minDistance = distance;
                                minDistCubeIndex = i;
                        }
                }

                return heatGridCubes[minDistCubeIndex].arrayIndex;
        }

        private GameObject FindChildObjectWithName(GameObject parentObject, string childName)
        {
                for (int i = 0; i < parentObject.transform.childCount; i++)
                {
                        if (parentObject.transform.GetChild(i).name == childName)
                        {
                                return parentObject.transform.GetChild(i).gameObject;
                        }
                }

                return null;

        }

}
