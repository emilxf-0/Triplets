using System.Collections;
using System.Collections.Generic;
using UnityEditor.Recorder;
using UnityEngine;

[CreateAssetMenu(fileName = "SpawnData")]
public class SpawnData : ScriptableObject 
{
    public Vector3 playerSpawnPoint;
    public Transform obstacleSpawnPoint;
    public Transform pickupSpawnPoint;
}
