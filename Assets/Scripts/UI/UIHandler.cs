using UnityEngine;
using System.Collections;

public class UIHandler : MonoBehaviour {

    [SerializeField]
    private Sprite[] UIElements;
    private UIFader activeTHUD;

    void Start()
    {
        activeTHUD = FindObjectOfType<UIFader>();
    }

    public void ActivateUIElement(string name)
    {
        if(name.Contains(" ("))
        {
            name = name.Split(' ', '(')[0];
        }
                
        foreach (Sprite i in UIElements)
        {
            if (i.name == name)
            {
                activeTHUD.gameObject.SetActive(true);
                activeTHUD.SetSprite(i);
                activeTHUD.BeginFadeIn();
                return;
            }
        }
    }

    public void DeactivateActiveUIElement()
    {
        if (activeTHUD)
        {
            activeTHUD.BeginFadeOut();
        }
    }
}
