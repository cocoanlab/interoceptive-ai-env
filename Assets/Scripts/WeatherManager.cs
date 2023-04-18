// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class WeatherManager : MonoBehaviour
// {
//     public enum Season {NONE, SPRING, SUMMER, AUTUMN, WINTER};
//     public enum Weather{NONE, SUNNY, HOTSUN, RAIN, SNOW};
//     public Season currentSeason;
//     public Weather currentweather;

//     [Header ("Time Settings")]
//     public float seasonTime;
//     public float springTime;
//     public float summerTime;
//     public float autumnTime;
//     public float winterTime;

//     public int currentYear;

//     private void Start()
//     {
//         this.currentSeason = Season.SPRING;
//         this.currentweather = Weather.SUNNY;
//         this.currentYear = 1;

//         this.seasonTime = this.springTime;
//     }

//     public void ChangeSeason (Season seasonType)
//     {
//         if (seasonType != this.currentSeason)
//         {
//             switch (seasonType)
//             {
//                 case Season.SPRING;
//                     currentSeason = Season.SPRING;
//                     break;
//                 case Season.SUMMER
//                     currentSeason = Season.SUMMER;
//                     break;
//                 case Season.AUTUMN;
//                     currentSeason = Season.AUTUMN;
//                     break;
//                 case Season.WINTER;
//                     currentSeason = Season.WINTER;
//                     break;
//             }
//         }
//     }

//     public void ChangeWeather (Weather weatherType)
//     {
//         if (weatherType != this.currentweather)
//         {
//             switch (weatherType)
//             {
//                 case Weather.SUNNY;
//                     currentweather = Weather.SUNNY;
//                     break;
//                 case Weather.HOTSUN;
//                     currentweather = Weather.HOTSUN;
//                     break;
//                 case Weather.RAIN;
//                     currentweather = Weather.RAIN;
//                     break;
//                 case Weather.SNOW;
//                     currentweather = Weather.SNOW;
//                     break;
//             }
//         }
//     }

// }
