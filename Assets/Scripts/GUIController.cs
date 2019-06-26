using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GUIController : MonoBehaviour
{
    // Panel for the complete Game-Over-Menue
    public GameObject uiPanel;

    // Top Text-Object
    public Text text1;

    // Bottom Text-Object
    public Text text2;

    // AudioClip for the new Highscore
    public AudioClip gameOverClip;

    // AudioClip for Highscore
    public AudioClip highscoreClip;

    // Current Pointscount, which is not shown in Inspector
    [HideInInspector] public int points = 0;

    // Highscore on game start
    int beginningHs;

    private void Start()
    {
        // Hide Game-Over-Menue
        uiPanel.SetActive(false);

        // Variable with 0
        beginningHs = 0;

        // Is there already a Highscore?
        if (PlayerPrefs.HasKey("Highscore"))
        {
            beginningHs = PlayerPrefs.GetInt("Highscore");
        }
    }

    // Show the Higscore
    void ShowHighscore()
    {
        // Is the new pointcount higher than die old one?
        if (points>beginningHs)
        {
            // Then write a new highscore.
            PlayerPrefs.SetInt("Highscore", points);

            // Save PlayerPrefs
            PlayerPrefs.Save();

            // Play the Highscore-Clip
            AudioSource.PlayClipAtPoint(highscoreClip, transform.position);

            // Set HIghscore-Text and Pointscount to the Textobjects
            text1.text = "New Highscore!";
            text2.text = "Score: " + points.ToString();
        }
        else
        {
            // If ther is no new Highscore, then play the GameOverClip
            AudioSource.PlayClipAtPoint(gameOverClip, transform.position);

            // Set the current Pointcount and the Highscore to the TextObjects
            text1.text = "Score: " + points.ToString();
            text2.text = "Highscore: " + beginningHs.ToString();
        }

        // Show the Game-Over-Menue
        uiPanel.SetActive(true);
    }

    // Load a Level
    public void LoadLevel(int index)
    {
        SceneManager.LoadScene(index);
    }
}
