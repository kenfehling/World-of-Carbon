using UnityEngine;
using System.Collections;

public class CarbonHolding : MonoBehaviour {

    PlayerManager player;

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
                player.IncrementCarbons();
                Destroy(gameObject);
            }   
        }
    }
}
