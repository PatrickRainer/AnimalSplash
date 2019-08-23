using System.Collections.ObjectModel;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    private float maxScore=0;
    private float currentScore=0;
    [HideInInspector]
    public float starsToFillAmount=0f;


    private Spawner spawner;

    private void Awake()
    {
        spawner = GameObject.Find("LevelManager").GetComponent<Spawner>();
        spawner.spawnedAnimals.CollectionChanged += SpawnedAnimals_CollectionChanged;
    }

    private void SpawnedAnimals_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
    {
        ObservableCollection<GameObject> mySpawnedAnimals = (ObservableCollection<GameObject>)sender;
        GameObject spawnedAnimal = mySpawnedAnimals[mySpawnedAnimals.Count - 1];

        AnimalBehaviour currentAnimal = spawnedAnimal.GetComponent<AnimalBehaviour>();
        currentAnimal.AnimalOnClicked += AnimalOnClicked;
    }

    private void AnimalOnClicked()
    {
        CountScore();
    }

    public void CountScore()
    {
        maxScore = spawner.spawnedAnimals.Count;
        currentScore++;
        starsToFillAmount = (100/maxScore * currentScore)/20;

        Debug.Log("Gecklickte Sterne/von: "+currentScore.ToString() + "/"+maxScore.ToString());

        float percent = 0f;
        percent=currentScore / maxScore * 100;
        Debug.Log("Prozent erfüllt: " + percent + "%");
        Debug.Log("Anzahl Sterne gefüllt: " + starsToFillAmount.ToString());// TODO: Noch au 5 Sternesystem umrechnen, 100% = 5 Sterne, zb 57% = xy Sterne
    }

}
