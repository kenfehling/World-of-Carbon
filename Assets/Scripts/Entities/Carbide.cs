using UnityEngine;
using System.Collections;

public class Carbide : MonoBehaviour {

    private GameObject product;
    private PlayerManager player;

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

                //Destroy the carbide
                Destroy(gameObject);
            }   
        }
    }
}
