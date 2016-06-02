using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {

    private GameObject child;
    private string composition;
    private float temperature;
    private float pressure;

    void Start()
    {
        //Stores reference to default child, destroys the child's rigidbody
        if (!child)
        {
            child = transform.GetChild(0).gameObject;
            Destroy(child.GetComponent<Rigidbody2D>());
        }
    }

    public void SetChild(GameObject child)
    {
        //Do any bookkeeping required by the old molecule here, since it's being replaced
        //Destroy the old child
        Destroy(this.child);
        //Remove Rigidbody2D from new child
        Destroy(child.GetComponent<Rigidbody2D>());
        //Store the reference to the new child
        this.child = child;
    }

    //Basic getters and setters
    public string GetComposition()
    {
        return composition;
    }

    public void SetComposition(string composition)
    {
        this.composition = composition;
    }

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
}
