using UnityEngine;
using System.Collections;

public class PressureZone : MonoBehaviour {

    private PlayerManager player;
    public uint nextLayer;
    public int carbonsNeeded;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerManager>())
        {
            if (!player)
            {
                player = other.GetComponent<PlayerManager>();
            }

            if(player.GetNumOfCarbons() >= carbonsNeeded)
            {

                if (nextLayer == 3)
                {
                    player.BecomeDiamond();
                }
                else
                {
                    player.GetComponent<HoldInPlace>().enabled = true;
                    player.GetComponent<FlyTo>().setTarget(transform.position);
                    player.GetComponent<FlyTo>().enabled = true;
                    GameManager.art.SwitchLayer(nextLayer);
                    GameManager.music.moveDownLayer();
                }
            }
        }
    }
}
