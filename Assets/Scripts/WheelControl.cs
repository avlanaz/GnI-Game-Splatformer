using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelControl : MonoBehaviour
{
    private Animator animate;
    // Start is called before the first frame update
    void Start()
    {
        animate = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        animate.SetFloat("direction", h);
        if (h == 0f) {
            animate.SetBool("stop", true);
        }else{
            animate.SetBool("stop", false);
        }
    }
}
