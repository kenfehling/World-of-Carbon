using UnityEngine;
using System.Collections;

public class SlingShotSprite : MonoBehaviour {
    public float forceScale = 1.0f;
    public float decelerationCoefficient = 1.0f;

	private Vector3 clickPoint;
	private Vector3 releasePoint;
	private Vector3 difference;
	private Rigidbody2D rb;

	void Start() {
		rb = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate () {
        //We need to simulate drag here.
        //This might be affected by heat or other environmental hazards
        float fixedDecelCoeff = decelerationCoefficient * Time.fixedDeltaTime;
        rb.velocity = rb.velocity.normalized * Mathf.Lerp(rb.velocity.magnitude, 0.0f, fixedDecelCoeff);
    }

	void OnMouseDown(){
		clickPoint = Input.mousePosition;//the place where you first click
		clickPoint.z = 5f; 
	}

	void OnMouseUp(){
		releasePoint = Input.mousePosition;
		difference.x = clickPoint.x - releasePoint.x;
		difference.y = clickPoint.y - releasePoint.y;
		difference.z = 5f;

		rb.AddForce(new Vector2 (difference.x * forceScale, difference.y * forceScale));
		return;
    }
}