using UnityEngine;
using System.Collections;

public class SlingShotSprite : MonoBehaviour {
    
    public float forceScale = 1.0f;
    public float decelerationCoefficient = 1.0f;

    private GameObject lineCylinder;
    private Rigidbody2D rb;
    private Vector3 clickPoint;
	private Vector3 releasePoint;
	private Vector3 difference;
    private float cylinderScale;


	void Start() {
        lineCylinder = (GameObject)Instantiate(Resources.Load(ResourcePaths.DragLine), Vector3.zero, Quaternion.identity);
        cylinderScale = lineCylinder.transform.localScale.x;
        lineCylinder.SetActive(false);

        rb = GetComponent<Rigidbody2D> ();
	}

    void Update()
    {
        lineCylinder.SetActive(TapHandler.playerTapped);

        if (lineCylinder.activeSelf)
        {
            Vector3 mouse = (Camera.main.ScreenToWorldPoint(Input.mousePosition));
            mouse.z = 0;
            Vector3 difference = mouse - transform.position;

            lineCylinder.transform.up = difference;
            lineCylinder.transform.position = transform.position + (difference / 2.0f);
            lineCylinder.transform.localScale = new Vector3(cylinderScale, difference.magnitude / 2.0f, cylinderScale);

            lineCylinder.GetComponent<Renderer>().material.color = Color.Lerp(Color.blue, Color.red, lineCylinder.transform.localScale.y / 2.0f);
        }
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
        if (TapHandler.playerTapped)
        {
            releasePoint = Input.mousePosition;
            difference.x = clickPoint.x - releasePoint.x;
            difference.y = clickPoint.y - releasePoint.y;
            difference.z = 5f;

            rb.AddForce(new Vector2(difference.x * forceScale, difference.y * forceScale));
        }
        lineCylinder.SetActive(false);
    }
}