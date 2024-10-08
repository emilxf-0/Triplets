using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFX : MonoBehaviour
{
    private ParticleSystem particles = null;
    
    void Start()
    {
        particles = GetComponent<ParticleSystem>();
    }

    public void Play()
    {
        Invoke(nameof(DestroyVFX), 1f);
    }

    private void DestroyVFX()
    {
        Destroy(gameObject);
    }
}

