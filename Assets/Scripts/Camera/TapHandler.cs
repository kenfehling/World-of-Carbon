using UnityEngine;
using System.Collections;

public class TapHandler : MonoBehaviour {

    [HideInInspector]public static bool playerTapped;
    public float maxTapTime;

    private RaycastHit2D raycastHit;
    private float timer;

    void Update()
    {
        timer -= Time.deltaTime;

        if (Input.GetMouseButtonDown(0))
        {
            raycastHit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (raycastHit.collider != null)
            {
                Debug.Log(raycastHit.transform.gameObject.name);
                if (raycastHit.transform.gameObject.name == "Player")
                {
                    playerTapped = true;
                }
            }
            timer = maxTapTime;
        }
        else if (Input.GetMouseButtonUp(0) && timer > 0.0f)
        {
            if (raycastHit.collider != null)
            {
                Debug.Log(raycastHit.transform.gameObject + " tapped!");
            }
        }
        else if(timer <= 0.0f)
        {
            playerTapped = false;
        }
    }
    
    void OnMouseUp()
    {
        playerTapped = false;
    }
}
