using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class rock : MonoBehaviour
{
    // public Rock prefab; 
    public GameObject Rock;

    private void Awake()
    {
        //Instantiate(Rock, new Vector3(3, 3, 0), Quaternion.identity);
        //Instantiate(Rock, new Vector3(-1, -2, 0), Quaternion.identity);
        // Instantiate(Rock);
        Quaternion rotation = Quaternion.Euler(0, 0, 45);
        //Instantiate(Rock, new Vector3(2, 1, 0), rotation);
        GameObject clone = Instantiate(Rock, Vector3.zero, rotation);
        clone.name = "Rock001";
        clone.transform.position = new Vector3(2, 1, 0);

    }
    // void CreateRock(int num, Rock type)
    //     {   
    //         for (int i = 0; i < num; i++)
    //         {
    //             if (string.Equals(type.name, "Rock"))
    //             Rock f = Instantiate(type, new Vector3(Random.Range(-range, range), 1f,
    //             Random.Range(-range, range)) + transform.position,
    //             Quaternion.Euler(new Vector3(0f, Random.Range(0f, 360f), 90f)));
    //             f.transform.parent = Rock.transform;
    //             f.InitializeProperties();

    //             f.name = "Rock" + (i + 1).ToString();
    //         }
    //     //  for (int i = 0; i < num; i++)
    //     //   {
        //     if (string.Equals(type.name("Rock")))
        //     {
        //       Rock Rock = Instantiate(prefab); 
        //       // Rock.transfrom.position = transfrom.position;
        //       // Rock.InitializeProperties();

        //       Rock.name = "Rock" + i.ToString();
        //     }
        //   }
        // }
}

