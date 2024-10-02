using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class ParallaxManager : MonoBehaviour
{
    [SerializeField] private List<Sprite> backgrounds = new();
    [SerializeField] private GameObject parallaxLayerPrefab;
    [SerializeField] private List<float> parallaxSpeed = new();
    private List<GameObject> parallaxLayers = new();
    private List<SpriteRenderer> parallaxRenderers = new();
    private float screenWidthInWorld;
    private float textureWidth;
    void Start()
    {

        for (int i = 0; i < backgrounds.Count; i++)
        {
            parallaxLayers.Add(Instantiate(parallaxLayerPrefab));
            parallaxRenderers.Add(parallaxLayers[i].GetComponent<SpriteRenderer>());
            parallaxRenderers[i].sprite = backgrounds[i];
            parallaxRenderers[i].size *= new Vector2(3, 1);
            parallaxLayers[i].GetComponent<ParallaxLayer>().ParallaxSpeed = parallaxSpeed[i];
            parallaxRenderers[i].sortingOrder -= backgrounds.Count - i;
            textureWidth = parallaxRenderers[i].sprite.texture.width / parallaxRenderers[i].sprite.pixelsPerUnit;
        }
    }

    void Update()
    { 
        for (int i = 0; i < parallaxLayers.Count; i++)
        {
            var bounds = parallaxRenderers[i].bounds;
            var rightEdge = bounds.size.x;
            parallaxLayers[i].transform.position += new Vector3(-parallaxSpeed[i] * Time.deltaTime, 0, 0);

            if ((Mathf.Abs(parallaxLayers[i].transform.position.x) - textureWidth) > 0)
            {
                parallaxLayers[i].transform.position = new Vector3(0, 0, 0 );
            }
        }
    }
}
