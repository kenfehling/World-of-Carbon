using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;
public class FormManager : MonoBehaviour {
    [SerializeField]
    private Sprite[] carbonForms = new Sprite[5];
    [SerializeField]
    private RuntimeAnimatorController[] carbonAnimations = new RuntimeAnimatorController[5];


    private SpriteRenderer moleculeSprite;
    private Animator moleculeAnimator;
    private Molecule pMol;
    private string currentForm;


	// Use this for initialization
	void Start () {
        pMol = GetComponentInChildren<Molecule>();

        currentForm = pMol.formula;
        moleculeSprite = GetComponentInChildren<SpriteRenderer>();
        moleculeAnimator = GetComponentInChildren<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        currentForm = pMol.formula;

        if(currentForm == "CaCO3" || currentForm == "MantleCaCO3")
        {
            currentForm = "CO3";
        }

        currentForm = currentForm.Substring(currentForm.IndexOf("C"));
        Debug.Log(currentForm);
        if(currentForm == "C")
        {
            moleculeSprite.sprite = carbonForms[0];
            moleculeAnimator.runtimeAnimatorController = carbonAnimations[0];
        }

        else if (currentForm == "CO2")
        {
            moleculeSprite.sprite = carbonForms[1];
            moleculeAnimator.runtimeAnimatorController = carbonAnimations[1];

        }

        else if (currentForm == "CO3")
        {
            moleculeSprite.sprite = carbonForms[2];
            moleculeAnimator.runtimeAnimatorController = carbonAnimations[2];

        }

        else if (currentForm == "CGraphite")
        {
            moleculeSprite.sprite = carbonForms[3];
            moleculeAnimator.runtimeAnimatorController = carbonAnimations[3];

        }

        else if (currentForm == "CDiamond")
        {
            moleculeSprite.sprite = carbonForms[4];
            moleculeAnimator.runtimeAnimatorController = carbonAnimations[4];
        }
	}
}
