using UnityEngine;
using System.Collections;

public class PlayerProperties : MonoBehaviour {

    private float temperature;
    private float pressure;
    private string composition;

    void Start()
    {

    }

    //Getters and setters
    public float getTemperature()
    {
        return temperature;
    }

    public void setTemperature(float temperature)
    {
        this.temperature = temperature;
    }

    public float getPressure()
    {
        return pressure;
    }

    public void setPressure(float pressure)
    {
        this.pressure = pressure;
    }

    public string getComposition()
    {
        return composition;
    }

    public void setComposition(string composition)
    {
        this.composition = composition;
    }
}
