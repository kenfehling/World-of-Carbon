using UnityEngine;
using System.Collections;

public class LayerManager : MonoBehaviour {

    public bool DebugControls = true;
    public uint currentLayerNumber = 0;
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
            if(nextLayer > currentLayerNumber)
            {
                DescendLayer(nextLayer);
            }
            else
            {
                AscendLayer(nextLayer);
            }
            currentLayerNumber = nextLayer;
        }
    }

    private void AscendLayer(uint nextLayer)
    {
        FaderScript fader;
        foreach (Transform child in currentLayer.transform)
        {
            fader = child.GetComponent<FaderScript>();
            if (fader)
            {
                fader.BeginFadeOut(false);
            }
            else
            {
                if (child.gameObject.name == "Entities")
                {
                    foreach (Transform grandChild in child)
                    {
                        fader = grandChild.GetComponent<FaderScript>();
                        if (fader)
                        {
                            fader.BeginFadeOut(false);
                        }
                    }
                }
                else
                {
                    child.gameObject.SetActive(false);
                }
            }
        }

        currentLayer = layers[nextLayer];
        currentLayer.SetActive(true);
        foreach (Transform child in currentLayer.transform)
        {
            child.gameObject.SetActive(true);
            fader = child.gameObject.GetComponent<FaderScript>();

            if (fader)
            {
                fader.SetDescending(false);
            }

            if (child.gameObject.name == "Entities")
            {
                foreach (Transform grandchild in child)
                {
                    grandchild.gameObject.SetActive(true);
                    fader = grandchild.gameObject.GetComponent<FaderScript>();
                    fader.SetDescending(false);
                }
            }
        }
    }

    private void DescendLayer(uint nextLayer)
    {
        FaderScript fader;
        foreach (Transform child in currentLayer.transform)
        {
            fader = child.GetComponent<FaderScript>();
            if (fader)
            {
                fader.BeginFadeOut(true);
            }
            else
            {
                if (child.gameObject.name == "Entities")
                {
                    foreach (Transform grandChild in child)
                    {
                        fader = grandChild.GetComponent<FaderScript>();
                        if (fader)
                        {
                            fader.BeginFadeOut(true);
                        }
                    }
                }
                else
                {
                    child.gameObject.SetActive(false);
                }
            }
        }

        currentLayer = layers[nextLayer];
        currentLayer.SetActive(true);
        foreach (Transform child in currentLayer.transform)
        {
            child.gameObject.SetActive(true);
            if (child.gameObject.name == "Entities")
            {
                foreach (Transform grandchild in child)
                {
                    grandchild.gameObject.SetActive(true);
                }
            }
        }
    }

    public uint GetCurrentLayer()
    {
        return currentLayerNumber;
    }
}
