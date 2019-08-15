using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicController : MonoBehaviour
{
    #region SingletonPattern
    private static MusicController _instance;
    public static MusicController Instance { get { return _instance; } }

    private void Awake()
    {
        _instance = this;
    }
    #endregion

    #region Members

    public List<AudioClip> musicTracks = new List<AudioClip>();
    public float Volume { get { return myAudiosource.volume; } set { myAudiosource.volume = value; SaveVolumeToPrefs(); PlayerPrefs.Save(); } }
    private AudioSource myAudiosource;
    private int currentTrackIndex;

    #endregion

    #region Initializing
    private void Start()
    {
        myAudiosource = GetComponent<AudioSource>();
        PlayAllTracksInLoop();
        LoadVolumeFromPrefs();
    }

    private void Update()
    {
        if (!myAudiosource.isPlaying)
        {
            PlayNextTrack();
        }
    }

    private void PlayNextTrack()
    {
        if (currentTrackIndex<musicTracks.Count)
        {
            myAudiosource.clip = musicTracks[currentTrackIndex + 1];
        }
        else if (currentTrackIndex>=musicTracks.Count)
        {
            myAudiosource.clip = musicTracks[0];
        }
        
    }

    private void LoadVolumeFromPrefs()
    {
        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            Volume = PlayerPrefs.GetFloat("MusicVolume");
        }
        
    }
    #endregion

    private void PlayTrack(int trackNumber)
    {

    }

    private void PlayAllTracksInLoop()
    {
        myAudiosource.clip = musicTracks[0];
        myAudiosource.loop = true;
        myAudiosource.Play();
    }

    private void StopMusic()
    {
        myAudiosource.Stop();
    }

    private void SetVolume(float volume)
    {
        Volume = volume;
    }

    private void SaveVolumeToPrefs()
    {
        PlayerPrefs.SetFloat("MusicVolume", Volume);
    }

}
