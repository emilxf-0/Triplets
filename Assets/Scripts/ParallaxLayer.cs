using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxLayer : MonoBehaviour
{
    [SerializeField] private float parallaxSpeed = 0;

    public float ParallaxSpeed { get => parallaxSpeed; set => parallaxSpeed = value; }
}
