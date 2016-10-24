using UnityEngine;
using System.Collections;

public class FaderScript : MonoBehaviour {
    [SerializeField]
    private Vector3 finalScale = new Vector3(1.0f, 1.0f, 1.0f);

    private SpriteRenderer rend;
    private Color targetColor;
    private Color currentColor;
    private Vector3 two = new Vector3(2.0f, 2.0f, 2.0f);
    private float fadeInSpeed = 1.5f;
    private bool fadingIn;
    private bool fadingOut;

    void Start () {
        rend = GetComponent<SpriteRenderer>();

	}
	
	void Update () {
        if (fadingIn)
        {
            if (rend)
            {
                currentColor = Color.Lerp(currentColor, targetColor, Time.deltaTime * fadeInSpeed);
                rend.color = currentColor;
            }

            if (gameObject.GetComponent<Collider2D>() != null)
                gameObject.GetComponent<Collider2D>().enabled = true;
            
            transform.localScale = Vector3.Lerp(transform.localScale, finalScale, Time.deltaTime * fadeInSpeed);

            if(transform.localScale.x > 0.998f)
            {
                

                if (rend)
                {
                    currentColor = targetColor;
                    rend.color = currentColor;
                }
                transform.localScale = finalScale;
                fadingIn = false;
            }
        }

        if (fadingOut)
        {
            if (rend)
            {
                currentColor = Color.Lerp(currentColor, targetColor, Time.deltaTime * fadeInSpeed);
                rend.color = currentColor;
            }

            transform.localScale = Vector3.Lerp(transform.localScale, two, Time.deltaTime * fadeInSpeed);
            if (transform.localScale.x > 1.998f)
            {
                if (rend)
                {
                    currentColor = targetColor;
                    rend.color = currentColor;
                }
                transform.localScale = Vector3.zero;

                fadingOut = false;
                gameObject.SetActive(false);
            }
        }
	}

    void OnEnable()
    {
        currentColor = Color.clear;
        targetColor = Color.white;

        transform.localScale = Vector3.zero;
        fadingIn = true;
    }

    public void BeginFadeOut()
    {
        if (gameObject.GetComponent<Collider2D>() != null)
            gameObject.GetComponent<Collider2D>().enabled = false;

        rend.color = Color.white;
        targetColor = Color.clear;
        fadingOut = true;
    }

    public bool isFading()
    {
        return fadingOut || fadingIn;
    }
}
