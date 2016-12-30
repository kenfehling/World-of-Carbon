using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TransitionFade : MonoBehaviour {

    private Image overlay;
    private bool fading = false;
    public Color targetColor;
    public float fadeInSpeed;
    private Color currentColor;
    private static int nextLevel;
    private bool loaded = false;
	// Use this for initialization
	void Start () {
        loaded = false;
        fading = false;
        overlay = GetComponent<Image>();
        currentColor = overlay.color;
	}
	
	// Update is called once per frame
	void Update () {
	    if(fading)
        {
            currentColor = Color.Lerp(currentColor, targetColor, Time.deltaTime * fadeInSpeed);
            overlay.color = currentColor;
        }

        if(currentColor == targetColor && !loaded)
        {
            loaded = true;
            SceneManager.LoadScene(nextLevel);

        }

	}

    public void StartFade(int next)
    {
        nextLevel = next;
        fading = true;
    }

}
