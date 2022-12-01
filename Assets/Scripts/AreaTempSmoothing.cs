using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.Linq;
using Unity.MLAgents;

public class AreaTempSmoothing : MonoBehaviour
{
        // Variables for code
        private EnvironmentParameters m_ResetParams;
        public float[,] areaTemp;
        private int areaWidth;
        private int areaDepth;
        private float oldLow;
        private float oldHigh;
        private float newLow;
        private float newHigh;
        public float[,] normalizedAreaTemp;

        [Header("Field Temperature parameters")]
        public float hotSpotCount = 300;
        public int smoothingRepetition = 10;
        public float hotSpotTempLow = 60.0f;
        public float hotSpotTempHigh = 60.0f;
        public float fieldDefaultTempLow = -60.0f;
        public float fieldDefaultTempHigh = -60.0f;


        public void Awake()
        {
                Academy.Instance.OnEnvironmentReset += SetParameters;
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

        }

        public void EpisodeAreaSmoothing()
        {
                areaTemp = new float[100, 100];

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

                for (int x = 0; x < 100; ++x)
                {
                        for (int z = 0; z < 100; ++z)
                        {
                                if (x >= 40 && x < 60 && z >= 40 && z < 60)
                                {
                                        areaTemp[x, z] = Random.Range(fieldDefaultTempLow, fieldDefaultTempHigh);
                                }
                                else if (x >= 0 && x < 50 && z >= 0 && z < 50)
                                {
                                        areaTemp[x, z] = Random.Range(fieldDefaultTempLow, fieldDefaultTempHigh);
                                }
                                else if (x >= 0 && x < 50 && z >= 50 && z < 100)
                                {
                                        areaTemp[x, z] = Random.Range(fieldDefaultTempLow, fieldDefaultTempHigh);
                                }
                                else if (x >= 50 && x < 100 && z >= 0 && z < 50)
                                {
                                        areaTemp[x, z] = Random.Range(fieldDefaultTempLow, fieldDefaultTempHigh);
                                }
                                else if (x >= 50 && x < 100 && z >= 50 && z < 100)
                                {
                                        areaTemp[x, z] = Random.Range(fieldDefaultTempLow, fieldDefaultTempHigh);
                                }
                                else
                                {
                                        areaTemp[x, z] = 0;
                                }
                        }
                }

                for (int tempCount = 0; tempCount < hotSpotCount; ++tempCount)
                {
                        MakeBonfire(Random.Range(2, 98), Random.Range(2, 98));
                }


                areaWidth = 100;
                areaDepth = 100;
                SmoothingAreaTemp(smoothingRepetition, areaTemp, areaWidth, areaDepth);

                normalizedAreaTemp = new float[100, 100];
                oldLow = areaTemp.Cast<float>().Min();
                oldHigh = areaTemp.Cast<float>().Max();
                newLow = 0.0f;
                newHigh = 1.0f;

                for (int x = 0; x < 100; ++x)
                {
                        for (int z = 0; z < 100; ++z)
                        {
                                normalizedAreaTemp[x, z] = Remap(areaTemp[x, z], oldLow, oldHigh, newLow, newHigh);
                        }
                }

        }


        public float GetAreaTemp(int x, int z)
        {
                return areaTemp[x, z];
        }

        public void SetAreaTemp(float temp)
        {
                for (int x = 0; x < 100; ++x)
                {
                        for (int z = 0; z < 100; ++z)
                        {
                                areaTemp[x, z] = areaTemp[x, z] + temp;
                        }
                }
        }

        public void MakeBonfire(int x, int z)
        {
                // private float bonfireTemp;
                float hotSpotTemp = Random.Range(hotSpotTempLow, hotSpotTempHigh);

                // Making 5x5 size of bonfire
                areaTemp[x - 2, z - 2] = hotSpotTemp;
                areaTemp[x - 2, z - 1] = hotSpotTemp;
                areaTemp[x - 2, z] = hotSpotTemp;
                areaTemp[x - 2, z + 1] = hotSpotTemp;
                areaTemp[x - 2, z + 2] = hotSpotTemp;

                areaTemp[x - 1, z - 2] = hotSpotTemp;
                areaTemp[x - 1, z - 1] = hotSpotTemp;
                areaTemp[x - 1, z] = hotSpotTemp;
                areaTemp[x - 1, z + 1] = hotSpotTemp;
                areaTemp[x - 1, z + 2] = hotSpotTemp;

                areaTemp[x, z - 2] = hotSpotTemp;
                areaTemp[x, z - 1] = hotSpotTemp;
                areaTemp[x, z] = hotSpotTemp;
                areaTemp[x, z + 1] = hotSpotTemp;
                areaTemp[x, z + 2] = hotSpotTemp;

                areaTemp[x + 1, z - 2] = hotSpotTemp;
                areaTemp[x + 1, z - 1] = hotSpotTemp;
                areaTemp[x + 1, z] = hotSpotTemp;
                areaTemp[x + 1, z + 1] = hotSpotTemp;
                areaTemp[x + 1, z + 2] = hotSpotTemp;

                areaTemp[x + 2, z - 2] = hotSpotTemp;
                areaTemp[x + 2, z - 1] = hotSpotTemp;
                areaTemp[x + 2, z] = hotSpotTemp;
                areaTemp[x + 2, z + 1] = hotSpotTemp;
                areaTemp[x + 2, z + 2] = hotSpotTemp;
        }

        public float GetNormalizedAreaTemp(int x, int z)
        {
                return normalizedAreaTemp[x, z];
        }

        public static float Remap(float input, float oldLow, float oldHigh, float newLow, float newHigh)
        {
                float t = Mathf.InverseLerp(oldLow, oldHigh, input);
                return Mathf.Lerp(newLow, newHigh, t);
        }


        public void SmoothingAreaTemp(int smoothingRepetition, float[,] areaTemp, int areaWidth, int areaDepth)
        {
                float[,] newareaTemp;

                while (smoothingRepetition > 0)
                {
                        smoothingRepetition--;

                        // Note: areaWidth and areaDepth should be equal and power-of-two values 
                        newareaTemp = new float[areaWidth, areaDepth];

                        for (int x = 0; x < areaWidth; x++)
                        {
                                for (int y = 0; y < areaDepth; y++)
                                {
                                        int adjacentSections = 0;
                                        float sectionsTotal = 0.0f;

                                        if ((x - 1) > 0) // Check to left
                                        {
                                                sectionsTotal += areaTemp[x - 1, y];
                                                adjacentSections++;

                                                if ((y - 1) > 0) // Check up and to the left
                                                {
                                                        sectionsTotal += areaTemp[x - 1, y - 1];
                                                        adjacentSections++;
                                                }

                                                if ((y + 1) < areaDepth) // Check down and to the left
                                                {
                                                        sectionsTotal += areaTemp[x - 1, y + 1];
                                                        adjacentSections++;
                                                }
                                        }

                                        if ((x + 1) < areaWidth) // Check to right
                                        {
                                                sectionsTotal += areaTemp[x + 1, y];
                                                adjacentSections++;

                                                if ((y - 1) > 0) // Check up and to the right
                                                {
                                                        sectionsTotal += areaTemp[x + 1, y - 1];
                                                        adjacentSections++;
                                                }

                                                if ((y + 1) < areaDepth) // Check down and to the right
                                                {
                                                        sectionsTotal += areaTemp[x + 1, y + 1];
                                                        adjacentSections++;
                                                }
                                        }

                                        if ((y - 1) > 0) // Check above
                                        {
                                                sectionsTotal += areaTemp[x, y - 1];
                                                adjacentSections++;
                                        }

                                        if ((y + 1) < areaDepth) // Check below
                                        {
                                                sectionsTotal += areaTemp[x, y + 1];
                                                adjacentSections++;
                                        }

                                        newareaTemp[x, y] = (areaTemp[x, y] + (sectionsTotal / adjacentSections)) * 0.5f;
                                }
                        }

                        // Overwrite the areaTemp info with our new smoothed info
                        for (int x = 0; x < areaWidth; x++)
                        {
                                for (int y = 0; y < areaDepth; y++)
                                {
                                        areaTemp[x, y] = newareaTemp[x, y];
                                }
                        }
                }
        }
}
