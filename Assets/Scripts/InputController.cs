using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    // Can I check inputs?
    bool doInputChecking = true;

    private void Update()
    {
        // Does Touch on the screen?
        if (Input.touchCount > 0)
        {
            // Is the 1. Input beginning, the check the position
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                CheckInput(Input.GetTouch(0).position);
            }
        }

        // Is no touch pressed, is the left Mouse Button pressed?
        if (Input.GetMouseButtonDown(0))
        {
            //Check the Mouse Position
            CheckInput(Input.mousePosition);
        }

    }

    // Check Input Position
    void CheckInput(Vector3 pos)
    {
        // Can I check Inputs?
        if (doInputChecking)
        {
            // Transform the Input-Position of the screen into a world-Position
            // in the scene
            Vector3 wp = Camera.main.ScreenToWorldPoint(pos);

            // Convert the Vector2 Type
            Vector2 touchPos = new Vector2(wp.x, wp.y);

            // Is the 2D-Position on a collider?
            Collider2D otherCol = Physics2D.OverlapPoint(touchPos);

            // If there is a Collider
            if (otherCol)
            {
                // Is it an enemy?
                if (otherCol.gameObject.CompareTag("Enemy"))
                {
                    /// Obsolete /// 
                    // ... then destroy it
                    //otherCol.transform.gameObject.SendMessage("KillMe", 0, SendMessageOptions.DontRequireReceiver);
                    /// End Obsolete ///

                    // Make it Faster
                    GameObject animal = otherCol.gameObject;
                    animal.SendMessage("OnClicked", SendMessageOptions.DontRequireReceiver);
                }
            }


         
        }
    }

    /// <summary>
    /// End the analizing of Touch or Mouse inputs
    /// </summary>
    public void StopInputChecking()
    {
    doInputChecking = false;
    }

    /// <summary>
    /// Resumes or starts the analizing of Touch or Mouse inputs
    /// </summary>
    public void ResumeInputChecking()
    {
        doInputChecking = true;
    }

}
