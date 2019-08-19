using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Holds the Preferences for this specific Level
/// </summary>
public class LevelPrefs : MonoBehaviour
{
    #region SingletonPattern
    private static LevelPrefs _instance;
    public static LevelPrefs Instance { get { return _instance; } }

    private void Awake()
    {
        _instance = this;
    }
    #endregion

    public GameObject[] animalPrefab;
    public float levelDuration;
    public float spawningDelay;

}
