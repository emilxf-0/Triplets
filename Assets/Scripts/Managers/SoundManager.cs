using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    
    [SerializeField] AudioClip gameMusic;
    [SerializeField] AudioClip jump;
    [SerializeField] AudioClip pickup;
    [SerializeField] AudioClip extraLife;

    private AudioSource sfxAudioSource;
    private AudioSource musicAudioSource;

    private float minPitch = 0.95f;
    private float maxPitch = 1.05f;

    void OnEnable()
    {
        EventManager.OnAddScore   += OnAddScore;
        EventManager.OnPlayerJump += OnPlayerJump;
        EventManager.OnAddAvatar  += OnAddAvatar;
    }

    void OnDisable()
    {
        EventManager.OnAddScore   -= OnAddScore;
        EventManager.OnPlayerJump -= OnPlayerJump;
        EventManager.OnAddAvatar  -= OnAddAvatar;
    }

    void Start()
    {
        sfxAudioSource = Instantiate(audioSource);
        musicAudioSource = Instantiate(sfxAudioSource);
        PlayMusic(gameMusic);
    }

    void OnAddScore(int score)
    {
        PlaySoundFX(pickup);
    }

    void OnPlayerJump()
    {
        PlaySoundFX(jump);
    }

    void OnAddAvatar()
    {
        PlaySoundFX(extraLife);
    }

    void PlaySoundFX(AudioClip clip, float volume = 1f)
    {
        sfxAudioSource.pitch = UnityEngine.Random.Range(minPitch, maxPitch);        
        sfxAudioSource.PlayOneShot(clip, volume);
    }

    void PlayMusic(AudioClip clip, float volume = 0.5f)
    {
        musicAudioSource.PlayOneShot(clip, volume);
    }
}
