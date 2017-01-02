using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TutorialActivator : MonoBehaviour {
    public UIHandler uitarget;
    public Image window;
    public Text title;
    public Text desc;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag.Equals("Player"))
        {
            other.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            other.enabled = true;
            if (!uitarget.IsTHUDOpen())
            {
                uitarget.ActivateAll(window, title, desc);

                Destroy(this.gameObject);
                other.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            }
        }
    }
}
