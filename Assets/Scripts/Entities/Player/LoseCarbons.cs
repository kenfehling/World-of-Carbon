using UnityEngine;
using System.Collections;

public class LoseCarbons : MonoBehaviour {

    public float invincibilityTime = 8.0f;

    private PlayerManager player;
    private float timer;

	void Start ()
    {
        player = gameObject.GetComponent<PlayerManager>();
	}

    void Update()
    {
        timer -= Time.deltaTime;
        if(timer > 0.0f)
        {
            GetComponentInChildren<SpriteRenderer>().material.color = Color.Lerp(Color.red, Color.white, Time.deltaTime/2);
        }

        if (timer < 0.0f)
        {
            GetComponentInChildren<SpriteRenderer>().material.color = Color.Lerp(Color.white, Color.red, Time.deltaTime / 2);
        }
    }
	
	void OnCollisionEnter2D(Collision2D col)
    {
        if(timer < 0.0f)
        {
            if (col.gameObject.CompareTag("Wall"))
            {
                if (player.GetNumOfCarbons() > 1)
                {
                    player.DecrementCarbons();
                    Vector3 randomDirection = new Vector3(Random.value, Random.value, Random.value);
                    GameObject lostCarbon = (GameObject)Instantiate(Resources.Load(ResourcePaths.FreeCarbonMolecule), transform.position, Quaternion.identity);
                    lostCarbon.GetComponent<FlyTo>().setTarget(transform.position + randomDirection * 2.5f, false);

                    timer = invincibilityTime;
                }
            }
        }
    }
}
