using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPickupType", menuName = "Pickups/PickupType")]
public class PickupType : ScriptableObject
{
    public string pickupName;
    public List<Sprite> sprites;
    public List<ScriptableObject> effects;

    public void ApplyEffects(GameObject gameObject)
    {
        foreach (var effect in effects)
        {
            if (effect is IPickupEffect pickupEffect)
            {
                pickupEffect.ApplyEffect(gameObject);
            }
        }
    }

}