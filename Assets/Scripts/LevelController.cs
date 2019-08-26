using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Timers;

[RequireComponent(typeof(Spawner))]
[RequireComponent(typeof(LevelPrefs))]
[RequireComponent(typeof(LevelTimer))]
[RequireComponent(typeof(InputController))]
/// <summary>
/// Controls the Level with the Main Function like Start, End, Pause
/// </summary>
public class LevelController : MonoBehaviour
{
    #region SingletonPattern
    private static LevelController _instance;
    public static LevelController Instance { get { return _instance; } }

    private void Awake()
    {
        _instance = this;
    }
    #endregion
    #region Members
    private Spawner mySpawner;
    private LevelPrefs myLevelPrefs;
    private float currentTimeScale;
    private LevelTimer myTimer;
    private InputController myInputController;
    private EventManager myEventManager;
    #endregion

    #region Events
    //public delegate void LevelEnds();
    //public event LevelEnds OnLevelEnds;
    //public delegate void LevelPauses();
    //public event LevelPauses OnLevelPauses;
    //public delegate void LevelPlays();
    //public event LevelPlays OnLevelPlays;
    //public delegate void LevelStatusChanged();
    //public event LevelStatusChanged OnLevelStatusChanged;
    #endregion

    #region Initializing
    private void Start()
    {
        Time.timeScale = 1;
        mySpawner = GetComponent<Spawner>();
        myLevelPrefs = GetComponent<LevelPrefs>();
        myTimer = GetComponent<LevelTimer>();
        myInputController = GetComponent<InputController>();
        myEventManager = GameObject.FindObjectOfType<EventManager>();
        myEventManager.OnLevelEnds.AddListener(EndLevel);
        StartSpawning();
    }
    #endregion

    #region General Methods
    private void StartSpawning()
    {
        mySpawner.StartSpawning();
        
        myTimer.StartTimer(myLevelPrefs.levelDuration);
        myTimer.OnTimerEnds += MyTimer_OnTimerEnds;
    }

    private void MyTimer_OnTimerEnds()
    {
        myEventManager.OnLevelEnds.Invoke();
    }

    public void EndLevel()
    {
        mySpawner.StopSpawning();
        Time.timeScale = 0;
        myInputController.StopInputChecking();
    }
    public void PauseLevel()
    {
        // TempSave the TimeScale
        currentTimeScale = Time.timeScale;
        // Set Time Scale to 0 pauses everything
        Time.timeScale = 0;
        // Stopp the Touch and Mouse input reading
        GetComponent<InputController>().StopInputChecking();
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);   
    }
    /// <summary>
    /// Resumes the Game usually from the Pause Menu
    /// </summary>
    public void ResumeLevel()
    {
        GetComponent<InputController>().ResumeInputChecking();
        Time.timeScale = currentTimeScale;
        myEventManager.OnLevelPlays.Invoke();
    }
    #endregion
}

