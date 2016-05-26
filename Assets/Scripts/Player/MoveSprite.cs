using UnityEngine;
using System.Collections;

public class MoveSprite : MonoBehaviour {
	bool clicked = false;
	public Transform target;
	public float smoothTime = 0.3F;
	private Vector3 velocity = Vector3.zero;
	//Vector3 targetPosition
	//find coords of mouse when last update happened. compare to current update
	void Update () {
		if (clicked) {
			Vector3 temp = Input.mousePosition;
			temp.z = 5f; 
			this.transform.position = Camera.main.ScreenToWorldPoint (temp);
		} /*else {
			targetPosition = target.TransformPoint(new Vector3(0, 5, -10));
			this.transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
		}*/
	}
	void OnMouseDown(){
		if (!clicked)
			clicked = true;
		else if (clicked)
			clicked = false;
	}
	void OnMouseUp(){
		clicked = false;

	}
}