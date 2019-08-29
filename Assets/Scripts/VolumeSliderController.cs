using UnityEngine;
using UnityEngine.UI;

public class VolumeSliderController : MonoBehaviour
{
    private Slider mySlider;
    private AudioSource myMusicSource;

    private void Awake()
    {
        mySlider = GetComponent<Slider>();
        myMusicSource = GameObject.FindObjectOfType<MusicController>().GetComponent<AudioSource>();
        //UNDONE: Initialize volume
        mySlider.value = PlayerPrefs.GetFloat("MusicVolume");
        mySlider.onValueChanged.AddListener((value) => { myMusicSource.volume = value; });
    }
}
