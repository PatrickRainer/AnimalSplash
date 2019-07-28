using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishCollision : MonoBehaviour
{
    // Gui Controller
    public GUIController myGuiController;

    private void Start()
    {
        myGuiController = GameObject.Find("GuiController").GetComponent<GUIController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        AnimalBehaviour animal = collision.gameObject.GetComponent<AnimalBehaviour>();
        // Is an enemy walked into my trigger and was clicked on his way down?
        if (collision.gameObject.tag=="Enemy" && animal.hasClicked)
        {
            //... then count Point up
            myGuiController.GetComponent<GUIController>().CurrentPoints++;

            // Destroy the GameObject of the animal with delay
            animal.DestroyMe();
        }
    }


}
