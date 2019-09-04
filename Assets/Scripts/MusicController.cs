using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class MusicController : MonoBehaviour
{
    #region Members
    private AudioSource myAudiosource;
    #endregion

    #region Initializing
    private void Awake()
    {
        //The Music shall not restart on reload level
        if (GameObject.FindObjectsOfType<MusicController>().Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);

        //Music Init on first GameStart
        if (!PlayerPrefs.HasKey("MusicVolume"))
        {
            PlayerPrefs.SetFloat("MusicVolume", 1f);
            PlayerPrefs.Save();
        }
    }
    private void Start()
    {
        myAudiosource = GetComponent<AudioSource>();
        LoadVolumeFromPrefs();
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

    public void ToggleSound()
    {
        if (myAudiosource.isPlaying)
        {
            myAudiosource.Pause();
        }
        else
        {
            myAudiosource.Play();
        }
        
    }
    #endregion
}
