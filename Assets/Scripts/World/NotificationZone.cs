using UnityEngine;
using System.Collections;

public class NotificationZone : MonoBehaviour {
    public string message;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag.Equals("Player"))
        {
            GameObject.FindObjectOfType<NoteDisplay>().Notify(message);
        }
    }

}
