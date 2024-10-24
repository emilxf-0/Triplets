using System.Collections;
using System.Collections.Generic;
using DG.Tweening.Core.Easing;
using UnityEngine;

public class FlashComponent : MonoBehaviour
{
    [SerializeField] private float flashTime = 0.5f;
    
    private SpriteRenderer spriteRenderer;
    
    private Color flashColor = Color.white;

    void OnEnable()
    {
        EventManager.OnTakeDamage += Flash;
    }

    void OnDisable()
    {
        EventManager.OnTakeDamage -= Flash;
    }

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    void Flash(GameObject gameObject, int damage)
    {
        if (gameObject == this.gameObject)
        {
            StartCoroutine(nameof(DamageFlash));
        }
    }

    IEnumerator DamageFlash()
    {
        spriteRenderer.material.SetColor("_FlashColor", flashColor);

        float currentTime = 0;
        float currentFlashAmount = 0f;
        
        while (currentTime < flashTime)
        {
            currentTime += Time.deltaTime;
            currentFlashAmount = Mathf.Lerp(1, 0, currentTime / flashTime);
            spriteRenderer.material.SetFloat("_FlashAmount", currentFlashAmount);
            yield return null;
        }
        
    }
}
