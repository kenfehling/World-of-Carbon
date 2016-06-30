using UnityEngine;
using System.Collections;

public class PressureZone : MonoBehaviour {

    private PlayerManager player;
    public uint nextLayer;
    public int carbonsNeeded;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

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

                if(nextLayer == 3)
                {
                    player.BecomeDiamond();
                }
                GameManager.art.SwitchLayer(nextLayer);
                GameManager.music.moveDownLayer();
            }
        }
    }
}
