using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof(WeatherController))]
public class WeatherAPI : MonoBehaviour
{
    private WeatherController wc;

    private const string API_KEY = "d87bca4040426991f13332aa55fa5c41";
    private const float API_MAX_COUNTDOWN = 30 * 60.0f;
    private float apiCountdown = API_MAX_COUNTDOWN;
    public string cityID = "2756252";


    // Start is called before the first frame update
    void Start()
    {
        wc = GetComponent<WeatherController>();
        StartCoroutine(GetWeather(CheckWeatherStatus));
    }

    // Update is called once per frame
    void Update()
    {
        apiCountdown -= Time.deltaTime;
        if (apiCountdown <= 0)
        {
            StartCoroutine(GetWeather(CheckWeatherStatus));
            apiCountdown = API_MAX_COUNTDOWN;
        }
    }

    public void CheckWeatherStatus(WeatherInfo weatherObj)
    { 
        
        string weather = weatherObj.weather[0].main;

        switch (weather)
        {
            case "Thunderstorm":
                Debug.Log("It's thundering out they!");
                break;
            case "Drizzle":
                Debug.Log("It's drizzlin out they!");
                wc.SetWeatherDrizzle();
                break;
            case "Rain":
                Debug.Log("Someone makin it rain out they!");
                wc.SetWeatherRain();
                break;

            case "Snow":
                Debug.Log("Hotdamn, they's snow out they");
                wc.SetWeatherSnow();
                break;

            case "Clear":
                Debug.Log("Ain't no nothin out they");
                break;

            case "Clouds":
                Debug.Log("Cloudy AF, my dude");
                wc.SetWeatherClouds();
                break;
            default:
                Debug.Log("Shit gone wronge");
                break;
        }
    }

    IEnumerator GetWeather(Action<WeatherInfo> onSuccess)
    {
        using (UnityWebRequest req = UnityWebRequest.Get(String.Format("http://api.openweathermap.org/data/2.5/weather?id={0}&APPID={1}", cityID, API_KEY)))
        {
            yield return req.SendWebRequest();
            while (!req.isDone)
                yield return null;
            byte[] result = req.downloadHandler.data;
            string weatherJSON = System.Text.Encoding.Default.GetString(result);
            Debug.Log(weatherJSON);
            WeatherInfo info = JsonUtility.FromJson<WeatherInfo>(weatherJSON);
            onSuccess(info);
        }
    }
}
