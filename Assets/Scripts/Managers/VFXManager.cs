using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEditor.Tilemaps;
using TMPro;

public class VFXManager : MonoBehaviour
{
    private float mostRecentScore = 0;

    void OnEnable()
    {
        EventManager.OnAddScore        += UpdateRecentScore;
        EventManager.OnExplosionVFX    += CreateExplosionVFX;
        EventManager.OnFlyingNumberVFX += CreateFlyingNumberVFX;
    }

    void OnDisable()
    {
        EventManager.OnAddScore        -= UpdateRecentScore;
        EventManager.OnExplosionVFX    -= CreateExplosionVFX;
        EventManager.OnFlyingNumberVFX -= CreateFlyingNumberVFX;
    }

    public void UpdateRecentScore(int score) 
    { 
        mostRecentScore = score;
    }
    
    public void CreateExplosionVFX(GameObject gameObject, Vector3 position) 
    {
        Instantiate(gameObject, position, Quaternion.identity);
    }

    public void CreateFlyingNumberVFX(GameObject gameObject, Vector3 position)
    {
        var fx = Instantiate(gameObject, position, Quaternion.identity);
        var text = fx.GetComponentInChildren<TMP_Text>();
        text.text = mostRecentScore.ToString();

        fx.transform.DOMoveY(transform.position.y + 2, 1f).OnComplete(() => Destroy(fx));
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
