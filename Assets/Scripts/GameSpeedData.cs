using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


[CreateAssetMenu(fileName = "GameSpeedData")]
public class GameSpeedData : ScriptableObject
{
    public float defaultGameSpeed;
    [HideInInspector] public float speed;

    void OnEnable()
    {
        speed = defaultGameSpeed;
        EventManager.OnSetGameSpeed += OnSetGameSpeed;
    }

    void OnDisable()
    {
        EventManager.OnSetGameSpeed -= OnSetGameSpeed;
    }

    void OnSetGameSpeed(float gameSpeed)
    {
        speed += gameSpeed;
    }
}
