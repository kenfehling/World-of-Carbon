
using UnityEngine;
using System.Collections;

public class ColorTracker : MonoBehaviour {

    public static ColorTracker _instance = null;
	
    public static ColorTracker Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = GameObject.FindObjectOfType<ColorTracker>();

                if(_instance == null)
                {
                    GameObject container = new GameObject("ColorTracker");
                    _instance = container.AddComponent<ColorTracker>();

                }
            }

            return _instance;
        }
        
    }

    private static string color = "BW";


	
	void Awake () {
        Debug.Log(this.GetInstanceID());
	}

    void Update()
    {
        Debug.Log(color);
    }
    public static void SetMolColor(string t_color)
    {
        color = t_color;
    }

    public static void ApplyColor(FormManager fMan)
    {
        fMan.color = color;
    }
}
