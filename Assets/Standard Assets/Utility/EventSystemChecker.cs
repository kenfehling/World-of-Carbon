using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class EventSystemChecker : MonoBehaviour
{
    //public GameObject eventSystem;

	// Use this for initialization
	void Awake ()
	{
	    if(!FindObjectOfType<EventSystem>())
        {
           //Instantiate(eventSystem);
            GameObject obj = new GameObject("EventSystem");
            obj.AddComponent<EventSystem>();
            obj.AddComponent<StandaloneInputModule>().forceModuleActive = true;
            #pragma warning disable CS0618
            obj.AddComponent<TouchInputModule>();
            #pragma warning restore CS0618
        }
	}
}
