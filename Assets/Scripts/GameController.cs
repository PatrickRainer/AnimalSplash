using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameController : MonoBehaviour
{
    #region SingletonPattern
    private static GameController _instance;
    public static GameController Instance { get { return _instance; } }

    private void Awake()
    {
        _instance = this;
    }
    #endregion

    //public GameController gameController;
    public Camera mainCam;
    public GameObject pauseMenu;
    public GameObject myGameOverlay;
    public Spawner mySpawner;
    public enum SceneStatus { Playing, Paused, Ended }
    public SceneStatus sceneStatus;
    public GUIController myGui;
    public InputController myInputController;

    // To temporary save the TimeScale
    private float tempTimeScale;
    

    #region Events

    #endregion

    private void Start()
    {
        mainCam = Camera.main;
        pauseMenu = GameObject.Find("PauseMenu");
        myGameOverlay = GameObject.Find("GameOverlay");
        mySpawner = GetComponent<Spawner>();
        myGui = GameObject.Find("GuiController").GetComponent<GUIController>();
        LoadHighscore(); // TODO: Take these Variables out from the GUIController class in to to stats or a sub Class of this
        myInputController = GetComponent<InputController>();

        // Does prevent from 
        Screen.autorotateToPortraitUpsideDown = false;
        Screen.orientation = ScreenOrientation.Landscape;

        // Start the Level
        StartLevel(1);  // TODO: The Level index must come from somewhere else

    }

    /// <summary>
    /// Start Scene
    /// </summary>
    /// <param name="level">Build Index of the scene</param>
    public void StartLevel(int level)
    {
        // TODO: Issue: Goes into a loop?! Because its in the start Method of this
        // ... script and we are still in that level?
        if (SceneManager.GetActiveScene().buildIndex !=level)
        {
            SceneManager.LoadScene(level);
        }
        
        mySpawner.StartSpawnInterval(mySpawner.startIntervalLength);
        // Set Scene-Status
        sceneStatus = SceneStatus.Playing;
    }

    /// <summary>
    /// Start Scene
    /// </summary>
    /// <param name="levelName">Scene Name</param>
    public void StartLevel(string levelName)
    {
        // TODO: Issue: Goes into a loop?!
        if (SceneManager.GetActiveScene().name != levelName)
        {
            SceneManager.LoadScene(levelName);
        }
        mySpawner.StartSpawnInterval(mySpawner.startIntervalLength);
        // Set Scene-Status
        sceneStatus = SceneStatus.Playing;
    }

    /// <summary>
    /// Restarts the current level
    /// </summary>
    public void RestartLevel()
    {
        mySpawner.StopAllCoroutines();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = tempTimeScale;
        // Set Scene-Status
        sceneStatus = SceneStatus.Playing;
    }

    /// <summary>
    /// Ends the Level
    /// </summary>
    public void EndLevel()
    {
        // Pause the Game
        PauseGame();
        // Show PauseMenu
        myGui.ShowPauseMenu();
        // Disable the resume Button
        myGui.DisableResumeButton();
        // Scene Status
        sceneStatus = SceneStatus.Ended;
    }

    /// <summary>
    /// Pauses the Game, and goes into the Pause Menu
    /// </summary>
    public void PauseGame()
    {
        // TempSave the TimeScale
        tempTimeScale = Time.timeScale;
        // Set Time Scale to 0
        Time.timeScale = 0;
        // Show the GameMenu
        myGui.ShowPauseMenu();  // TODO: Test
        // Stopp the Touch and Mouse input reading
        myInputController.StopInputChecking();
        // Set Scene-Status
        sceneStatus = SceneStatus.Paused;
        // Save Highscore if new is made
        SaveHighscore();
    }

    /// <summary>
    /// Resumes the Game usually from the Pause Menu
    /// </summary>
    public void ResumeGame()
    {
        // Hides the Highscore Menu
        myGui.HidePauseMenu();
        // Reloads the  temporary Saved TimeScale
        Time.timeScale = tempTimeScale;
        // Resumes the Touch and Mouse input reading
        myInputController.ResumeInputChecking();
         sceneStatus = SceneStatus.Playing;
    }

    /// <summary>
    /// Quits the Game
    /// </summary>
    public void QuitGame()
    {
        // TODO: Add WebPlayer, Android and Iphone Quit. Example is here: https://answers.unity.com/questions/161858/startstop-playmode-from-editor-script.html
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }

    /// <summary>
    /// Saves the Highscore if there is a new one made
    /// </summary>
    public void SaveHighscore()
    {
        if (myGui.CurrentPoints > myGui.beginningHs)
        {
            // Then write a new highscore.
            PlayerPrefs.SetInt("Highscore", myGui.CurrentPoints);

            // Save PlayerPrefs
            PlayerPrefs.Save();
        }
    }

    /// <summary>
    /// Loads the Highscore from PlayerPrefs into the GuiController class
    /// </summary>
    public void LoadHighscore()
    {
        // Is there already a Highscore?
        if (PlayerPrefs.HasKey("Highscore"))
        {
            myGui.beginningHs = PlayerPrefs.GetInt("Highscore");
        }
    }

    //TODO: SavePlayerInfo
    public void SavePlayerInfo()
    {

    }

    //TODO: LoadPlayerInfo
    public void LoadPlayerInfo()
    {

    }

    // TODO: NewPlayer
    public void NewPlayer()
    {

    }

    // TODO: DeletePlayer
    public void DeletePlayer()
    {

    }

    // TODO: ShowPlayerStats
    public void ShowPlayerStats()
    {

    }

}