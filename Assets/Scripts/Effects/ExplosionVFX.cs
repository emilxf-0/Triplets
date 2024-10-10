using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "ExplosionVFX", menuName = "Pickups/VFX/ExplosionVFX")]
public class ExplosionVFX : ScriptableObject, IVfx
{
    [SerializeField] GameObject vfx;

    public void ApplyVFX(Vector3 position)
    {
        EventManager.ExplosionVFX(vfx, position); 
    }

}