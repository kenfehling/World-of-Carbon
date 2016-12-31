using UnityEngine;
using System.Collections;

public class Tracker : MonoBehaviour {
    [SerializeField]
    public static uint layerTransfer = 0;

    [SerializeField]
    public static bool mustJump = false;
	// Use this for initialization
	void Start () 
    {
        DontDestroyOnLoad(this.gameObject);
	}
	
	public static void SetTransferLayer(uint target)
    {
        layerTransfer = target;
        mustJump = true;
    }

    public static void JumpToTransfer()
    {
        GameManager.art.SwitchLayer(layerTransfer);
        mustJump = false;
    }

    public static bool MustJump()
    {
        return mustJump;
    }
}
