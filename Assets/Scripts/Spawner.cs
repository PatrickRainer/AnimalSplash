using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    // Text Object for the level-label
    public Text levelText;

    // Array for the ghosts
    public GameObject[] prefs;

    // Time of a ghost-wave, or level
    public float intervalLength = 10;

    // Current creating-delay
    float currentSpawnDelay = 1.0F;

    // Playing width
    float width;

    // Playing height
    float height;

    // Current Level
    int levelCounter = 0;

    private void Start()
    {
        // Display width
        width = Screen.width;
        // Display height
        height = Screen.height;

        // Start the first Wave
        StartSpawnInterval();
    }

    void Spawn()
    {
        levelText.text = "";
        Vector3 pos = new Vector3();
        pos.x = UnityEngine.Random.Range(50, width - 50);
        pos.y = height + 70;
        Vector3 wp = Camera.main.ScreenToWorldPoint(pos);
        wp.z = 0;

        Instantiate(prefs[UnityEngine.Random.Range(0, prefs.Length)], wp, Quaternion.identity);
    }
    private void StartSpawnInterval()
    {
        // count Level upwards
        levelCounter++;

        // Show Level-Text
        levelText.text = "Level " + levelCounter.ToString();

        // Start in 3 seconds and create ghosts with delay
        InvokeRepeating("Spawn",3, currentSpawnDelay);

        // Stopp the wave
        Invoke("IntervalBreak", intervalLength);
    }

    void IntervalBreak()
    {
        // Cancel Spawn
        CancelInvoke("Spawn");

        // Start the next wave in 3 sec.
        Invoke("StartSpawnInterval", 3);

        // if the delay is bigger than 0.2 sec
        if (currentSpawnDelay>0.2F)
        {
            // then reduce the Delay for 0.05 sec
            currentSpawnDelay -= 0.05F;
        }
    }

    void StopSpawning()
    {
        // Cancel all Mehtods which has been started by invoke
        CancelInvoke();
    }
}
