using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveController : MonoBehaviour
{
    public ParticleSystem destroyEffect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDisable()
    {
        if (!this.gameObject.scene.isLoaded) return;
        ChangeColor();
        Instantiate(destroyEffect, transform.position, transform.rotation);
    }

    private void ChangeColor()
    {
        for (int i = 0; i < destroyEffect.transform.childCount; i++)
        {
            var currentmain = destroyEffect.transform.GetChild(i).GetComponent<ParticleSystem>().main;
            currentmain.startColor = this.gameObject.GetComponent<Renderer>().material.color;
            var currnetShape = destroyEffect.transform.GetChild(i).GetComponent<ParticleSystem>().shape;
            currnetShape.scale = this.transform.localScale;
        }
    }
}
