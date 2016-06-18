using UnityEngine;
using System.Collections;

public class Oxide : MonoBehaviour
{
    PlayerManager player;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerManager>())
        {
            if (!player)
            {
                player = other.GetComponent<PlayerManager>();
                ParticleSystem ps = player.GetComponentInChildren<ParticleSystem>();
                ps.Play();
            }
            player.IncrementOxides();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<PlayerManager>())
        {
            player.DecrementOxides();
        }
    }

}
