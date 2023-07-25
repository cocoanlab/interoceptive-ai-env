using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// public enum WeatherState { Change, Sun, Thunder, Mist, Rain, Snow }
public enum WeatherState { Change, Rain, Snow, None }

[RequireComponent(typeof(AudioSource))]   //필요한 component가 GameObject에 자동으로 추가됨
public class DynamicWeatherSystem : MonoBehaviour
{
        public float switchTimer = 0;
        public float resetTimer = 3600f;
        public float minLightIntensity = 0f;
        public float maxLightIntensity = 1f;
        private int switchWeather;
        public AudioSource audiosource;
        public Light sunLight;
        public Transform windzone;

        public WeatherState weatherState;
        public WeatherData[] weatherData;

        public void Awake()
        {
                audiosource = GetComponent<AudioSource>();
                RenderSettings.fog = true;
                RenderSettings.fogMode = FogMode.ExponentialSquared;
                RenderSettings.fogDensity = 0.0f;
        }

        public void Start()
        {
                LoadWeatherSystem();
                StartCoroutine((StartDynamicWeather()));

        }

        void LoadWeatherSystem()
        {
                for (int i = 0; i < weatherData.Length; i++)
                {
                        weatherData[i].emission = weatherData[i].particleSystem.emission;
                }
                switchTimer = resetTimer;
                ResetWeather();

        }

        private void FixedUpdate()
        {
                switchTimer -= Time.deltaTime;
                if (switchTimer > 0) return;
                if (switchTimer <= 0)
                {
                        switchTimer = 0;
                        weatherState = WeatherState.Change;
                        switchTimer = resetTimer;
                }
        }

        IEnumerator StartDynamicWeather()
        {
                while (true)
                {
                        if (weatherState == WeatherState.Change) { SelectWeather(); }
                        else if (weatherState == WeatherState.Rain) { ActivedWeather("Rain"); }
                        else if (weatherState == WeatherState.Snow) { ActivedWeather("Snow"); }
                        else if (weatherState == WeatherState.None) { ActivedWeather("None"); }
                        // else if (weatherState == WeatherState.Sun) {ActivedWeather("Sun"); }
                        // else if (weatherState == WeatherState.Thunder) {ActivedWeather("Thunder"); }
                        // else if (weatherState == WeatherState.Mist) {ActivedWeather("Mist"); }
                        // Debug.Log(weatherState);
                        yield return null;
                }
        }

        void ActivedWeather(string weather)
        {
                if (weatherData.Length > 0)
                {
                        for (int i = 0; i < weatherData.Length; i++)
                        {
                                if (weatherData[i].particleSystem != null)
                                {
                                        if (weatherData[i].name == weather)
                                        {
                                                weatherData[i].emission.enabled = true;
                                                weatherData[i].fogColor = RenderSettings.fogColor;
                                                RenderSettings.fogColor = Color.Lerp(weatherData[i].currentFogColor, weatherData[i].fogColor, weatherData[i].fogChangeSpeed * Time.deltaTime);

                                                ChangeWeatherSettings(weatherData[i].lightIntensity, weatherData[i].weatherAudio);
                                        }

                                }
                        }
                }
        }


        void SelectWeather()
        {
                switchWeather = Random.Range(0, System.Enum.GetValues(typeof(WeatherState)).Length);
                // Debug.Log(switchWeather);
                ResetWeather();
                if (switchWeather == 0) { weatherState = WeatherState.Change; }
                else if (switchWeather == 1) { weatherState = WeatherState.Rain; }
                else if (switchWeather == 2) { weatherState = WeatherState.Snow; }
                else if (switchWeather == 3) { weatherState = WeatherState.None; }
                // else if (switchWeather == 1) { weatherState = WeatherState.Sun; }
                // else if (switchWeather == 2) { weatherState = WeatherState.Thunder; }
                // else if (switchWeather == 3) { weatherState = WeatherState.Mist; }
        }

        void ChangeWeatherSettings(float lightIntensity, AudioClip audioClip)
        {
                Light tmpLight = GetComponent<Light>();
                if (tmpLight.intensity > maxLightIntensity) { tmpLight.intensity -= Time.deltaTime * lightIntensity; }
                if (tmpLight.intensity < maxLightIntensity) { tmpLight.intensity += Time.deltaTime * lightIntensity; }

                // if(weatherData[switchWeather].useAudio == true)
                {
                        AudioSource tmpAudio = GetComponent<AudioSource>();

                        if (tmpAudio.volume > 0 && tmpAudio.clip != audioClip)
                        {
                                tmpAudio.volume -= Time.deltaTime * weatherData[switchWeather].audioFadeInTimer;
                        }

                        if (tmpAudio.volume == 0)
                        {
                                tmpAudio.Stop();
                                tmpAudio.clip = audioClip;
                                tmpAudio.loop = true;
                                tmpAudio.Play();
                        }

                        if (tmpAudio.volume < 1 && tmpAudio.clip != audioClip)
                        {
                                tmpAudio.volume -= Time.deltaTime * weatherData[switchWeather].audioFadeInTimer;
                        }
                }
        }

        void ResetWeather()
        {
                if (weatherData.Length > 0)
                {
                        for (int i = 0; i < weatherData.Length; i++)
                        {
                                if (weatherData[i].emission.enabled != false)
                                {
                                        weatherData[i].emission.enabled = false;
                                }
                        }
                }
        }
}

