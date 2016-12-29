using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CarbonDisplay : MonoBehaviour {

    private Text text;
    private string displayText;
    private int numOfCarbons;
    private string currentFormula;

    public float stayTime = 8.0f;
    public float fadeoutTimer;

    public Color fadeColor;
    //TODO: CHANGE TO FORMULA
	// Use this for initialization
	void Start () {
        text = gameObject.GetComponent<Text>();
        fadeColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        fadeoutTimer = stayTime;

        displayText = "Formula: ";
        numOfCarbons = 1;
        currentFormula = "";
        updateDisplay();

	}

    void Update()
    {
        if(fadeoutTimer > 0.0f)
        {
            fadeoutTimer -= Time.deltaTime;
            fadeColor.a -= 0.25f* Time.deltaTime;
            
        }
        text.material.color = fadeColor;

    }

    private void updateDisplay()
    {
        text.text = displayText + currentFormula;
    }
	
	public void setNumOfCarbons(int numOfCarbons)
    {
        this.numOfCarbons = numOfCarbons;
        updateDisplay();
    }

    public void setFormula(string formula)
    {
        if(formula.Contains("Mantle"))
        {
            formula = formula.Substring(5);
        }

        if (formula.Contains("Water"))
        {
            formula = formula.Substring(4);
        }

        currentFormula = formula;
        fadeoutTimer = stayTime;
        fadeColor = Color.white;
        updateDisplay();
    }
}
