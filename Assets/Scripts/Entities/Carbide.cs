using UnityEngine;
using System.Collections;

public class Carbide : MonoBehaviour {

    public float delay = 0.1f;
    public int carbonYield = 5;

    private GameObject product;
    private PlayerManager player;
    private float timer;
    private bool exploding;

    void Start()
    {
        timer = delay;
    }

    void FixedUpdate()
    {
        if (exploding)
        {
            timer -= Time.fixedDeltaTime;
            if (timer < 0.0f)
            {
                timer = delay;
                --carbonYield;

                //Spawn the explosion particle effect
                Instantiate(Resources.Load(ResourcePaths.transExplosion), transform.position, Quaternion.identity);

                //Spawn a lone carbon and send it flying to the player
                product = (GameObject)Instantiate(Resources.Load(ResourcePaths.FreeCarbonMolecule), transform.position, Quaternion.identity);
                product.GetComponent<FlyTo>().setTarget(player.transform);

                //Spawn other products and send them flying in a random direction

                //Play combine sound
                AudioSource aSrc = player.GetAudioSource();
                SoundManager soundManager = GameObject.Find("GameManager").GetComponent<GameManager>().getSoundManager();
                soundManager.playCombineSound(aSrc);

                player.GetCloud().IncNumOfCarbons();
                if (carbonYield == 0)
                {
                    //Destroy the carbide
                    Destroy(gameObject);
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerManager>())
        {
            OnTriggerStay2D(other);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.GetComponent<PlayerManager>())
        {
            if (!player)
            {
                player = other.GetComponent<PlayerManager>();
            }

            if (player.IsOxidePresent())
            {
                exploding = true;
            }   
        }
    }
}
