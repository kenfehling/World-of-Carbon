using UnityEngine;
using System.Collections;

public class SlingShotSprite : MonoBehaviour {
    public float forceScale = 1.0f;
    public float decelerationCoefficient = 1.0f;
    public float angularDecelerationCoefficient = 1.0f;

	private Vector3 clickPoint;
	private Vector3 releasePoint;
	private Vector3 difference;
	private Rigidbody2D rb;

	private float angle;
	private float movementCoef;
	//private Vector3 startPoint;
	//private float startTime;

	void Start() {
		rb = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate () {
        /*
		if (clicked) {
			//makes the smaller sprite follow the mouse
			//spriteRender.sprite = Arrow;
			//find mouse position up to a certain max radius. make vector from mouse position to object center
			//use arrow prefab and a circle. the arrow shows where the object will end up. the circle shows the max pull back
			//the arrow will scale at 1-3 with the distance you pull back FOR NOW.
		} else if (released) {

			this.transform.position = Camera.main.ScreenToWorldPoint (clickPoint);
			//put the gradual movement stuff here
			//this.transform.Translate(clickPoint.x,clickPoint.y, Time.deltaTime);
		}
		*/

        //We need to simulate drag here.
        float fixedDecelCoeff = decelerationCoefficient * Time.fixedDeltaTime;
        rb.velocity = rb.velocity.normalized * Mathf.Lerp(rb.velocity.magnitude, 0.0f, fixedDecelCoeff);
        //rb.angularVelocity = rb.angularVelocity;
    }

	void OnMouseDown(){
		clickPoint = Input.mousePosition;//the place where you first click
		clickPoint.z = 5f; 
	}

	void setMovementCoef(){
		movementCoef = 3f;
	}

	void setMovementCoef(string initEnvInfo){
		//do some other things
		movementCoef = 3f;
	}

	void OnMouseUp(){
		releasePoint = Input.mousePosition;
		difference.x = clickPoint.x - releasePoint.x;
		difference.y = clickPoint.y - releasePoint.y;
		difference.z = 5f;

		rb.AddForce(new Vector2 (difference.x * forceScale, difference.y * forceScale));
		return;

        /*
		angle = Mathf.Atan (difference.y / difference.x);
		if (difference.x > 100f) {
			if (difference.y == 0) {
				difference.x = 100f;
			} else if(difference.y > 0){
				difference.x = 100f * Mathf.Cos (angle);
				difference.y = 100f * Mathf.Sin (angle); 
			} else if(difference.y < 0){
				difference.x = 100f * Mathf.Cos (angle);
				difference.y = 100f * Mathf.Sin (angle); 
			}
		} else if (difference.x < -100f) {
			if (difference.y == 0) {
				difference.x = -100f;
			} else if(difference.y > 0){
				difference.x = -100f * Mathf.Cos (angle);
				difference.y = -100f * Mathf.Sin (angle); 
			} else if(difference.y < 0){
				difference.x = -100f * Mathf.Cos (angle);
				difference.y = -100f * Mathf.Sin (angle); 
			}

		} else if (difference.y > 100f) {	
			if (difference.x == 0) {
				difference.y = 100f;
			} else if (difference.x > 0) {
				difference.x = 100f * Mathf.Cos (angle);
				difference.y = 100f * Mathf.Sin (angle); 

			}else if (difference.x < 0){
				difference.x = -100f * Mathf.Cos (angle);
				difference.y = -100f * Mathf.Sin (angle); 
			}
		} else if (difference.y < -100f) {	
			if (difference.x == 0) {
				difference.y = -100f;
			} else if (difference.x > 0) {
				difference.x = 100f * Mathf.Cos (angle);
				difference.y = 100f * Mathf.Sin (angle); 
			} else if (difference.x < 0){
				difference.x = -100f * Mathf.Cos (angle);
				difference.y = -100f * Mathf.Sin (angle); 
			}

		}
		startPoint.x = clickPoint.x;
		startPoint.y = clickPoint.y;
		startPoint.z = 5f;
		startTime = Time.time;

		//find pressure and temperarture to see distance the object will go. 
		//raycast object to find collisions, angles, reactions and so on.
		
		setMovementCoef();
		clickPoint.x += difference.x * movementCoef;
		clickPoint.y += difference.y * movementCoef; 
		clickPoint.z = 5f;
		*/

	}
}