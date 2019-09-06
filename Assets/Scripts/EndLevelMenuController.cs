using UnityEngine.UI;
using UnityEngine;
using System;

public class EndLevelMenuController : MonoBehaviour
{
    // HACK:
    int completeStarsToFill;

    public Image[] scoringStars;
    private EventManager myEventManager;
    private ScoreCounter scoreCounter;

    private void Awake()
    {
        // Assign Members
        scoreCounter = GameObject.Find("LevelManager").GetComponent<ScoreCounter>();
        //Assign Event
        LevelController lc = GameObject.Find("LevelManager").GetComponent<LevelController>();
        myEventManager = GameObject.FindObjectOfType<EventManager>();
        myEventManager.OnLevelEnds.AddListener(ShowEndLevelMenu);
        myEventManager.OnLevelPlays.AddListener(HideEndLevelMenu);
    }
    private void Start()
    {
        this.gameObject.SetActive(false);
    }
    private void FillStar(int starNumber, float fillAmount)
    {
        scoringStars[starNumber].fillAmount = fillAmount;
    }
    private void OnGUI()
    {
        //DELETE:
        GUILayout.Label("StarsToFill is: " + completeStarsToFill);
    }
    private void FillStars()
    {
        //TEST: Test without the function, it has an error on Android       
        completeStarsToFill = GetFirstDigit(scoreCounter.starsToFillAmount);
        float partlyStarToFill = GetSecondDigit(scoreCounter.starsToFillAmount);
        
        //Fill CompleteStars
        for (int i = 0; i < completeStarsToFill; i++)
        {
                scoringStars[i].fillAmount = 1f;
        }

        //UNDONE: Activate as soon fixed the Bug of filling the Stars
        ////Fill the partly Star
        //if (partlyStarToFill > 0.1f)
        //{
        //    scoringStars[completeStarsToFill].fillAmount = partlyStarToFill;
        //}

    }
    /// <summary>
    /// Gets the first Digit of any Number
    /// </summary>
    /// <param name="number"></param>
    /// <returns></returns>
    private static int GetFirstDigit(float number)
    {
        while (number>=10)
        {
            number /= 10;
        }
        return (int)number;
    }
    /// <summary>
    /// Gets the second Digit of any number
    /// </summary>
    /// <param name="number"></param>
    /// <returns></returns>
    private static float GetSecondDigit(float number)
    {
        // Check if it has a decimal
        if ((number % 1) != 0)
        {
            //Round to one decimal
            number=(float)Math.Round(number, 1);
            number = number % 1;
            return number;
        }
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
