using UnityEngine;
using System.Collections;

public class FaderScript : MonoBehaviour {
    SpriteRenderer rend;
    Color tar;
    Color cur;
	// Use this for initialization
	void Start () {
        rend = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        rend.color = Color.Lerp(rend.color, Color.white, Time.deltaTime * 4.0f);
	}

    void OnEnable()
    {
        Debug.Log("Lerp In");
        rend.color = Color.clear;
        tar = Color.white;
        Debug.Log(transform.localScale);
        
    }

    void OnDisable()
    {
        Debug.Log("Lerp Out");
        rend.color = Color.white;
        tar = Color.clear;

    }
}
