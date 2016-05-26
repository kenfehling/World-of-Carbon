using UnityEngine;
using System.Collections;

public class WorldProperties {

    // world temperature in Kelvin
    private float temperature;
    // world pressure in torr
    private float pressure;

    private int worldWidth;
    private int worldHeight;


    // called on level load to set the initial parameters for this level
    public void SetInitialParams(int width, int height, int initialPressure, int initialTemp)
    {
        worldWidth = width;
        worldHeight = height;
        pressure = initialPressure;
        temperature = initialTemp;
    }

    public float GetTemperature()
    {
        return temperature;
    }

    public float GetPressure()
    {
        return pressure;
    }

    public int GetWorldWidth()
    {
        return worldWidth;
    }

    public int GetWorldHeight()
    {
        return worldHeight;
    }
}
