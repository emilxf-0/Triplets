using System;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxManager : MonoBehaviour
{
    [Serializable]
    public class Parallax 
    {
        public Sprite background;
        public float speedMultiplier;
    }

    public GameObject parallaxLayerPrefab;
    [SerializeField] private List<Parallax> parallax;
    [SerializeField] private bool isTutorial;
    [SerializeField] GameSpeedData gameSpeedData;
    private List<GameObject> parallaxLayers        = new();
    private List<SpriteRenderer> parallaxRenderers = new();
    private float screenWidthInWorld;
    private float textureWidth;
    void Start()
    {

        for (int i = 0; i < parallax.Count; i++)
        {
            parallaxLayers.Add(Instantiate(parallaxLayerPrefab));
            parallaxRenderers.Add(parallaxLayers[i].GetComponent<SpriteRenderer>());
            parallaxRenderers[i].sprite = parallax[i].background;
            parallaxRenderers[i].size *= new Vector2(3, 1);
            parallaxRenderers[i].sortingOrder -= parallax.Count - i;
            textureWidth = parallaxRenderers[i].sprite.texture.width / parallaxRenderers[i].sprite.pixelsPerUnit;
        }
    }

    void Update()
    {
        if (isTutorial)
        {
            return;
        } 

        for (int i = 0; i < parallaxLayers.Count; i++)
        {
            var bounds = parallaxRenderers[i].bounds;
            var rightEdge = bounds.size.x;
            
            float speed = gameSpeedData.speed * parallax[i].speedMultiplier;
            parallaxLayers[i].transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);

            if ((Mathf.Abs(parallaxLayers[i].transform.position.x) - textureWidth) > 0)
            {
                parallaxLayers[i].transform.position = new Vector3(0, 0, 0 );
            }
        }
    }
}
