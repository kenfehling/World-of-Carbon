using UnityEngine;
using System.Collections;

public class LayerManager : MonoBehaviour {

    public GameObject[] layers = new GameObject[3];
    private GameObject currentLayer;
	// Use this for initialization
	void Start () {
        currentLayer = layers[0];

        if(layers[1])
            layers[1].SetActive(false);

        if(layers[2])
            layers[2].SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetKey(KeyCode.A))
        {
            SwitchLayer(0);
        }

        if(Input.GetKey(KeyCode.B))
        {
            SwitchLayer(1);
        }
	}

    // Switches the active layer.
    public void SwitchLayer(uint nextLayer)
    {
        switch(nextLayer)
        {
            case 0:
                layers[0].SetActive(true);
                layers[1].SetActive(false);
                if (layers[2])
                    layers[2].SetActive(false);
                break;

            case 1:
                layers[0].SetActive(false);
                layers[1].SetActive(true);
                if (layers[2])
                    layers[2].SetActive(false);
                break;

            case 2:
                layers[0].SetActive(false);
                layers[1].SetActive(false);
                if (layers[2])
                    layers[2].SetActive(true);
                break;
        }
        currentLayer = layers[nextLayer];

        
    }
}
