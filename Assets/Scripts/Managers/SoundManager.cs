using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    private AudioSource vfxAudioSource;
    private AudioSource musicAudioSource;
    
    [SerializeField] AudioClip gameMusic;
    [SerializeField] AudioClip jump;
    [SerializeField] AudioClip pickup;

    private float minPitch = 0.95f;
    private float maxPitch = 1.05f;

    void OnEnable()
    {
        EventManager.OnAddScore   += OnAddScore;
        EventManager.OnPlayerJump += OnPlayerJump;
    }

    void OnDisable()
    {
        EventManager.OnAddScore   -= OnAddScore;
        EventManager.OnPlayerJump -= OnPlayerJump;
    }

    void Start()
    {
        vfxAudioSource = Instantiate(audioSource);
        musicAudioSource = Instantiate(vfxAudioSource);
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

    void PlaySoundFX(AudioClip clip, float volume = 1f)
    {
        vfxAudioSource.pitch = UnityEngine.Random.Range(minPitch, maxPitch);        
        vfxAudioSource.PlayOneShot(clip, volume);
    }

    void PlayMusic(AudioClip clip, float volume = 0.5f)
    {
        musicAudioSource.PlayOneShot(clip, volume);
    }
}
