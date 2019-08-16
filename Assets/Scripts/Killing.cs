using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killing : MonoBehaviour
{
    // The Game Controller
    GUIController guicontroller;

    Moving moving;
    
    // Killing Audio
    [Tooltip("Playing Sound, as soon the ghost is killed")]
    public AudioClip clip;
    
    // The own Animator
    Animator anim;
    
    // Am I dead?
    bool isDead = false;

    private void Start()
    {
        // Get Animator to member
        anim = GetComponent<Animator>();

        // Get Moving
        moving = GetComponent<Moving>();

        // Get the Gui Controller
        guicontroller = GameObject.FindGameObjectWithTag("GuiManager").GetComponent<GUIController>();

    }

    void KillMe()
    {
        // If I am not already Dead
        if (!isDead)
        {
            // call my stopMoving Methode and stop me
            SendMessage("StopMoving");

            // Call the Trigger "Dead" of the Animatior
            anim.SetTrigger("Dead");

            // Play the AudioClip at my Position
            AudioSource.PlayClipAtPoint(clip, transform.position);

            // Destroy me after 0.4 sec
            Destroy(gameObject, 0.4F);

            // Save my Position temporary
            Vector3 pos = transform.position;

            // Push my position backwards
            pos.z = 5;

            // Set new Postion, so that other objects lay over this
            transform.position = pos;

            // Count Points
            guicontroller.CurrentPoints++;

            // Yes, I am Dead to true
            isDead = true;

        }
    }
}
