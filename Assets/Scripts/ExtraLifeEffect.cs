using System.Xml.Serialization;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

[CreateAssetMenu(fileName = "ExtraLifeEffect", menuName = "Pickups/Effects/ExtraLifeEffect")]
public class ExtraLifeEffect : ScriptableObject, IPickupEffect
{
    
    public void ApplyEffect(GameObject player)
    {   
        EventManager.AddLife();
    }
}