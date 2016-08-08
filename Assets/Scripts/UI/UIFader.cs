using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIFader : MonoBehaviour {

    public float fadeTime = 1.0f;

    private Image image;
    private RectTransform rectTransform;
    private Vector2 size;
    private float timer;
    private State state;

    private enum State {fadingIn, fadingOut, visible, idle};

	// Use this for initialization
	void Start () {
        image = GetComponent<Image>();
        rectTransform = GetComponent<RectTransform>();
        image.SetNativeSize();
        size = rectTransform.sizeDelta;
        timer = fadeTime;
        state = State.idle;
        rectTransform.sizeDelta = Vector2.zero;
    }

    void Awake()
    {
        Start();
        BeginFadeIn();
    }
	
	// Update is called once per frame
	void Update () {
	    if(state == State.fadingIn)
        {
            //Declare the lerp backwards because of shrinking timer
            rectTransform.sizeDelta = Vector2.Lerp(size, rectTransform.sizeDelta, Mathf.Clamp(timer, 0.0f, 1.0f));
        }
        else if(state == State.fadingOut)
        {
            rectTransform.sizeDelta = Vector2.Lerp(Vector2.zero, rectTransform.sizeDelta, Mathf.Clamp(timer, 0.0f, 1.0f));
        }

        if(timer <= 0.0f && (state == State.fadingIn || state == State.fadingOut))
        {
            if(state == State.fadingIn)
            {
                state = State.visible;
            }
            else
            {
                state = State.idle;
            }
        }

        timer -= Time.deltaTime;
	}

    public void BeginFadeOut()
    {
        if(timer <= 0.75f && state != State.idle && state != State.fadingOut)
        {
            rectTransform.sizeDelta = size;
            state = State.fadingOut;
            timer = fadeTime;
        }        
    }

    public void BeginFadeIn()
    {
        rectTransform.sizeDelta = Vector2.zero;
        state = State.fadingIn;
        timer = fadeTime;
    }

    public void SetSprite(Sprite sprite)
    {
        image.sprite = sprite;
        image.SetNativeSize();
        size = sprite.bounds.size * sprite.pixelsPerUnit;
    }
}
