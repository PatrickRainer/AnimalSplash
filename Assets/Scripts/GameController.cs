using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        DontDestroyOnLoad(this.gameObject);
    }
    #endregion

}
