using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

#region Enums
public enum LevelStatus
{
    isPlaying,
    isPaused,
    hasEnded
}
#endregion

public class EventManager : MonoBehaviour
{
    #region SingletonPattern
    private static EventManager _instance;
    public static EventManager Instance { get { return _instance; } }

    private void Awake()
    {
        _instance = this;
    }
    #endregion
    #region Events
    public UnityEvent OnLevelEnds = new UnityEvent();
    public UnityEvent OnLevelPauses = new UnityEvent();
    public UnityEvent OnLevelPlays = new UnityEvent();
    #endregion

}
