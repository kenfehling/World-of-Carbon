using UnityEngine;
using System.Collections;

public class NotificationZone : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag.Equals("Player"))
        {
            GameObject.Find("Notification").gameObject.GetComponent<CarbonDisplay>().Notify();
        }
    }

}
