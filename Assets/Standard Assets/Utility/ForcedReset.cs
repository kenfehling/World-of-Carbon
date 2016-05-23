using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof (GUITexture))]
public class ForcedReset : MonoBehaviour
{
    private void Update()
    {
        // if we have forced a reset ...
        if (CrossPlatformInputManager.GetButtonDown("ResetObject"))
        {
            //... reload the scene
            #pragma warning disable CS0618
            Application.LoadLevelAsync(Application.loadedLevelName);
            #pragma warning restore CS0618
        }
    }
}
