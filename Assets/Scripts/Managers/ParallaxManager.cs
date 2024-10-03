using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class ParallaxManager : MonoBehaviour
{
    [Serializable]
    public class Parallax 
    {
        public Sprite background;
        public float speed;

    }
    public GameObject parallaxLayerPrefab;
    [SerializeField] private List<Parallax> parallax;
    private List<GameObject> parallaxLayers = new();
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
            parallaxLayers[i].GetComponent<ParallaxLayer>().ParallaxSpeed = parallax[i].speed;
            parallaxRenderers[i].sortingOrder -= parallax.Count - i;
            textureWidth = parallaxRenderers[i].sprite.texture.width / parallaxRenderers[i].sprite.pixelsPerUnit;
        }
    }

    void Update()
    { 
        for (int i = 0; i < parallaxLayers.Count; i++)
        {
            var bounds = parallaxRenderers[i].bounds;
            var rightEdge = bounds.size.x;
            parallaxLayers[i].transform.position += new Vector3(-parallax[i].speed * Time.deltaTime, 0, 0);

            if ((Mathf.Abs(parallaxLayers[i].transform.position.x) - textureWidth) > 0)
            {
                parallaxLayers[i].transform.position = new Vector3(0, 0, 0 );
            }
        }
    }
}
