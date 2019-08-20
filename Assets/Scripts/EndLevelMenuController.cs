using UnityEngine.UI;
using UnityEngine;

public class EndLevelMenuController : MonoBehaviour
{
    public Image[] scoringStars;

    private void Awake()
    {
        //Assign Event
        LevelController lc = GameObject.Find("LevelManager").GetComponent<LevelController>();
        lc.OnLevelEnds += ShowEndLevelMenu;
    }
    private void Start()
    {
        this.gameObject.SetActive(false);
    }
    private void FillStar(int starNumber, float fillAmount)
    {
        scoringStars[starNumber].fillAmount = fillAmount;
    }
    private void ShowEndLevelMenu()
    {
        this.gameObject.SetActive(true);
    }
}
