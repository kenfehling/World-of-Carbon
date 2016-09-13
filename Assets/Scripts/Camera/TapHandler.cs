using UnityEngine;
using System.Collections;

public class TapHandler : MonoBehaviour {

    [HideInInspector]public static bool playerTapped;
    public float maxTapTime;

    private UIHandler ui;
    private RaycastHit2D raycastHit;
    private float timer;

    void Start()
    {
        ui = FindObjectOfType<UIHandler>();
    }

    void Update()
    {
        if(timer > 0.0f)
            timer -= Time.deltaTime;

        if (Input.GetMouseButtonDown(0))
        {
            raycastHit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (raycastHit.collider != null)
            {
                if (raycastHit.transform.gameObject.name == "Player")
                {
                    playerTapped = true;
                }
            }
            timer = maxTapTime;
        }
        else if (Input.GetMouseButtonUp(0) && timer > 0.0f)
        {
            if (raycastHit.collider != null && !ui.IsTHUDOpen())
            {
                ui.ActivateUIElement(raycastHit.transform.gameObject.name);
                playerTapped = false;
            }
            else
            {
                ui.DeactivateActiveUIElement();
            }
        }

        if (timer <= 0.0f && Input.GetMouseButtonUp(0))
        {
            ui.DeactivateActiveUIElement();
            playerTapped = false;
        }        
    }
    
    void OnMouseUp()
    {
        playerTapped = false;
    }
}
