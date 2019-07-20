using UnityEngine;

public class TemplateClass
{
    public GameController gameController;
    public SceneController sceneController;
    public Camera mainCam;
    public GameObject pauseMenu;
    public GameObject mainMenu;

    public TemplateClass()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        sceneController = GameObject.FindGameObjectWithTag("SceneController").GetComponent<SceneController>();
        mainCam = Camera.main;
        pauseMenu = GameObject.Find("PauseMenu");
        mainMenu = GameObject.Find("MainMenu");
    }
}
