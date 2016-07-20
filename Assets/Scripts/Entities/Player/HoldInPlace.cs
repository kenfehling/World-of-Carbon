using UnityEngine;
using System.Collections;

public class HoldInPlace : MonoBehaviour {

    public float timeToHold = 2.0f;
    public float rotationSpeed = 200.0f;

    private Vector3 rotationVector;
    private Collider2D col;
    private float timer;

	void OnEnable () {
        col = GetComponent<Collider2D>();

        timer = timeToHold;
        col.enabled = false;
        rotationVector = new Vector3(0.0f, 0.0f, -rotationSpeed);
        gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
    }
	
	void Update () {
        timer -= Time.deltaTime;
        if(timer < 0.0f)
        {
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            col.enabled = true;
            GetComponent<FlyTo>().enabled = false;
            enabled = false;
        }
	}

    void FixedUpdate()
    {
        transform.Rotate(rotationVector*Time.fixedDeltaTime);
    }
}
