using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

[RequireComponent(typeof(LevelPrefs))]
public class Spawner : MonoBehaviour
{
    #region Members
    private LevelPrefs myLevelPrefs;
    private float remainingTime;
    #endregion

    private void Start()
    {
        myLevelPrefs = GetComponent<LevelPrefs>();
        remainingTime = myLevelPrefs.levelDuration;
    }

    /// <summary>
    /// Spawn one Prefab at a random position at the left end of the screen
    /// </summary>
    private void SpawnOnePrefab()
    {
        Vector3 pos = new Vector3();
        pos.x = 0; 
        pos.y = UnityEngine.Random.Range(50, Screen.height - 50);
        Vector3 wp = Camera.main.ScreenToWorldPoint(pos);
        wp.z = 0;

        Instantiate(myLevelPrefs.animalPrefab[UnityEngine.Random.Range(0, myLevelPrefs.animalPrefab.Length)], 
            wp, Quaternion.identity);
    }

    public void StartSpawning()
    {
        InvokeRepeating("SpawnOnePrefab", .2F, myLevelPrefs.spawningDelay);
    }

    public void StopSpawning()
    {
        // Cancel all Methods which has been started by invoke
        if (IsInvoking())
        {
            CancelInvoke();
        }
    }
    
}
