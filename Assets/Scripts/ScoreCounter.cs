using System.Collections.ObjectModel;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    private float maxScore=0f;
    private float currentScore=0f;
    [HideInInspector]
    public float starsToFillAmount=0f;
    private Spawner spawner;
    private ObservableCollection<GameObject> mySpawnedAnimals;

    private void Awake()
    {
        spawner = GameObject.Find("LevelManager").GetComponent<Spawner>();
        spawner.spawnedAnimals.CollectionChanged += SpawnedAnimals_CollectionChanged;
    }

    private void SpawnedAnimals_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
    {
        // Write the last spawned Animal into a variable
        mySpawnedAnimals = (ObservableCollection<GameObject>)sender;
        GameObject spawnedAnimal = mySpawnedAnimals[mySpawnedAnimals.Count - 1];

        // Set the Eventhandler for the onclickEvent of the last spawned Animal
        AnimalBehaviour currentAnimal = spawnedAnimal.GetComponent<AnimalBehaviour>();
        currentAnimal.AnimalOnClicked += AnimalOnClicked;

        // Set Maxscore to the amount of spawned Animals
        maxScore = mySpawnedAnimals.Count;

        //DELETE: Debuglog
        Debug.Log("MaxScore is: "+maxScore.ToString());
        Text maxScoreTxt = GameObject.Find("MaxScoreText").GetComponent<Text>();
        maxScoreTxt.text = "MaxScore is: " + maxScore.ToString();
    }

    private void AnimalOnClicked()
    {
        CountScore();
    }

    public void CountScore()
    {
        currentScore++; //BUG: Currentscore is higher than MaxScore. Found Reason, Touch inputs ar counted twice.
        starsToFillAmount = (100/maxScore * currentScore)/20;

        //DELETE:
        //Debug.Log("MaxScore is: " + maxScore.ToString());
        Debug.Log("CurrentScore is: " + currentScore.ToString());
        Text curScoreText = GameObject.Find("CurrentScoreText").GetComponent<Text>();
        curScoreText.text = "CurrentScore is: " + currentScore.ToString();

        // Calculate percentage
        float percent = 0f;
        percent=currentScore / maxScore * 100;
    }

}
