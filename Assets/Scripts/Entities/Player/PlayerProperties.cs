using UnityEngine;
using System.Collections;

public class PlayerProperties {

    private float temperature;
    private float pressure;
    private string composition;

    void Start()
    {

    }

    //Getters and setters
    public float GetTemperature()
    {
        return temperature;
    }

    public void SetTemperature(float temperature)
    {
        this.temperature = temperature;
    }

    public float GetPressure()
    {
        return pressure;
    }

    public void SetPressure(float pressure)
    {
        this.pressure = pressure;
    }

    public string GetComposition()
    {
        return composition;
    }

    public void SetComposition(string composition)
    {
        this.composition = composition;
    }
}
