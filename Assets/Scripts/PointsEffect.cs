using System.Xml.Serialization;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

[CreateAssetMenu(fileName = "PointsEffect", menuName = "Pickups/Effects/PointsEffect")]
public class PointsEffect : ScriptableObject, IPickupEffect
{
    [SerializeField] int points;
    public void ApplyEffect(GameObject player)
    {   
        EventManager.AddScore(points);
    }
}