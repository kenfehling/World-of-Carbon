using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIHandler : MonoBehaviour {

    [SerializeField]
    private Image THUDImage;
    [SerializeField]
    private Text THUDTitle, THUDDescription;
    private UIFader THUDImageFader, THUDTitleFader, THUDDescriptionFader;

    void Start()
    {
        THUDImageFader = THUDImage.GetComponent<UIFader>();
        THUDTitleFader = THUDTitle.GetComponent<UIFader>();
        THUDDescriptionFader = THUDDescription.GetComponent<UIFader>();
    }

    public bool IsTHUDOpen()
    {
        return THUDImageFader.isVisible();
    }

    public void ActivateUIElement(string name)
    {
        if(name.Contains(" ("))
        {
            name = name.Split(' ', '(')[0];
        }

        ActivateTHUDElement(name);
    }

    public void DeactivateActiveUIElement()
    {
        if (THUDImageFader)
            THUDImageFader.BeginFadeOut();
        if (THUDTitleFader)
            THUDTitleFader.BeginFadeOut();
        if(THUDDescriptionFader)
            THUDDescriptionFader.BeginFadeOut();
    }

    private void ActivateTHUDElement(string name)
    {
        bool found = false;
        Image tempImg = null;
        Text tempTitle = null, tempDescription = null;

        if (name == "Player")
        {
            found = true;
            CarbonDisplay cd = GameObject.FindObjectOfType<CarbonDisplay>().GetComponent<CarbonDisplay>();
            cd.setFormula("");
            tempImg = ((GameObject)Instantiate(Resources.Load(ResourcePaths.PlayerTHUDImage))).GetComponent<Image>();
            tempTitle = ((GameObject)Instantiate(Resources.Load(ResourcePaths.PlayerTHUDTitle))).GetComponent<Text>();
            tempDescription = ((GameObject)Instantiate(Resources.Load(ResourcePaths.PlayerTHUDDescription))).GetComponent<Text>();
        }

        else if (name == "RedMolecule")
        {
            found = true;
            tempImg = ((GameObject)Instantiate(Resources.Load(ResourcePaths.RedMolTHUDImage))).GetComponent<Image>();
            tempTitle = ((GameObject)Instantiate(Resources.Load(ResourcePaths.RedMolTHUDTitle))).GetComponent<Text>();
            tempDescription = ((GameObject)Instantiate(Resources.Load(ResourcePaths.RedMolTHUDDescription))).GetComponent<Text>();
        }

        else if (name == "BlueMolecule")
        {
            found = true;
            tempImg = ((GameObject)Instantiate(Resources.Load(ResourcePaths.BlueMolTHUDImage))).GetComponent<Image>();
            tempTitle = ((GameObject)Instantiate(Resources.Load(ResourcePaths.BlueMolTHUDTitle))).GetComponent<Text>();
            tempDescription = ((GameObject)Instantiate(Resources.Load(ResourcePaths.BlueMolTHUDDescription))).GetComponent<Text>();
        }

        else if (name == "YelMolecule")
        {
            found = true;
            tempImg = ((GameObject)Instantiate(Resources.Load(ResourcePaths.YelMolTHUDImage))).GetComponent<Image>();
            tempTitle = ((GameObject)Instantiate(Resources.Load(ResourcePaths.YelMolTHUDTitle))).GetComponent<Text>();
            tempDescription = ((GameObject)Instantiate(Resources.Load(ResourcePaths.YelMolTHUDDescription))).GetComponent<Text>();
        }

        else if (name == "CO2")
        {
            found = true;
            tempImg = ((GameObject)Instantiate(Resources.Load(ResourcePaths.CO2THUDImage))).GetComponent<Image>();
            tempTitle = ((GameObject)Instantiate(Resources.Load(ResourcePaths.CO2THUDTitle))).GetComponent<Text>();
            tempDescription = ((GameObject)Instantiate(Resources.Load(ResourcePaths.CO2THUDDescription))).GetComponent<Text>();
        }

        else if (name == "O2" || name == "Oxide")
        {
            found = true;
            tempImg = ((GameObject)Instantiate(Resources.Load(ResourcePaths.OxideTHUDImage))).GetComponent<Image>();
            tempTitle = ((GameObject)Instantiate(Resources.Load(ResourcePaths.OxideTHUDTitle))).GetComponent<Text>();
            tempDescription = ((GameObject)Instantiate(Resources.Load(ResourcePaths.OxideTHUDDescription))).GetComponent<Text>();
        }

        else if (name == "H2O")
        {
            found = true;
            tempImg = ((GameObject)Instantiate(Resources.Load(ResourcePaths.H2OTHUDImage))).GetComponent<Image>();
            tempTitle = ((GameObject)Instantiate(Resources.Load(ResourcePaths.H2OTHUDTitle))).GetComponent<Text>();
            tempDescription = ((GameObject)Instantiate(Resources.Load(ResourcePaths.H2OTHUDDescription))).GetComponent<Text>();
        }

        else if (name == "SO")
        {
            found = true;
            tempImg = ((GameObject)Instantiate(Resources.Load(ResourcePaths.SOTHUDImage))).GetComponent<Image>();
            tempTitle = ((GameObject)Instantiate(Resources.Load(ResourcePaths.SOTHUDTitle))).GetComponent<Text>();
            tempDescription = ((GameObject)Instantiate(Resources.Load(ResourcePaths.SOTHUDDescription))).GetComponent<Text>();
        }

        else if (name == "H+")
        {
            found = true;
            tempImg = ((GameObject)Instantiate(Resources.Load(ResourcePaths.HPlusTHUDImage))).GetComponent<Image>();
            tempTitle = ((GameObject)Instantiate(Resources.Load(ResourcePaths.HPlusTHUDTitle))).GetComponent<Text>();
            tempDescription = ((GameObject)Instantiate(Resources.Load(ResourcePaths.HPlusTHUDDescription))).GetComponent<Text>();
        }

        else if (name == "CAO")
        {
            found = true;
            tempImg = ((GameObject)Instantiate(Resources.Load(ResourcePaths.CAOTHUDImage))).GetComponent<Image>();
            tempTitle = ((GameObject)Instantiate(Resources.Load(ResourcePaths.CAOTHUDTitle))).GetComponent<Text>();
            tempDescription = ((GameObject)Instantiate(Resources.Load(ResourcePaths.CAOTHUDDescription))).GetComponent<Text>();
        }

        else if (name == "NO3-")
        {
            found = true;
            tempImg = ((GameObject)Instantiate(Resources.Load(ResourcePaths.NO3MinusTHUDImage))).GetComponent<Image>();
            tempTitle = ((GameObject)Instantiate(Resources.Load(ResourcePaths.NO3MinusTHUDTitle))).GetComponent<Text>();
            tempDescription = ((GameObject)Instantiate(Resources.Load(ResourcePaths.NO3MinusTHUDDescription))).GetComponent<Text>();
        }

        else if (name == "HCO3-")
        {
            found = true;
            tempImg = ((GameObject)Instantiate(Resources.Load(ResourcePaths.HCO3MinusTHUDImage))).GetComponent<Image>();
            tempTitle = ((GameObject)Instantiate(Resources.Load(ResourcePaths.HCO3MinusTHUDTitle))).GetComponent<Text>();
            tempDescription = ((GameObject)Instantiate(Resources.Load(ResourcePaths.HCO3MinusTHUDDescription))).GetComponent<Text>();
        }

        else if (name == "CA2+")
        {
            found = true;
            tempImg = ((GameObject)Instantiate(Resources.Load(ResourcePaths.Ca2PlusTHUDImage))).GetComponent<Image>();
            tempTitle = ((GameObject)Instantiate(Resources.Load(ResourcePaths.Ca2PlusTHUDTitle))).GetComponent<Text>();
            tempDescription = ((GameObject)Instantiate(Resources.Load(ResourcePaths.Ca2PlusTHUDDescription))).GetComponent<Text>();
        }

        else if (name == "MG2+")
        {
            found = true;
            tempImg = ((GameObject)Instantiate(Resources.Load(ResourcePaths.Mg2PlusTHUDImage))).GetComponent<Image>();
            tempTitle = ((GameObject)Instantiate(Resources.Load(ResourcePaths.Mg2PlusTHUDTitle))).GetComponent<Text>();
            tempDescription = ((GameObject)Instantiate(Resources.Load(ResourcePaths.Mg2PlusTHUDDescription))).GetComponent<Text>();
        }


        if (found)
        {
            THUDImageFader.SetSprite(tempImg.sprite);
            THUDTitle.text = tempTitle.text;
            THUDDescription.text = tempDescription.text;

            Destroy(tempImg.gameObject);
            Destroy(tempTitle.gameObject);
            Destroy(tempDescription.gameObject);

            THUDImageFader.BeginFadeIn();
            THUDTitleFader.BeginFadeIn();
            THUDDescriptionFader.BeginFadeIn();
        }
    }
}
