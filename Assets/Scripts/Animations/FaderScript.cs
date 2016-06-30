using UnityEngine;
using System.Collections;

public class FaderScript : MonoBehaviour {

    private SpriteRenderer rend;
    private Color targetColor;
    private Color currentColor;
    private Vector3 two = new Vector3(2.0f, 2.0f, 2.0f);
    private float fadeInSpeed = 4.0f;
    private bool descending;
    private bool fadingIn;
    private bool fadingOut;

    void Start () {
        rend = GetComponent<SpriteRenderer>();
	}
	
	void Update () {
        if (descending)
        {
            DescendUpdate();
        }
        else
        {
            AscendUpdate();
        }
	}

    void OnEnable()
    {
        currentColor = Color.clear;
        targetColor = Color.white;

        transform.localScale = Vector3.zero;
        fadingIn = true;
    }

    private void AscendUpdate()
    {
        if (fadingIn)
        {
            if (rend)
            {
                currentColor = Color.Lerp(currentColor, targetColor, Time.deltaTime * fadeInSpeed);
                rend.color = currentColor;
            }

            transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one, Time.deltaTime * fadeInSpeed);

            if (transform.localScale.x > 0.989f)
            {
                gameObject.GetComponent<Collider2D>().enabled = true;

                if (rend)
                {
                    currentColor = targetColor;
                    rend.color = currentColor;
                }
                transform.localScale = Vector3.one;
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

            transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero, Time.deltaTime * fadeInSpeed);
            if (transform.localScale.x > 1.989f)
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

    private void DescendUpdate()
    {
        if (fadingIn)
        {
            if (rend)
            {
                currentColor = Color.Lerp(currentColor, targetColor, Time.deltaTime * fadeInSpeed);
                rend.color = currentColor;
            }

            transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one, Time.deltaTime * fadeInSpeed);

            if (transform.localScale.x > 0.989f)
            {
                gameObject.GetComponent<Collider2D>().enabled = true;

                if (rend)
                {
                    currentColor = targetColor;
                    rend.color = currentColor;
                }
                transform.localScale = Vector3.one;
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
            if (transform.localScale.x > 1.989f)
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

    public void BeginFadeOut(bool descending)
    {
        gameObject.GetComponent<Collider2D>().enabled = false;

        rend.color = Color.white;
        targetColor = Color.clear;
        fadingOut = true;
        this.descending = descending;
    }

    public bool isFading()
    {
        return fadingOut || fadingIn;
    }

    public void SetDescending(bool descending)
    {
        this.descending = descending;
        if (!descending && fadingIn)
        {
            transform.localScale = two;
        }
    }
}
