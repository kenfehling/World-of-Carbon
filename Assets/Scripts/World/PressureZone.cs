using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class PressureZone : MonoBehaviour {

    private PlayerManager player;
    public uint nextLayer;
    public int nextLevel;
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

                    if(nextLayer != 3)
                        GameManager.art.SwitchLayer(nextLayer);
                    
                    else
                    {
                        SceneManager.LoadScene(nextLevel);
                    }

            }
        }
    }
}
