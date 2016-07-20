using UnityEngine;
using System.Collections;

public class FlyTo : MonoBehaviour {

    public float flySpeed = 1.0f;

    private Vector3 target;
    private float fadeOutSpeed = 2.0f;

	void FixedUpdate () {
        transform.position = Vector3.Lerp(transform.position, target, flySpeed * Time.fixedDeltaTime);
	}

    public void setTarget(Transform target)
    {
        this.target = target.position;
    }

    public void setTarget(Vector3 target)
    {
        this.target = target;
    }
}
