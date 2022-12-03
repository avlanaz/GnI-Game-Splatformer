using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    Material bullet_m;
    public ParticleSystem spark;
    void Start()
    {
        bullet_m = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerMove.reset) {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.isTrigger)
        {
            if (other.GetComponent<ColorChange>() != null)
            {
                ColorChange colorChanger = other.GetComponent<ColorChange>();
                if (this.gameObject.CompareTag("redBullet"))
                {
                    
                    colorChanger.makeRed();
                }
                else if (this.gameObject.CompareTag("blueBullet"))
                {
                    colorChanger.makeBlue();
                }

                if (this.gameObject.CompareTag("clearBullet"))
                {
                    colorChanger.makeWhite();
                }
            }
            if (!other.gameObject.CompareTag("Player"))
            {
                StartColor = bullet_m.color;
                //Debug.Log(bullet_m.color);
                Instantiate(spark, transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }
        }
    }

    public Color StartColor
    {
        set
        {
            var main = spark.main;
            main.startColor = value;
        }
    }
}
