using UnityEngine;
using System.Collections;

public class LayerManager : MonoBehaviour {

    public bool DebugControls = true;
    public uint lnum = 0;
    public GameObject[] layers = new GameObject[3];
    private GameObject currentLayer;

	// Use this for initialization
	void Start () {
        currentLayer = layers[0];

        currentLayer.SetActive(true);

        for(int i=1; i<layers.Length; i++)
        {
            layers[i].SetActive(false);
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (DebugControls)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                SwitchLayer(0);
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                SwitchLayer(1);
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                SwitchLayer(2);
            }
        }
	}

    // Switches the active layer.
    public void SwitchLayer(uint nextLayer)
    {
        if(currentLayer != layers[nextLayer] && !currentLayer.transform.GetChild(0).GetComponent<FaderScript>().isFading()
            && !layers[nextLayer].transform.GetChild(0).GetComponent<FaderScript>().isFading())
        {
            FaderScript fader;
            foreach (Transform child in currentLayer.transform)
            {
                fader = child.GetComponent<FaderScript>();
                if (fader)
                {
                    fader.BeginFadeOut();
                }
            }

            currentLayer = layers[nextLayer];
            currentLayer.SetActive(true);
            foreach (Transform child in currentLayer.transform)
            {
                child.gameObject.SetActive(true);
            }
        }
    }
}
