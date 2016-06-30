using UnityEngine;
using System.Collections;

public class CloudCollector : MonoBehaviour {

    private int baseNumber = 100;
    public int numberOfCarbons = 0;
    public int cloudFactor = 20;
    private ParticleSystem cloud;
	// Use this for initialization
	void Start () {
        cloud = GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
        cloud.maxParticles = baseNumber + (numberOfCarbons * cloudFactor);
        cloud.startLifetime = 1 + (0.5f * numberOfCarbons);
	}

    public void IncNumOfCarbons()
    {
        ++numberOfCarbons;
    }

    public void DecNumOfCarbons()
    {
        --numberOfCarbons;
    }
}
