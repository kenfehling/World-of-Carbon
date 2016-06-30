using UnityEngine;
using System.Collections;

public class Ejector : MonoBehaviour {

    public int minimumCarbons;

    private PlayerManager player;

	void FixedUpdate () {
        if (!player)
        {
            GameObject.Find("Player");
        }

        if(player.GetNumOfCarbons() < minimumCarbons)
        {
            GameObject.Find("GameManager").gameObject.GetComponent<LayerManager>().SwitchLayer(GameObject.Find("GameManager").gameObject.GetComponent<LayerManager>().GetCurrentLayer() - 1);
        }
	}
}
