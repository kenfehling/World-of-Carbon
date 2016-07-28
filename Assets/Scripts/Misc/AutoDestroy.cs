using UnityEngine;
using System.Collections;

public class AutoDestroy : MonoBehaviour 
{
    private ParticleSystem p;

	void Start () {
	    p = GetComponent<ParticleSystem>();
	}
	
	void Update () {
        if (!p.IsAlive())
        {
            Destroy(gameObject);
        }
	}
}
