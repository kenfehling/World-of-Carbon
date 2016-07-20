using UnityEngine;
using System.Collections;

public class TapHandler : MonoBehaviour {

    public float maxTapTime;

    private RaycastHit2D raycastHit;
    private float timer;

    void Update()
    {
        timer -= Time.deltaTime;
        if (Input.GetMouseButtonDown(0))
        {
            timer = maxTapTime;
        }

        if (Input.GetMouseButtonUp(0) && timer > 0.0f)
        {
            raycastHit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (raycastHit.collider != null)
            {
                Debug.Log(raycastHit.transform.gameObject);
            }
        }
    }
    
}
