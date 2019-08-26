using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestListnener : MonoBehaviour
{ 
    private EventManager _eventManager;
    private void Awake()
    {
        _eventManager = GameObject.FindObjectOfType<EventManager>();
        //_eventManager.RegisterListener(_eventManager.OnLevelEnds, DoSomething);
    }

    private void DoSomething()
    {
        Debug.Log("The on Levelends Listner did react");
    }
}

