using UnityEngine;
using UnityEngine.SceneManagement;

// https://docs.unity3d.com/ScriptReference/SceneManagement.SceneManager.MoveGameObjectToScene.html
// https://docs.unity3d.com/ScriptReference/Object.DontDestroyOnLoad.html


    /// <summary>
    /// The Class controls the Main Elements of the whole game and the 
    /// belonging GameObject, can be moved from scene to scene
    /// </summary>
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

    /// <summary>
    /// Quits the Game
    /// </summary>
    public void QuitGame()
    {
        // TODO: Add WebPlayer, Android and Iphone Quit. Example is here: https://answers.unity.com/questions/161858/startstop-playmode-from-editor-script.html
        Application.Quit();

    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #endif
    }

    public void LoadNextLevel()
    {
        int curSceIdx = SceneManager.GetActiveScene().buildIndex;
        int numberOfScenes = SceneManager.sceneCountInBuildSettings;

        // Check if next scene exists
        if (numberOfScenes>curSceIdx+1)
        {
            // and load the scene
            SceneManager.LoadScene(curSceIdx + 1);
        }
        else
        {
            //Goto MainMenu
            SceneManager.LoadScene("MainMenu");
        }
    }

}
