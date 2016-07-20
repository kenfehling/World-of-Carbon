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
        GetComponentInChildren<SpriteRenderer>().material.color = Color.Lerp(Color.white, Color.red, timer / invincibilityTime);
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
                    lostCarbon.GetComponent<FlyToPlayer>().setTarget(transform.position + randomDirection * 2.5f, false);

                    timer = invincibilityTime;
                }
            }
        }
    }
}
