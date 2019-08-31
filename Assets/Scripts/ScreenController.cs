using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The class controls all around the screen, like orientation, resolution, etc.
/// </summary>
public class ScreenController : MonoBehaviour
{
    void Awake()
    {
        SetLandscapeOrientation();
    }

    private void SetLandscapeOrientation()
    {
        // Prevent from going to Portrait mode
        Screen.autorotateToLandscapeLeft = true;
        Screen.autorotateToLandscapeRight = true;
        Screen.autorotateToPortrait = false;
        Screen.autorotateToPortraitUpsideDown = false;
    }

}
