using UnityEngine;
using System.Collections;

public class PTZone : MonoBehaviour {
    public string pressure = "";
    public string temperature = "";

    private ParticleSystem ps;

    //Lt = Low Temp = 1, Mt = Med Temp = 4, Ht = Hi Temp = 7
    //Lp = Low Pres = 2, Mp = Med Pres = 5, Hp = Hi Pres = 8

	// Use this for initialization
	void Start () {
        ps = GetComponentInChildren<ParticleSystem>();
        Color zoneColor = new Color(0, 0, 0, 0.5f);
        //Zone Color will be based off the Temp and Pressure set.
        if (pressure == "Lp")
            zoneColor.b += 0.5f;

        if (pressure == "Mp")
            zoneColor.g += 0.5f;

        if (pressure == "Hp")
            zoneColor.r += 0.5f;

        if (temperature == "Lt")
        {
            ps.startLifetime = 5.0f;
            ps.startSpeed = 0.5f;
            ParticleSystem.MinMaxCurve rate = ps.emission.rate;
            rate.mode = ParticleSystemCurveMode.Constant;
            rate.constantMax = 50.0f;
            rate.constantMin = 50.0f;
        }

        if (temperature == "Mt")
        {
            ps.startLifetime = 2.0f;
            ps.startSpeed = 2.0f;
            ParticleSystem.MinMaxCurve rate = ps.emission.rate;
            rate.mode = ParticleSystemCurveMode.Constant;
            rate.constantMax = 50.0f;
            rate.constantMin = 50.0f;
        }

        if (temperature == "Ht")
       {
            ps.startLifetime = 0.7f;
            ps.startSpeed = 6.0f;
            ParticleSystem.MinMaxCurve rate = ps.emission.rate;
            rate.mode = ParticleSystemCurveMode.Constant;
            rate.constantMax = 50.0f;
            rate.constantMin = 50.0f;
        }
        ps.startColor = zoneColor;
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
                Instantiate(Resources.Load(ResourcePaths.TransExplosion), transform.position, Quaternion.identity);

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
