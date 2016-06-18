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
        cur = Color.Lerp(cur, Color.white, Time.deltaTime * 4.0f);
        rend.color = cur;
	}

    void OnEnable()
    {
        Debug.Log("Lerp In");
        cur = Color.clear;
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
