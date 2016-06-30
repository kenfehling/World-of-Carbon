using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {

    private GameObject child;
    private SoundManager soundManager;
    private AudioSource source;
    private string composition;
    private float temperature;
    private float pressure;
    private int numOfOxides;
    private int numOfCarbons;
    private CloudCollector cloud;
    void Start()
    {
        //Stores reference to default child, destroys the child's rigidbody
        if (!child)
        {
            child = transform.GetChild(0).gameObject;
            Destroy(child.GetComponent<Rigidbody2D>());
        }

        source = gameObject.AddComponent<AudioSource>();
        cloud = gameObject.GetComponentInChildren<CloudCollector>();
        source.loop = false;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        try
        {
            soundManager.playClackSound(source);
        }
        catch
        {
            soundManager = GameObject.Find("GameManager").GetComponent<GameManager>().getSoundManager();
            soundManager.playClackSound(source);
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

    public bool IsOxidePresent()
    {
        return numOfOxides > 0 ? true : false;
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

    public CloudCollector GetCloud()
    {
        return cloud;
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

    public void IncrementOxides()
    {
        ++numOfOxides;
    }

    public void DecrementOxides()
    {
        --numOfOxides;
    }

    public void IncrementCarbons()
    {
        ++numOfCarbons;
    }

    public void DecrementCarbons()
    {
        --numOfCarbons;
    }

    public int GetNumOfCarbons()
    {
        return numOfCarbons;
    }

    public AudioSource GetAudioSource()
    {
        return source;
    }
}
