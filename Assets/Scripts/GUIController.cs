using UnityEngine;
using UnityEngine.UI;

public class GuiController : MonoBehaviour
{
    public GameObject pauseMenuUi;
    public Text currentScoreText;
    public Text timerText;
    public Button resumeButton;

    private void Start()
    {
        // Hide PauseMenu
        HidePauseMenu();
    }

    /// <summary>
    /// Shows the PauseMenu
    /// </summary>
    public void ShowPauseMenu()
    {
        // Show the Pause Menu
        pauseMenuUi.SetActive(true);
    }

    /// <summary>
    /// Hiding the Highscore Menu
    /// </summary>
    public void HidePauseMenu()
    {
        // Hide the Game-Over-Menue
        pauseMenuUi.SetActive(false);
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
}
