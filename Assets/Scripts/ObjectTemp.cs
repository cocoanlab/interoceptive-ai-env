// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using System.Text;
// using System.Linq;
// using Unity.MLAgents;

// public class ObjectTemp : AreaTempSmoothing
// {
//     public GameObject Cave;
//     public float objectTemp = 80.0f;
//     private EnvironmentParameters m_ResetParams;

//     private void SetParameters()
//     {
//         objectTemp = m_ResetParams.GetWithDefault("objectTemp", objectTemp);

//     }
//     public void EpisodeAreaSmoothing()
//     {
//             //object(cave)의 개수만큼 MakeObjectHotspot 메소드를 실행시켜줌
//         for (int tempCount = 0; tempCount < objectSpotCount; ++tempCount)
//         {
//             if(objectSpotCount > 0) //objectSpotCount의 개수가 0이면 실행 안되게 해줌.
//             {
//                 MakeObjectHotspot(Random.Range(2, 98), Random.Range(2, 98));
//             }
//         }
//     }

//         //Game Object 영역의 온도를 올려주는 메소드
//     public void MakeObjectHotspot(int a, int b)
//     {   
//         //areaTemp의 x,z는 0~100으로 설정되어있는데, 실제 scene에서의 transform의 x좌표가 약 -70~30으로 지정되어있음.
//         //따라서 object의 transform을 받아와서 +70을 해줘야 areaTemp에서 위치가 알맞게 지정됨.

//         a = (int)Cave.transform.position.x + 70;
//         b = (int)Cave.transform.position.z;

//         // private float objectSpotTemp;
//         float objectSpotTemp = objectTemp;

//         // Making 10a10 sibe of objectSpot
//         if(objectSpotCount > 0)
//         {
//             for (int i = -5; i < 5; ++i)
//             {
//                 for (int j = 0; j < 10; ++j)
//                 {
//                     areaTemp[a + i, b + j] = objectSpotTemp;
//                 }
//             } 
//         }
//     }

// }
