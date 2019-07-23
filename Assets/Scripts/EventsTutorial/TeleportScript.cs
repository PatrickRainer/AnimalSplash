using UnityEngine;
using System.Collections;

public class TeleportScript : MonoBehaviour
{
    void OnEnable()
    {
        // Assigns the method to the event
        EventManager.OnClicked += Teleport;
    }


    void OnDisable()
    {
        // Unsubscribe the method from the event
        EventManager.OnClicked -= Teleport;
    }


    void Teleport()
    {
        Vector3 pos = transform.position;
        pos.y = Random.Range(1.0f, 3.0f);
        transform.position = pos;
    }
}