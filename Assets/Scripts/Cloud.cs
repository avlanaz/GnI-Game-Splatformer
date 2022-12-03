using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    public float speed = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(0.07f,0.37f);
    }

    // Update is called once per frame
    void Update()
    {

        if (!UIController.pause)
        {
            this.transform.Translate(Vector3.left * speed);
        }

        
        
        this.transform.Translate(Vector3.left*speed*Time.deltaTime);
        if (this.transform.position.x < -150)
        {
            Destroy(this.gameObject);
        }
    }
}
