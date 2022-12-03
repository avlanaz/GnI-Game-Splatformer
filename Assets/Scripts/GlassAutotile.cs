using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassAutotile : MonoBehaviour
{
    public float StandardXScale = 4f;
    public float StandardYScale = 4f;
    public float textureOffsetX = 0.0f;
    public float textureOffsetY = 0.0f;
    Material mat;
    // Start is called before the first frame update
    void Start()
    {
        mat = gameObject.GetComponent<Renderer>().material;
        mat.SetTextureScale("_NormalTex", new Vector2(this.gameObject.transform.lossyScale.x / StandardXScale, this.gameObject.transform.lossyScale.y / StandardYScale));
        mat.SetTextureOffset("_NormalTex", new Vector2(textureOffsetX, textureOffsetY));
    }

    // Update is called once per frame
    void Update()
    {

    }
}
