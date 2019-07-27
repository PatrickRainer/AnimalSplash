using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishCollision : MonoBehaviour
{
    // GameController from the Scene
    public GameObject gameController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        AnimalBehaviour animal = collision.gameObject.GetComponent<AnimalBehaviour>();
        // Is an enemy walked into my trigger and was clicked on his way down?
        if (collision.gameObject.tag=="Enemy" && animal.hasClicked)
        {
            //... then count Point up
            gameController.GetComponent<GUIController>().CurrentPoints++;

            // Destroy the GameObject of the animal with delay
            animal.DestroyMe();
        }
    }


}
