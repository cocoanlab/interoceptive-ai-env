using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class AreaTempSmoothing : MonoBehaviour
{
    private int smoothingRepetition;
    public float[,] areaTemp;
    private int areaWidth;
    private int areaDepth;

    private void Awake()
    {
        areaTemp = new float[100, 100];
        for (int x = 0; x < 100; ++x)
        {
            for (int z = 0; z < 100; ++z)
            {
                if (x >= 10 && x < 20)
                {
                    areaTemp[x, z] = -5.0f;
                }
                else if (x >= 30 && x < 40)
                {
                    areaTemp[x, z] = -10.0f;
                }
                else if (x >= 50 && x < 60)
                {
                    areaTemp[x, z] = 10.0f;
                }
                else if (x >= 70 && x < 80)
                {
                    areaTemp[x, z] = 5.0f;
                }
                else
                {
                    areaTemp[x, z] = 0.0f;
                }
            }
        }

        // Debug.Log(areaTemp[0, 0].ToString());
        // int rowLength = areaTemp.GetLength(0);
        // int colLength = areaTemp.GetLength(1);

        // 콘솔 창에서 작동되는지 확인하기 위함
        // StringBuilder sb = new StringBuilder();
        // for (int i = 0; i < areaTemp.GetLength(1); i++)
        // {
        //     for (int j = 0; j < areaTemp.GetLength(0); j++)
        //     {
        //         sb.Append(areaTemp[i, j]);
        //         sb.Append(' ');
        //     }
        //     sb.AppendLine();
        // }
        // Debug.Log(sb.ToString());

        smoothingRepetition = 3;
        areaWidth = 100;
        areaDepth = 100;
        SmoothingAreaTemp(smoothingRepetition, areaTemp, areaWidth, areaDepth);

        // Debug.Log(areaTemp[0, 0].ToString());
        // StringBuilder sc = new StringBuilder();
        // for (int i = 0; i < areaTemp.GetLength(1); i++)
        // {
        //     for (int j = 0; j < areaTemp.GetLength(0); j++)
        //     {
        //         sc.Append(areaTemp[i, j]);
        //         sc.Append(' ');
        //     }
        //     sc.AppendLine();
        // }
        // Debug.Log(sc.ToString());

    }

    public float GetAreaTemp(int x, int z)
    {
        return areaTemp[x, z];
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
