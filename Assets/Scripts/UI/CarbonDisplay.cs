using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CarbonDisplay : MonoBehaviour {

    private Text text;
    private string displayText;
    private int numOfCarbons;
    private string currentFormula;
    
    public string targetFormulaText;
    public float stayTime = 8.0f;
    public float fadeoutTimer;

    public Color fadeColor;

    public bool notification;

	// Use this for initialization
	void Start () {
        text = gameObject.GetComponent<Text>();
        fadeColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        fadeoutTimer = stayTime;

        currentFormula = GameObject.FindObjectOfType<PlayerManager>().gameObject.GetComponentInChildren<Molecule>().formula;
        if (currentFormula.Contains("Mantle"))
        {
            currentFormula = currentFormula.Substring(6);
        }

        if (currentFormula.Contains("Water"))
        {
            currentFormula = currentFormula.Substring(5);
        }

        numOfCarbons = 1;

        if(!notification)
            updateDisplay();

	}

    void Update()
    {
        if(fadeoutTimer > 0.0f)
        {
            fadeoutTimer -= Time.deltaTime;
            fadeColor.a -= 0.15f* Time.deltaTime;
            
        }
        text.material.color = fadeColor;

    }

    private void updateDisplay()
    {
        if (!notification)
            text.text = "Formula: " + currentFormula;

        else
            text.text = targetFormulaText;

    }
	
	public void setNumOfCarbons(int numOfCarbons)
    {
        this.numOfCarbons = numOfCarbons;
        updateDisplay();
    }
    
    public void Notify(string note)
    {
        currentFormula = note;
        updateDisplay();
    }

    public void setFormula(string formula)
    {
        if (formula == "")
        {
            formula = currentFormula;
        }

        else
        {
            if (formula.Contains("Mantle"))
            {
                formula = formula.Substring(6);
            }

            if (formula.Contains("Water"))
            {
                formula = formula.Substring(5);
            }
        }

        currentFormula = formula;
        fadeoutTimer = stayTime;
        fadeColor = Color.white;
        updateDisplay();
    }
}
