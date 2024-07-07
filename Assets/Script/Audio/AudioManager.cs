using System.Collections;
using System.Collections.Generic;
using Unity.Notifications.iOS;
using UnityEngine;
using System;
public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField] Sound[] MusicSounds;
    [SerializeField] Sound[] SfxSounds;
    [SerializeField] AudioSource MusicSource;
    [SerializeField] AudioSource SfxSource;

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void Start()
    {
        PlayMusic("Theme");
    }
    public void PlayMusic(string name)
    {
        Sound sound = Array.Find(MusicSounds, x => x.name == name);
        if (sound == null)
        {
            Debug.Log("music not found");
        }
        else
        {
            MusicSource.clip = sound.clip;
            MusicSource.Play();
        }
    }
    public void PlaySFX(string name)
    {
        Sound sound = Array.Find(SfxSounds, x => x.name == name);
        if (sound == null)
        {
            Debug.Log("music not found");
        }
        else
        {
            SfxSource.PlayOneShot(sound.clip);
        }
    }
}

[System.Serializable]
public class Sound
{
    [SerializeField] internal string name;
    [SerializeField] internal AudioClip clip;
}
