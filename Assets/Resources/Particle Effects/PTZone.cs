using UnityEngine;
using System.Collections;

public class PTZone : MonoBehaviour {
    public string pressure = "";
    public string temperature = "";

    //Lt = Low Temp = 1, Mt = Med Temp = 4, Ht = Hi Temp = 7
    //Lp = Low Pres = 2, Mp = Med Pres = 5, Hp = Hi Pres = 8

	// Use this for initialization
	void Start () {
       
        
        if (temperature == "Lt")
        {
            foreach(Transform child in transform)
            {

                Animator anim = child.gameObject.GetComponent<Animator>();
                anim.speed = 0.5f;
                
            }
        }

        if (temperature == "Mt")
        {
            foreach (Transform child in transform)
            {

                Animator anim = child.gameObject.GetComponent<Animator>();
                anim.speed = 1.0f;

            }
        }

        if (temperature == "Ht")
        {
            foreach (Transform child in transform)
            {

                Animator anim = child.gameObject.GetComponent<Animator>();
                anim.speed = 3.0f;

            }
        }


	}
	
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.GetComponent<PlayerManager>() != null)
        {
            Molecule pmol = other.gameObject.GetComponentInChildren<Molecule>();
            pmol.pressure = pressure;
            pmol.temperature = temperature;

            string combined = string.Concat(pmol.formula, string.Concat(temperature, pressure));

            ReactionTable rt = GameObject.Find("GameManager").GetComponent<GameManager>().getReactionTable();
            //Lookup the combined string in the table;
            if (rt.table[combined] != null)
            {
                Debug.Log("Reaction!");
                Instantiate(Resources.Load(ResourcePaths.TransExplosion), other.transform.position, Quaternion.identity);

                //Play combine sound
                AudioSource aSrc = other.gameObject.GetComponent<PlayerManager>().GetAudioSource();
                SoundManager soundManager = GameObject.Find("GameManager").GetComponent<GameManager>().getSoundManager();
                soundManager.playCombineSound(aSrc);

                pmol.formula = rt.table[combined];

                //Update the formula display
                GameObject.Find("Formula Display").gameObject.GetComponent<CarbonDisplay>().setFormula(pmol.formula);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PlayerManager>() != null)
        {
            Molecule pmol = other.gameObject.GetComponentInChildren<Molecule>();
            pmol.pressure = "";
            pmol.temperature = "";
        }
    }
}
