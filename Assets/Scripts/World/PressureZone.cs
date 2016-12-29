using UnityEngine;
using System.Collections;

public class PressureZone : MonoBehaviour {

    private PlayerManager player;
    public uint nextLayer;
    public string formulaNeeded;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Player"))
        {
            player = other.gameObject.GetComponent<PlayerManager>();
            Molecule pmol = other.gameObject.GetComponentInChildren<Molecule>();
            Debug.Log(pmol.formula);
            if(pmol.formula == formulaNeeded)
            {
                    player.gameObject.GetComponent<HoldInPlace>().enabled = true;
                    player.gameObject.GetComponent<FlyTo>().setTarget(transform.position);
                    player.gameObject.GetComponent<FlyTo>().enabled = true;
                    GameManager.music.moveDownLayer();
                    GameManager.art.SwitchLayer(nextLayer);
                    
            }
        }
    }
}
