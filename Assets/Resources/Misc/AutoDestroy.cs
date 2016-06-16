using UnityEngine;
using System.Collections;

public class AutoDestroy : MonoBehaviour 
{
    private ParticleSystem p;
	// Use this for initialization
	void Start () {
	    p = GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {

        if (!p.IsAlive())
            Destroy(gameObject);
	}
}
