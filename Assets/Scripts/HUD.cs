using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText = null;
    private int score = 0;

    void OnEnable()
    {
        EventManager.OnPickUpDestroyed += OnPickUpDestroyed;
    }

    void OnPickUpDestroyed()
    {
        score += 1;
        scoreText.text = $"Score: {score:D6}";
    }

    void OnDisable()
    {
        EventManager.OnPickUpDestroyed -= OnPickUpDestroyed;
    }
    void Start()
    {
        scoreText.text = $"Score: {score:D6}";
    }

    void Update()
    {

    }
}
