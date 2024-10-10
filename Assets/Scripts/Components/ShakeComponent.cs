using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ShakeComponent : MonoBehaviour
{
    [SerializeField] bool shakeOnDamage;
    [SerializeField] float shakeTime = 0;
    [SerializeField] float shakeStrength = 0;
    private Vector3 startPos;

    void OnEnable()
    {
//        if (shakeOnDamage)
        {
            EventManager.OnTakeDamage += OnTakeDamage;
        }
    }

    void OnDisable()
    {
        //if (shakeOnDamage)
        {
            EventManager.OnTakeDamage -= OnTakeDamage;
        }
    }

    void Start()
    {
        startPos = GetComponent<Transform>().transform.position;
    }

    void OnTakeDamage(GameObject gameObject, int damage)
    {
        Shake();
    }

    void Shake()
    {
        transform.DOShakePosition(shakeTime, shakeStrength).SetId(this).OnComplete(() => 
        {
            transform.position = startPos;
            DOTween.Kill(this);
        });       
    }

}
