using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class MusicController : MonoBehaviour
{
    #region Members
    [HideInInspector]
    public Slider volumeSlider;
    private AudioSource myAudiosource;
    #endregion

    #region Initializing
    private void Awake()
    {
        volumeSlider = GameObject.Find("VolumeSlider").GetComponent<Slider>();

        //The Music shall not restart on reload level
        if (GameObject.FindObjectsOfType<MusicController>().Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
    private void Start()
    {
        myAudiosource = GetComponent<AudioSource>();
        LoadVolumeFromPrefs();
        volumeSlider.value = myAudiosource.volume;   
    }
    #endregion

    #region Methods

    private void LoadVolumeFromPrefs()
    {
        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            myAudiosource.volume = PlayerPrefs.GetFloat("MusicVolume");
        }
    }

    private void StopMusic()
    {
        myAudiosource.Stop();
    }

    private void OnDestroy()
    {
        SaveVolumeToPrefs();
    }

    private void SaveVolumeToPrefs()
    {
        // If myAudioSource isnot null, save the volume
        if (myAudiosource) 
        {
            PlayerPrefs.SetFloat("MusicVolume", myAudiosource.volume);
        }
        
    }
    #endregion
}
