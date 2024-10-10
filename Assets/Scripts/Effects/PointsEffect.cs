using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "PointsEffect", menuName = "Pickups/Effects/PointsEffect")]
public class PointsEffect : ScriptableObject, IPickupEffect
{
    [SerializeField] ScoreData scoreData; 
    [SerializeField] int points;
    
    public void ApplyEffect(GameObject player)
    {   
        EventManager.AddScore(points * scoreData.currentMultiplier);
    }

}