using UnityEngine;
using UnityEngine.Events;
using System.Collections.ObjectModel;

[RequireComponent(typeof(LevelPrefs))]
public class Spawner : MonoBehaviour
{
    #region Members
    private LevelPrefs myLevelPrefs;
    private float remainingTime;
    public ObservableCollection<GameObject> spawnedAnimals=
        new ObservableCollection<GameObject>();
    #endregion

    private void Awake()
    {
        myLevelPrefs = GameObject.Find("LevelPref").GetComponent<LevelPrefs>();
        remainingTime = myLevelPrefs.levelDuration;
    }
    private void Start()
    {
    
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

        // Instantiate the AnimalPrefab and add it to the SpawnedAnimalsCollection
        spawnedAnimals.Add(Instantiate(myLevelPrefs.animalPrefab[UnityEngine.Random.Range(0, myLevelPrefs.animalPrefab.Length)], 
            wp, Quaternion.identity));
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
