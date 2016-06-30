using UnityEngine;
using System.Collections;

public class RandParticles : MonoBehaviour {

	// Use this for initialization
    public Material[] particleSprites = new Material[5];
	void Start () {
        ParticleSystemRenderer psr = GetComponent<ParticleSystem>().GetComponent<ParticleSystemRenderer>();
        psr.material = particleSprites[Random.Range(0, 4)];
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
