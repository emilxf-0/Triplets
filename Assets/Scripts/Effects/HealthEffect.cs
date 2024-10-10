using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HealthEffect", menuName = "Pickups/Effects/HealthEffect")]
public class HealthEffect : ScriptableObject, IPickupEffect 
{
    public int healAmount;

    public void ApplyEffect(GameObject player)
    {
       EventManager.GainLife(player, healAmount);
    }
}
