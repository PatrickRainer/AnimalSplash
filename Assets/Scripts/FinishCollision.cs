using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Finish Collision, is obsolete we will not use it anymore!
/// </summary>
public class FinishCollision : MonoBehaviour
{
    private void Start()
    {

        // Set up the position of the collider to the right end of the screen
        transform.position = Camera.main.ViewportToWorldPoint(new Vector3(1, 0.5F));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        AnimalBehaviour animal = collision.gameObject.GetComponent<AnimalBehaviour>();
        // Is an enemy walked into my trigger and was clicked on his way down?
        if (collision.gameObject.tag=="Enemy" && animal.isClicked)
        {
            // Destroy the GameObject of the animal with delay
            animal.DestroyMe();
        }
    }


}
