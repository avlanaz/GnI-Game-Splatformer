using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudGenerate : MonoBehaviour
{
    public GameObject cloudA;
    public GameObject cloudB;

    public float counter = 0.0f;

    public float startX = 300f;

    public float next=3f;

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;
        if (counter >= next)
        {
            generateCloud();
            counter = 0;
            next = Random.Range(5f,7f);
        }
    }


    void generateCloud()
    {
        GameObject target;
        if (Random.Range(0f, 1f) >= 0.5f)
        {
            target = cloudA;
            
        }
        else
        {
            target = cloudB;
        }
        var c = Instantiate(target);
        c.transform.position = new Vector3(startX,Random.Range(17f,50f) , Random.Range(20f, 110f));


    }

}
