using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;
public class FormManager : MonoBehaviour {
    [SerializeField]
    private Sprite[] carbonForms = new Sprite[5];
    [SerializeField]
    private RuntimeAnimatorController[] carbonAnimations = new RuntimeAnimatorController[5];

    [SerializeField]
    private Sprite[] redcarbonForms = new Sprite[5];
    [SerializeField]
    private RuntimeAnimatorController[] redcarbonAnimations = new RuntimeAnimatorController[5];

    [SerializeField]
    private Sprite[] bluecarbonForms = new Sprite[5];
    [SerializeField]
    private RuntimeAnimatorController[] bluecarbonAnimations = new RuntimeAnimatorController[5];

    [SerializeField]
    private Sprite[] bwcarbonForms = new Sprite[5];
    [SerializeField]
    private RuntimeAnimatorController[] bwcarbonAnimations = new RuntimeAnimatorController[5];

    public string color = "Yellow";

    private SpriteRenderer moleculeSprite;
    private Animator moleculeAnimator;

    private Sprite[] primarySprite;
    private RuntimeAnimatorController[] primaryAC;

    private Molecule pMol;
    private string currentForm;


	// Use this for initialization
	void Start () {
        pMol = GetComponentInChildren<Molecule>();

        currentForm = pMol.formula;
        
        moleculeSprite = GetComponentInChildren<SpriteRenderer>();
        moleculeAnimator = GetComponentInChildren<Animator>();

        ColorTracker.ApplyColor(this);
        switch(color)
        {
            case "BW":
                primarySprite = bwcarbonForms;
                primaryAC = bwcarbonAnimations;
                break;

            case "Red":
                primarySprite = redcarbonForms;
                primaryAC = redcarbonAnimations;
                break;

            case "Blue":
                primarySprite = bluecarbonForms;
                primaryAC = bluecarbonAnimations;
                break;

            case "Yellow":
                primarySprite = carbonForms;
                primaryAC = carbonAnimations;
                break;

        }
	}
	
	// Update is called once per frame
	void Update () {
        currentForm = pMol.formula;
        switch (color)
        {
            case "BW":
                primarySprite = bwcarbonForms;
                primaryAC = bwcarbonAnimations;
                break;

            case "Red":
                primarySprite = redcarbonForms;
                primaryAC = redcarbonAnimations;
                break;

            case "Blue":
                primarySprite = bluecarbonForms;
                primaryAC = bluecarbonAnimations;
                break;

            case "Yellow":
                primarySprite = carbonForms;
                primaryAC = carbonAnimations;
                break;

        }

        if(currentForm == "CaCO3" || currentForm == "MantleCaCO3")
        {
            currentForm = "CO3";
        }

        currentForm = currentForm.Substring(currentForm.IndexOf("C"));
        Debug.Log(currentForm);
        if(currentForm == "C")
        {
            moleculeSprite.sprite = primarySprite[0];
            moleculeAnimator.runtimeAnimatorController = primaryAC[0];
        }

        else if (currentForm == "CO2")
        {
            moleculeSprite.sprite = primarySprite[1];
            moleculeAnimator.runtimeAnimatorController = primaryAC[1];

        }

        else if (currentForm == "CO3")
        {
            moleculeSprite.sprite = primarySprite[2];
            moleculeAnimator.runtimeAnimatorController = primaryAC[2];

        }

        else if (currentForm == "CGraphite")
        {
            moleculeSprite.sprite = primarySprite[3];
            moleculeAnimator.runtimeAnimatorController = primaryAC[3];

        }

        else if (currentForm == "CDiamond")
        {
            moleculeSprite.sprite = primarySprite[4];
            moleculeAnimator.runtimeAnimatorController = primaryAC[4];
        }
	}
}
