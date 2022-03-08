using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioClip[] clips;
    public AudioSource musicSource;
    public AudioSource soundSource;
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
        //inicia música general
        PlayMusic(clips[0]);
        
    }
    public void PlayMusic(AudioClip clip)
    {
        musicSource.clip = clip;
        musicSource.Play();
    }
    public void PlaySound(AudioClip clip)
    {
        soundSource.clip = clip;
        soundSource.Play();
    }
    
}
