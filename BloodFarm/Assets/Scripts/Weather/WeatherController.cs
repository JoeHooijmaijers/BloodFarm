using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherController : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem sno;
    [SerializeField]
    private ParticleSystem driz;
    [SerializeField]
    private ParticleSystem rain;
    [SerializeField]
    private ParticleSystem cloudy;

    private void Start()
    {
        DisableEverything();
    }

    public void SetWeatherSnow()
    {
        DisableEverything();
        sno.Play();
    }

    public void SetWeatherDrizzle()
    {
        DisableEverything();
        driz.Play();
    }

    public void SetWeatherRain()
    {
        DisableEverything();
        rain.Play();
    }

    public void SetWeatherThunderstorm()
    {
        DisableEverything();
    }

    public void SetWeatherClouds()
    {
        DisableEverything();
        cloudy.Play();
    }

    public void SetWeatherClear()
    {
        DisableEverything();
    }

    private void DisableEverything()
    {
        sno.Stop();
        driz.Stop();
        rain.Stop();
        cloudy.Stop();
    }
}
