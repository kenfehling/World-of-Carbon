using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;
public class FormManager : MonoBehaviour {
    [SerializeField]
    private Sprite[] carbonForms = new Sprite[5];

    private SpriteRenderer moleculeSprite;
    private Molecule pMol;
    private string currentForm;


	// Use this for initialization
	void Start () {
        pMol = GetComponentInChildren<Molecule>();

        currentForm = pMol.formula;
        moleculeSprite = GetComponentInChildren<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        currentForm = pMol.formula;

        Match m;
        if((m = Regex.Match(currentForm, "^C$")).Success)
        {
            Debug.Log("You are C");
            moleculeSprite.sprite = carbonForms[0];
        }

        else if ((m = Regex.Match(currentForm, "^CO2$")).Success)
        {
            Debug.Log("You are CO2");
            moleculeSprite.sprite = carbonForms[1];

        }

        else if ((m = Regex.Match(currentForm, "^CO3$")).Success)
        {
            Debug.Log("You are CO3");
            moleculeSprite.sprite = carbonForms[2];

        }

        else if ((m = Regex.Match(currentForm, "^CDiamond$")).Success)
        {
            Debug.Log("You are Diamond!");
            moleculeSprite.sprite = carbonForms[3];

        }
	}
}
