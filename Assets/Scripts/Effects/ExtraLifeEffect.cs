using UnityEngine;

[CreateAssetMenu(fileName = "ExtraLifeEffect", menuName = "Pickups/Effects/ExtraLifeEffect")]
public class ExtraLifeEffect : ScriptableObject, IPickupEffect
{
    
    public void ApplyEffect(GameObject player)
    {   
        EventManager.AddAvatar();
    }
}