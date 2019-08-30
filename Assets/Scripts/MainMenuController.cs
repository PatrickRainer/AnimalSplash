using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        // Prevent from going to Portrait mode
        Screen.autorotateToLandscapeRight = true;
        Screen.orientation = ScreenOrientation.Landscape;

        // Deactivate VolumeSlider
        GameObject.Find("VolumeSlider").SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void QuitGame()
    {
        Application.Quit();
        //UnityEditor.EditorApplication.isPlaying = false; // TODO: Does error in build mode
    }

    public void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }
}
