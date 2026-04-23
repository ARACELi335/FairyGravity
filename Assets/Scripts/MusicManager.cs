using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource music;
    public AudioSource deadMusic;


    private static MusicManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayDeadMusic()
    {
        music.Pause();
        deadMusic.Play();
    }
    public void ResumeMusic()
    {
        deadMusic.Stop();
        music.UnPause();
    }
}
