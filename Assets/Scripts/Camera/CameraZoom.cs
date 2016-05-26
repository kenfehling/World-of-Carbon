using UnityEngine;
using System.Collections;

public class CameraZoom : MonoBehaviour {

    public float maxDistance = 1.0f;
    public float minDistance = 4.0f;

    private Camera cam;
    private float scrollWheelAxis;

    void Start()
    {
        cam = gameObject.GetComponent<Camera>();
    }

    void Update()
    {
        //This can be changed to some mobile-specific control later
        scrollWheelAxis = Input.GetAxis("Mouse ScrollWheel");
        if (scrollWheelAxis > 0)
        {
            if(cam.orthographicSize <= minDistance)
            {
                cam.orthographicSize = minDistance;
            }
            else
            {
                cam.orthographicSize -= 0.1f;
            }   
        }
        else if (scrollWheelAxis < 0)
        {
            if(cam.orthographicSize >= maxDistance)
            {
                cam.orthographicSize = maxDistance;
            }
            else
            {
                cam.orthographicSize += 0.1f;
            }   
        }
    }
}
