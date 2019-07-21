using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public GameController gameController;
    public Camera mainCam;
    public GameObject pauseMenu;
    public GameObject inGameGui;
    public Spawner mySpawner;
    public enum SceneStatus { Playing, Paused }
    public SceneStatus sceneStatus;
    public GUIController myGui;
    // To temporary save the TimeScale
    private float tempTimeScale;


    private void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").
            GetComponent<GameController>();
        mainCam = Camera.main;
        pauseMenu = GameObject.Find("PauseMenu");
        inGameGui = GameObject.Find("InGameGui");
        mySpawner = GetComponent<Spawner>();
        myGui = GetComponent<GUIController>();

        // TODO: Check which scene schould be loaded.
        StartLevel(0);
    }

    // TODO: Start Level
    public void StartLevel(int level)
    {
        // TODO: Issue: Goes into a loop?! Because its in the start Method of this
        // ... script and we are still in that level?
        //SceneManager.LoadScene(level);
        mySpawner.StartSpawnInterval(mySpawner.startIntervalLength);
        // Set Scene-Status
        sceneStatus = SceneStatus.Playing;
    }

    //TODO: Start Level with LevelName
    public void StartLevel(string levelName)
    {
        // TODO: Issue: Goes into a loop?!
        //SceneManager.LoadScene(levelName);
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

    //TODO: Pause Game
    public void PauseGame()
    {
        // TempSave the TimeScale
        tempTimeScale = Time.timeScale;
        // Set Time Scale to 0
        Time.timeScale = 0;
        // Show the GameMenu
        gameController.SendMessage("ShowHighscore");
        // Stopp the Touch and Mouse input reading
        gameController.SendMessage("StopInputChecking");
        // Set Scene-Status
        sceneStatus = SceneStatus.Paused;

    }

    //TODO: Resume Game, when in Pause Mode
    public void ResumeGame()
    {
        // Hides the Highscore Menu
        myGui.HideHighscore();
        // Reloads the  temporary Saved TimeScale
        Time.timeScale = tempTimeScale;
        // Resumes the Touch and Mouse input reading
        gameController.SendMessage("ResumeInputChecking");
        sceneStatus = SceneStatus.Playing;
    }

    //TODO: QuitGame
    public void QuitGame()
    {

    }

    //TODO: SavePlayerInfo
    public void SavePlayerInfo()
    {

    }

    //TODO: LoadPlayerInfo
    public void LoadPlayerInfo()
    {

    }

    //TODO: SaveHighscore
    public void SaveHighscore()
    {

    }

    // TODO: LoadHighscore
    public void LoadHighscore()
    {

    }
}