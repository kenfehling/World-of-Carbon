using UnityEngine;
using System.Collections;

public class FlyTo : MonoBehaviour {

    public float flySpeed;

    private Transform target;

	void FixedUpdate () {
        transform.position = Vector3.Lerp(transform.position, target.position, flySpeed * Time.fixedDeltaTime);

        if(Vector3.Distance(transform.position, target.position) < 0.1f)
        {
            target.gameObject.GetComponent<PlayerManager>().IncrementCarbons();
            Destroy(gameObject);
        }
	}

    public void setTarget(Transform target)
    {
        this.target = target;
    }
}
