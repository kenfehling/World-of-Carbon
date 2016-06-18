using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {

	public float rotateSpeed;
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.Rotate(new Vector3(0.0f, 0.0f, rotateSpeed * Time.fixedDeltaTime));
	}
}
