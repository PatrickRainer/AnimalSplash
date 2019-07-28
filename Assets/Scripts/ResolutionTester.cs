using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolutionTester : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            // Switch to 640 x 480 full-screen
            Screen.SetResolution(640, 480, true);

            Debug.Log("Key 1 pressed");
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            // Switch to 640 x 480 full-screen at 60 hz
            Screen.SetResolution(640, 480, true, 60);

            Debug.Log("Key 2 pressed");
        }
    }

    private void OnGUI()
    {
        GUILayout.Label("Resolution Change Keys 1 - 9");
    }
}
