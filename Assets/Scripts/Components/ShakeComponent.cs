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
        EventManager.OnTakeDamage += OnTakeDamage;
    }

    void OnDisable()
    {
        EventManager.OnTakeDamage -= OnTakeDamage;
        DOTween.Kill(this);
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
        DOTween.Complete(this);

        transform.DOShakePosition(shakeTime, shakeStrength).SetId(this).OnComplete(() => 
        {
            transform.position = startPos;
        });       
    }

}
