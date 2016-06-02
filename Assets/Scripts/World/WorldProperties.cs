using UnityEngine;
using System.Collections;

public class WorldProperties : MonoBehaviour {

    // world temperature in Kelvin
    [SerializeField] private float temperature;
    // world pressure in torr
    [SerializeField] private float pressure;

    [SerializeField] private int worldWidth;
    [SerializeField] private int worldHeight;

    public PlayerManager player = null;

    void Start()
    {
        if (!player)
        {
            player = GameObject.Find("Player").GetComponent<PlayerManager>();
        }
    }

    // called on level load to set the initial parameters for this level
    public void SetInitialParams(int width, int height, int initialPressure, int initialTemp)
    {
        worldWidth = width;
        worldHeight = height;
        pressure = initialPressure;
        temperature = initialTemp;
    }

    // Sets the reference to the player, must be called when player is created by level generator
    public void SetPlayer(ref PlayerManager p)
    {
        player = p;
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
