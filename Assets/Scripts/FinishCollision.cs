using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Finish Collision, is obsolete we will not use it anymore!
/// </summary>
public class FinishCollision : MonoBehaviour
{
    // Gui Controller
    public GUIController myGuiController;

    private void Start()
    {
        myGuiController = GameObject.Find("GuiController").GetComponent<GUIController>();

        // Set up the position of the collider to the right end of the screen
        transform.position = Camera.main.ViewportToWorldPoint(new Vector3(1, 0.5F));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        AnimalBehaviour animal = collision.gameObject.GetComponent<AnimalBehaviour>();
        // Is an enemy walked into my trigger and was clicked on his way down?
        if (collision.gameObject.tag=="Enemy" && animal.hasClicked)
        {
            //... then count Point up // Obsolete we do it in the onClicked of AnimalBeahaviour
            //myGuiController.GetComponent<GUIController>().CurrentPoints++;

            // Destroy the GameObject of the animal with delay
            animal.DestroyMe();
        }
    }


}
