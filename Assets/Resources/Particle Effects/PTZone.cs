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
            zoneColor.b += 0.5f;

        if (temperature == "Mt")
            zoneColor.g += 0.5f;

        if (temperature == "Ht")
            zoneColor.r += 0.5f;
        ps.startColor = zoneColor;
	}
	
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.GetComponent<PlayerManager>() != null)
        {
            Molecule pmol = other.gameObject.GetComponentInChildren<Molecule>();
            pmol.pressure = pressure;
            pmol.temperature = temperature;
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
