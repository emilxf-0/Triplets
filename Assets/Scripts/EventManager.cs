using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public static class EventManager 
{
    public static event Action OnPickUpDestroyed;
    public static void PickupDestroyed()
    {
        OnPickUpDestroyed?.Invoke();   
    }
}
