using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCaller : MonoBehaviour
{
    private EventManager _eventManager;
    private void Awake()
    {
        _eventManager = GameObject.FindObjectOfType<EventManager>();
    }
    private void Start()
    {
       // _eventManager.OnLevelEnds.Invoke();
    }
}
