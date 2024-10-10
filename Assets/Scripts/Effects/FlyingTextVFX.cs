using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

[CreateAssetMenu(fileName = "FlyingTextVFX", menuName = "Pickups/VFX/FlyingTextVFX")]
public class FlyingTextVFX : ScriptableObject, IVfx
{
    [SerializeField] GameObject vfx;
    
    public void ApplyVFX(Vector3 position)
    {
        EventManager.FlyingNumberVFX(vfx, position);
    }

}