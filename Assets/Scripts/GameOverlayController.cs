using UnityEngine;
using UnityEngine.UI;

public class GameOverlayController : MonoBehaviour
{
    private GameObject levelStartText;
    private Slider timerFillbar;
    private LevelTimer levelTimer;
    private Animator scoreStarAnim;

    private void Awake()
    {
        levelStartText = GameObject.Find("LevelStartText");
        timerFillbar = GameObject.Find("TimerFillbar").GetComponent<Slider>();
        levelTimer = GameObject.Find("LevelManager").GetComponent<LevelTimer>();
        scoreStarAnim = GameObject.Find("ScoreStar").GetComponent<Animator>();
    }
    void Start()
    {
        levelStartText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnGUI()
    {
        timerFillbar.value=LevelPrefs.Instance.levelDuration / 100 * levelTimer.timeLeft;

        scoreStarAnim.SetTrigger("HeartBeatTrigger");
     
    }
}
