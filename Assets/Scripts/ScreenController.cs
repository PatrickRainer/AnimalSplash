using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The class controls all around the screen, like orientation, resolution, etc.
/// </summary>
public class ScreenController : MonoBehaviour
{
    void Start()
    {
        SetLandscapeOrientation();
    }

    private void SetLandscapeOrientation()
    {
        // Does prevent from AutoRotation
        Screen.autorotateToPortraitUpsideDown = false;
        Screen.orientation = ScreenOrientation.Landscape;
    }

}
