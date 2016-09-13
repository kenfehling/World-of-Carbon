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
            tempImg = ((GameObject)Instantiate(Resources.Load(ResourcePaths.PlayerTHUDImage))).GetComponent<Image>();
            tempTitle = ((GameObject)Instantiate(Resources.Load(ResourcePaths.PlayerTHUDTitle))).GetComponent<Text>();
            tempDescription = ((GameObject)Instantiate(Resources.Load(ResourcePaths.PlayerTHUDDescription))).GetComponent<Text>();
        }
        else if(name == "CO2")
        {
            found = true;
            tempImg = ((GameObject)Instantiate(Resources.Load(ResourcePaths.CO2THUDImage))).GetComponent<Image>();
            tempTitle = ((GameObject)Instantiate(Resources.Load(ResourcePaths.CO2THUDTitle))).GetComponent<Text>();
            tempDescription = ((GameObject)Instantiate(Resources.Load(ResourcePaths.CO2THUDDescription))).GetComponent<Text>();
        }
        else if(name == "Oxide")
        {
            found = true;
            tempImg = ((GameObject)Instantiate(Resources.Load(ResourcePaths.OxideTHUDImage))).GetComponent<Image>();
            tempTitle = ((GameObject)Instantiate(Resources.Load(ResourcePaths.OxideTHUDTitle))).GetComponent<Text>();
            tempDescription = ((GameObject)Instantiate(Resources.Load(ResourcePaths.OxideTHUDDescription))).GetComponent<Text>();
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
