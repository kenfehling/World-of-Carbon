using UnityEngine;
using System.Collections;

public class DiamondFormer : MonoBehaviour {

    public int minimumCarbon = 30;

    private PlayerManager player;

    void OnTriggerEnter2D(Collider2D other)
    {
        OnTriggerStay2D(other);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.GetComponent<PlayerManager>())
        {
            if (!player)
            {
                player = other.GetComponent<PlayerManager>();
            }

            if(player.GetNumOfCarbons() > minimumCarbon)
            {
                //YOU WIN
            }
        }
    }
}
