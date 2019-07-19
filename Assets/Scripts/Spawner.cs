using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    // The GameController
    GameObject gameController;

    private void Start()
    {
        // Game Controller assign
        gameController = GameObject.FindGameObjectWithTag("GameController");

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
        // Show Level-Text
        levelText.text = "Level " + SceneManager.GetActiveScene().buildIndex.ToString();

        // Start in x seconds and create ghosts with delay
        InvokeRepeating("Spawn",1, currentSpawnDelay);
    

        // TODO: Stop the wave and End Level
        Invoke("EndLevel", intervalLength);

    }

    void EndLevel()
    {

        // StopSpawning
        StopSpawning();
                     
        // Show Highscore
        gameController.GetComponent<GUIController>().ShowHighscore();

        // Start the next wave in 3 sec.
        //Invoke("StartSpawnInterval", 3);

        // if the delay is bigger than 0.2 sec
        if (currentSpawnDelay>0.2F)
        {
            // then reduce the Delay for 0.05 sec
            currentSpawnDelay -= 0.05F;
        }

        // TODO: Stop all Animals on Screen
        StopGame();
    }

    void StopSpawning()
    {
        // Cancel all Mehtods which has been started by invoke
        CancelInvoke();
    }

    // Stopp the Game
    void StopGame()
    {
        // Stopp spawning
        gameController.SendMessage("StopSpawning");

        // Show the GameOver-Menue
        gameController.SendMessage("ShowHighscore");

        // Stopp the Touch and Mouse input reading
        gameController.SendMessage("StopInputChecking");

        // Search for all Animals
        GameObject[] animals = GameObject.FindGameObjectsWithTag("Enemy");

        // Go trough every Ghost and stop them
        foreach (GameObject current in animals)
        {
            current.SendMessage("StopMoving");
        }
    }
}
