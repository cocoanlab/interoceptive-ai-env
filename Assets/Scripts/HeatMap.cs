using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeatMap : MonoBehaviour
{
        public Image heatMap;
        public GameObject area;
        public Gradient gradient;
        private Texture2D mapTexture;

        public GameObject agentTrack;

        public FoodCollectorAgent agent;

        // private int count = 0;
        // private int a = 10;
        // private int b = 10;

        void Awake()
        {
                if (agent.useThermalObs)
                {
                        mapTexture = new Texture2D(100, 100);
                }
                else
                {
                        heatMap.enabled = false;
                        agentTrack.GetComponent<Image>().enabled = false;
                }
        }

        public void EpisodeHeatMap()
        {

                ModifyPixels();

                // count += 1;
                // Debug.Log("Episode : " + count.ToString());
                // Debug.Log("Test : " + area.GetComponent<AreaTempSmoothing>().GetNormalizedAreaTemp(10, 10).ToString());

                // b = b + 10;
                // a = a + 10;

                // Debug.Log("a : " + a.ToString() + "b : " + b.ToString());

        }

        public void ModifyPixels()
        {
                for (int z = 0; z < mapTexture.height; z++)
                {
                        for (int x = 0; x < mapTexture.width; x++)
                        {
                                Color color = gradient.Evaluate(1 - area.GetComponent<AreaTempSmoothing>().GetNormalizedAreaTemp(x, z));
                                mapTexture.SetPixel(z, -x, color);
                        }
                }

                // mapTexture.SetPixel(b, -a, Color.black);

                mapTexture.Apply();

                heatMap.material.mainTexture = mapTexture;
        }

        // void Start()
        // {
        //     Renderer rend = GetComponent<Renderer>();

        //     // duplicate the original texture and assign to the material
        //     Texture2D texture = Instantiate(rend.material.mainTexture) as Texture2D;
        //     rend.material.mainTexture = texture;

        //     // colors used to tint the first 3 mip levels
        //     Color[] colors = new Color[3];
        //     colors[0] = Color.red;
        //     colors[1] = Color.green;
        //     colors[2] = Color.blue;
        //     int mipCount = Mathf.Min(3, texture.mipmapCount);

        //     // tint each mip level
        //     for (int mip = 0; mip < mipCount; ++mip)
        //     {
        //         Color[] cols = texture.GetPixels(mip);
        //         for (int i = 0; i < cols.Length; ++i)
        //         {
        //             cols[i] = Color.Lerp(cols[i], colors[mip], 0.33f);
        //         }
        //         texture.SetPixels(cols, mip);
        //     }
        //     // actually apply all SetPixels, don't recalculate mip levels
        //     texture.Apply(false);
        // }
}


