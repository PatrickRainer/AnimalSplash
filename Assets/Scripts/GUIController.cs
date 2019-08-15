using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GUIController : MonoBehaviour
{
    // Panel for the complete Game-Over-Menue
    public GameObject uiPanel;
    // Highscore Menu Title
    public Text HighscoreTitle;
    // Top Text-Object
    public Text text1;
    // Bottom Text-Object
    public Text text2;
    // Current Score Text
    public Text currentScoreText;
    // AudioClip for the new Highscore
    public AudioClip gameOverClip;
    // AudioClip for Highscore
    public AudioClip highscoreClip;
    // Current Pointscount
    public int CurrentPoints;
    // Highscore on game start
    public int beginningHs;
    // The Spawner
    public Spawner mySpawner;
    // Timer Text
    public Text TimerText;
    // The Resume Button
    public Button resumeButton;

    private void Start()
    {
        mySpawner = GameObject.FindGameObjectWithTag("GameController").GetComponent<Spawner>();

        // Hide Game-Over-Menue
        uiPanel.SetActive(false);

        // Variable with 0
        beginningHs = 0;

    }

    /// <summary>
    /// Shows the PauseMenu
    /// </summary>
    public void ShowPauseMenu()
    {
        
        // Is the new pointcount higher than die old one?
        if (CurrentPoints > beginningHs)
        {
            // Play the Highscore-Clip TODO: Highscore sound clip
            AudioSource.PlayClipAtPoint(highscoreClip, transform.position);

            // Set Highscore-Text and Pointscount to the Textobjects
            text1.text = "New Highscore!";
            text2.text = "Score: " + CurrentPoints.ToString();
        }
        else
        {

            // Set the current Pointcount and the Highscore to the TextObjects
            text1.text = "Score: " + CurrentPoints.ToString();
            text2.text = "Highscore: " + beginningHs.ToString();
        }

        // Show the Pause Menu
        uiPanel.SetActive(true);
    }

    /// <summary>
    /// Hiding the Highscore Menu
    /// </summary>
    public void HidePauseMenu()
    {
        // Hide the Game-Over-Menue
        uiPanel.SetActive(false);
    }

    public void DisableResumeButton()
    {
        resumeButton.interactable = false;
        // Set the color of the text opacity to half    
        Text txt = (Text)GameObject.Find("TxtResume").GetComponent<Text>();
        Color clr = txt.color;
        clr.a = 0.5f;
        txt.color = clr;
        // End Set Transparency
    }

    public void OnGUI()
    {
        currentScoreText.text = "Score: "+CurrentPoints.ToString();
        TimerText.text = "Timer: "+((int)mySpawner.currentIntervallLength).ToString();
    }
}
