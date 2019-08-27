using UnityEngine;
using UnityEngine.UI;

public class GameOverlayController : MonoBehaviour
{
    private GameObject levelStartText;
    private Slider timerFillbar;
    private LevelTimer levelTimer;
    private Animator scoreStarAnim;
    private Button pauseBtn;
    private GameObject endLevelMenu;

    private void Awake()
    {
        levelStartText = GameObject.Find("LevelStartText");
        timerFillbar = GameObject.Find("TimerFillbar").GetComponent<Slider>();
        levelTimer = GameObject.Find("LevelManager").GetComponent<LevelTimer>();
        scoreStarAnim = GameObject.Find("ScoreStar").GetComponent<Animator>();
        pauseBtn = GameObject.Find("PauseBtn").GetComponent<Button>();
        endLevelMenu = GameObject.Find("EndLevelMenu");
    }
    void Start()
    {
        levelStartText.SetActive(false);
    }
    private void Update()
    {
        // While EndLevel is open, deactivate Pause Button
        if (endLevelMenu.activeInHierarchy)
        {
            pauseBtn.interactable = false;
        }
        else
        {
            pauseBtn.interactable = true;
        }

    }
    private void OnGUI()
    {
        timerFillbar.value=LevelPrefs.Instance.levelDuration / 100 * levelTimer.timeLeft;     
    }
    public void AnimateStar()
    {
        scoreStarAnim.SetTrigger("HeartBeatTrigger");
    }
}
