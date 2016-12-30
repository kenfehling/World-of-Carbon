using UnityEngine;
using System.Collections;

public class Molecule : MonoBehaviour {

	// To be set by designer in object inspector of molecule prefabs
	public string formula;
    public string pressure = "";
    public string temperature = "";
    public bool wildMolecule = true;

    void Update()
    {
        if (wildMolecule)
        {
            transform.GetComponent<Rigidbody2D>().AddForce(Random.insideUnitCircle * 2.25f);
        }

    
    }

    void FixedUpdate()
    {
        transform.Rotate(new Vector3(0.0f, 0.0f, -20.0f) * Time.fixedDeltaTime);
    }

    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.tag.Equals("Player"))
        {
            Molecule player = obj.gameObject.GetComponentInChildren<Molecule>();
            PlayerManager pMan = obj.gameObject.GetComponent<PlayerManager>();
            if (player != null)
            {
                string combined = string.Concat(player.formula, formula);
                combined = string.Concat(combined, player.temperature);
                combined = string.Concat(combined, player.pressure);
                Debug.Log(combined);
                ReactionTable rt = GameObject.Find("GameManager").GetComponent<GameManager>().getReactionTable();

                

                if (rt.table[combined] != null)
                    Debug.Log(rt.table[combined]);
                //Lookup the combined string in the table;
                if (rt.table[combined] != null)
                {
                    Debug.Log("Reaction!");
                    Instantiate(Resources.Load(ResourcePaths.TransExplosion), transform.position, Quaternion.identity);

                    //Play combine sound
                    AudioSource aSrc = pMan.GetAudioSource();
                    SoundManager soundManager = GameObject.Find("GameManager").GetComponent<GameManager>().getSoundManager();
                    soundManager.playCombineSound(aSrc);

                    player.formula = rt.table[combined];

                    //Update the formula display
                    GameObject.Find("Formula Display").gameObject.GetComponent<CarbonDisplay>().setFormula(player.formula);
                    Destroy(this.gameObject);
                }
            }
        }
    }
}
