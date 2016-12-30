using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {

    private GameObject child;
    private SoundManager soundManager;
    private AudioSource source;
    private ReactionTableEntry.Pressure pressure;
    private ReactionTableEntry.Temperature temperature;
    public string startFormula;
    private int numOfOxides;
    private int numOfCarbons;
    private Color carbonTint;

    void Start()
    {
        //Stores reference to default child, destroys the child's rigidbody
        if (!child)
        {
            child = transform.GetChild(0).gameObject;
            Destroy(child.GetComponent<Rigidbody2D>());
        }

        source = gameObject.AddComponent<AudioSource>();
        source.loop = false;

        pressure = ReactionTableEntry.Pressure.lo;
        temperature = ReactionTableEntry.Temperature.lo;
        Debug.Log(GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Molecule>());
        startFormula = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Molecule>().formula;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            IncrementCarbons();
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        try
        {
            soundManager.playClackSound(source);
        }
        catch
        {
            soundManager = GameObject.Find("GameManager").GetComponent<GameManager>().getSoundManager();
            soundManager.playClackSound(source);
        }
    }

    public void SetChild(GameObject child)
    {
        //Do any bookkeeping required by the old molecule here, since it's being replaced
        //Destroy the old child
        Destroy(this.child);
        //Remove Rigidbody2D from new child
        Destroy(child.GetComponent<Rigidbody2D>());
        //Store the reference to the new child
        this.child = child;
    }

    public string GetFormula()
    {
        return startFormula;
    }

    public bool IsOxidePresent()
    {
        return numOfOxides > 0 ? true : false;
    }

    public ReactionTableEntry.Temperature GetTemperature()
    {
        return temperature;
    }

    public void SetTemperature(ReactionTableEntry.Temperature temperature)
    {
        this.temperature = temperature;
    }

    public ReactionTableEntry.Pressure GetPressure()
    {
        return pressure;
    }

    public void SetPressure(ReactionTableEntry.Pressure pressure)
    {
        this.pressure = pressure;
    }

    public void IncrementOxides()
    {
        ++numOfOxides;
    }

    public void DecrementOxides()
    {
        --numOfOxides;
    }

    public void IncrementCarbons()
    {
        ++numOfCarbons;
        GameObject.Find("Carbon Display").GetComponent<CarbonDisplay>().setNumOfCarbons(numOfCarbons);
    }

    public void DecrementCarbons()
    {
        --numOfCarbons;
        GameObject.Find("Carbon Display").GetComponent<CarbonDisplay>().setNumOfCarbons(numOfCarbons);
    }

    public int GetNumOfCarbons()
    {
        return numOfCarbons;
    }

    public AudioSource GetAudioSource()
    {
        return source;
    }

    public void BecomeDiamond()
    {
        SpriteRenderer sRend = GetComponentInChildren<SpriteRenderer>();
        Sprite diamond = Resources.Load<Sprite>(ResourcePaths.DiamondMol);
        sRend.sprite = diamond;
    }

    public void ChangeTint(Color tint)
    {
        SpriteRenderer sRend = GetComponentInChildren<SpriteRenderer>();
        sRend.material.color = tint;
    }
}
