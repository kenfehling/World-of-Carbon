using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NoteDisplay : MonoBehaviour {
    private Text text;
    private string displayText;
    public string message;

    public float stayTime = 8.0f;
    public float fadeoutTimer;

    public Color fadeColor;

	// Use this for initialization
	void Start () {
        text = gameObject.GetComponent<Text>();
        fadeColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        fadeoutTimer = stayTime;
	}
	
	// Update is called once per frame
	void Update () {
        if (fadeoutTimer > 0.0f)
        {
            fadeoutTimer -= Time.deltaTime;
            fadeColor.a -= 0.15f * Time.deltaTime;

        }
        text.material.color = fadeColor;
	}


    public void Notify(string note)
    {
        message = note;
        fadeoutTimer = stayTime;
        fadeColor = Color.white;
        updateDisplay();
    }


    private void updateDisplay()
    {
        text.text = message;
    }
}
