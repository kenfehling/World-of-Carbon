using UnityEngine;
using System.Collections;

public class FlyTo : MonoBehaviour {

    public float flySpeed;

    private SpriteRenderer rend;
    private Vector3 target;
    private float fadeOutSpeed = 2.0f;
    private bool isToPlayer;

    void Start()
    {
        rend = gameObject.GetComponent<SpriteRenderer>();
    }

	void FixedUpdate () {
        transform.position = Vector3.Lerp(transform.position, target, flySpeed * Time.fixedDeltaTime);

        if (!isToPlayer)
        {
            rend.color = Color.Lerp(rend.color, Color.clear, Time.fixedDeltaTime * fadeOutSpeed);
        }

        if(Vector3.Distance(transform.position, target) < 0.4f)
        {
            if (isToPlayer)
            {
                GameObject.Find("Player").GetComponent<PlayerManager>().IncrementCarbons();
            }
            Destroy(gameObject);
        }
	}

    public void setTarget(Transform target, bool isToPlayer)
    {
        this.target = target.position;
        this.isToPlayer = isToPlayer;
    }

    public void setTarget(Vector3 target, bool isToPlayer)
    {
        this.target = target;
        this.isToPlayer = isToPlayer;
    }
}
