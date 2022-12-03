using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    public bool startAsRed;
    public ParticleSystem redPlatformParticles;
    public ParticleSystem bluePlatformParticles;
    private ParticleSystem redPlatformUse;
    private ParticleSystem bluePlatformUse;
    public ParticleSystem destroyEffect;
    // Start is called before the first frame update
    void Start()
    {
        if (this.gameObject.GetComponent<Collider>() == null)
        {
            this.gameObject.AddComponent<Collider>();
        }
        if (this.gameObject.GetComponent<Rigidbody>() == null)
        {
            this.gameObject.AddComponent<Rigidbody>().isKinematic = true;
        }
        redPlatformUse = Instantiate(redPlatformParticles, this.transform);
        redPlatformUse.transform.position = this.transform.position;
        bluePlatformUse = Instantiate(bluePlatformParticles, this.transform);
        bluePlatformUse.transform.position = this.transform.position;
        if(startAsRed) {
            makeRed();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerMove.reset)
        {
            this.gameObject.GetComponent<Renderer>().material.color = Color.white;
            this.gameObject.tag = "whiteObject";
            if (startAsRed) {
                makeRed();
            }
        }
        if (!this.CompareTag("redObject") && redPlatformUse != null && !redPlatformUse.isStopped) {
            StopParticles();
        }
        if (!this.CompareTag("blueObject") && bluePlatformUse != null && !bluePlatformUse.isStopped) {
            bluePlatformUse.Stop();
        }

    }

    public void makeRed() {
        
        this.gameObject.GetComponent<Renderer>().material.color = Color.red;
        this.gameObject.tag = "redObject";
        if (redPlatformUse != null && !redPlatformUse.isPlaying)
        {
            CreateParticles();
        }
    }

    public void makeBlue() {
        this.gameObject.GetComponent<Renderer>().material.color = Color.blue;
        this.gameObject.tag = "blueObject";
        if (bluePlatformUse != null && !bluePlatformUse.isPlaying)
        {
            CreateBlueParticles();
        }
    }

    public void makeWhite() {
        this.gameObject.GetComponent<Renderer>().material.color = Color.white;
        this.gameObject.tag = "whiteObject";
    }

    void CreateParticles() {
        redPlatformUse.Play();
    }
    void CreateBlueParticles() {
        bluePlatformUse.Play();
    }

    void StopParticles() {
        redPlatformUse.Stop();
    }
    

    
}
