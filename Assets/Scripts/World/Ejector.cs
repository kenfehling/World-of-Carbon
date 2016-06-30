using UnityEngine;
using System.Collections;

public class Ejector : MonoBehaviour {

    public int minimumCarbons;
    private bool ejected = false;
    private PlayerManager player;

    void OnEnable()
    {
        ejected = false;
    }
	void FixedUpdate () {
        if (!player)
        {
            player = GameObject.Find("Player").GetComponent<PlayerManager>();
        }

        if(player.GetNumOfCarbons() < minimumCarbons)
        {
            if (!ejected)
            {
                GameObject.Find("GameManager").gameObject.GetComponent<LayerManager>().SwitchLayer(GameObject.Find("GameManager").gameObject.GetComponent<LayerManager>().GetCurrentLayer() - 1);
                ejected = true;
                GameObject.Find("GameManager").gameObject.GetComponent<GameManager>().getMusicManager().moveUpLayer();
            }
        }
	}
}
