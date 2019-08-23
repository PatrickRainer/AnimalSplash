using UnityEngine.UI;
using UnityEngine;
using System;

public class EndLevelMenuController : MonoBehaviour
{
    public Image[] scoringStars;

    private void Awake()
    {
        //Assign Event
        LevelController lc = GameObject.Find("LevelManager").GetComponent<LevelController>();
        lc.OnLevelEnds += ShowEndLevelMenu;
        lc.OnLevelPlays += HideEndLevelMenu;
    }
    private void Start()
    {
        this.gameObject.SetActive(false);
    }
    private void FillStar(int starNumber, float fillAmount)
    {
        scoringStars[starNumber].fillAmount = fillAmount;
    }
    private void FillStars()
    {
        ScoreCounter scoreCounter = GameObject.Find("LevelManager").GetComponent<ScoreCounter>();
        int completeStarsToFill = FirstDigit(scoreCounter.starsToFillAmount);
        float partlyStarToFill = SecondDigit(scoreCounter.starsToFillAmount);

        //Fill CompleteStars
        for (int i = 0; i < completeStarsToFill; i++)
        {
            scoringStars[i].fillAmount = 1;
        }

        //Fill the partly Star
        scoringStars[completeStarsToFill].fillAmount = partlyStarToFill;
    }

    private static int FirstDigit(float number)
    {
        while (number>=10)
        {
            number /= 10;
        }
        Debug.Log("FirstDigit: "+(int)number);
        return (int)number;
    }

    private static float SecondDigit(float number)
    {
        // Check if it has a decimal
        if ((number % 1) != 0)
        {
            //Round to one decimal
            number=(float)Math.Round(number, 1);
            number = number % 1;
            return number;
        }

        Debug.Log("Second Digit: " + number);

        return 0f;
    }
    private void ShowEndLevelMenu()
    {
        this.gameObject.SetActive(true);
        FillStars();
    }
    private void HideEndLevelMenu()
    {
        this.gameObject.SetActive(false);
    }
}
