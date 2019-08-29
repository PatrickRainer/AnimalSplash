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

        /// Dont destroy on load mechanic
        GameObject[] gameManagers = GameObject.FindGameObjectsWithTag("GameManager");
        if (gameManagers.Length>1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
        /// Dont destroy on load mechanic
    }
    #endregion

    /// <summary>
    /// Quits the Game
    /// </summary>
    public void QuitGame()
    {
        // TODO: Add WebPlayer, Android and Iphone Quit. Example is here: https://answers.unity.com/questions/161858/startstop-playmode-from-editor-script.html
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }

    public void LoadNextLevel()
    {
        // If the next scene exist
        if (!SceneManager.GetSceneByBuildIndex(SceneManager.GetActiveScene().buildIndex+1).IsValid())
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            //TODO: EndScreen or something
        }
        
    }

}
