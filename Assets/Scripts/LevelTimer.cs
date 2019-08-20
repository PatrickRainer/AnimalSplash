using UnityEngine;

public class LevelTimer : MonoBehaviour
{
    #region Members
    public bool isActive = false;
    public float timeLeft = 0f;
    public bool isElapsed = false;
    #endregion

    #region Events
    public delegate void TimerEnd();
    public event TimerEnd OnTimerEnds;
    #endregion

    #region Initializing
    private void Start()
    {
        OnTimerEnds += LevelTimer_OnTimerEnds;
    }
    #endregion

    #region EventHandlers
    private void LevelTimer_OnTimerEnds()
    {
        isElapsed = true;
        isActive = false;
    }
    #endregion

    #region Frame based methods
    private void Update()
    {
        if (isActive)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft <= 0)
            {
                OnTimerEnds();
            }
        }
    }
    #endregion

    #region General Methods
    public void ResetTimer(float timeToCount)
    {
        timeLeft = timeToCount;
    }

    public void StopTimer()
    {
        isActive = false;
    }

    public void StartTimer(float timeToCount)
    {
        timeLeft = timeToCount;
    }
    #endregion
}
