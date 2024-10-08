using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] AudioClip gameMusic;
    [SerializeField] AudioClip jump;
    [SerializeField] AudioClip pickup;


    
    void OnEnable()
    {
        EventManager.OnStartGame += OnStartGame;
        EventManager.OnAddScore  += OnAddScore;
        EventManager.On
    }

    void OnDisable()
    {
        EventManager.OnStartGame -= OnStartGame;
        EventManager.OnAddScore  -= OnAddScore;
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();        
        audioSource.PlayOneShot(gameMusic, 0.5f);
    }

    void OnStartGame()
    {
    }

    void OnAddScore(int score)
    {
        audioSource.PlayOneShot(pickup);
    }
}
