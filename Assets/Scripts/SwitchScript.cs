using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchScript : MonoBehaviour
{
    private bool switchOn = false;
    public GameObject[] objects;
    public bool[] startOff;
    public ParticleSystem destroyEffect;
    
    public GameObject thePanel;
    public GameObject leverBone;
    // Start is called before the first frame update
    void Start()
    {
        // Ensure array is of the same size as object array
        if (startOff.Length == 0)
        {
            startOff = new bool[objects.Length];
            for (int i = 0; i < startOff.Length; i++)
            {
                startOff[i] = false;
            }
        }
        else if (startOff.Length < objects.Length) {
            bool[] originalArr = startOff;
            startOff = new bool[objects.Length];
            int i = 0;
            while (i < originalArr.Length) {
                startOff[i] = originalArr[i];
                i++;
            }
            while (i < objects.Length) {
                startOff[i] = false;
                i++;
            }
        }
        
        int oIndex = 0;
        foreach (GameObject o in objects) {
            DissolveController controler = o.AddComponent<DissolveController>();
            controler.destroyEffect = this.destroyEffect;
            if (startOff[oIndex])
            {
                o.SetActive(false);
            }
            oIndex += 1;
        }
        if (thePanel != null)
        {
            thePanel.gameObject.GetComponent<Renderer>().material.color = new Color(255.0f / 255.0f, 165.0f / 255.0f, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerMove.reset) {
            if (switchOn)
            {
                leverBone.transform.Rotate(-168.45f, 0, 0);
            }
            switchOn = false;
            flipSwitch();
            if (leverBone != null) {
                
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "redBullet" || other.tag == "blueBullet" || other.tag == "clearBullet")
        {
            switchOn = !switchOn;
            flipSwitch();
        }
        
    }
    // flips the switch
    private void flipSwitch() {
        int oIndex = 0;
        foreach (GameObject o in objects)
        {

            foreach (Transform child in o.transform)
            {
                if (child.gameObject.CompareTag("Player") && switchOn)
                {
                    child.SetParent(null);
                }
            }
            if (!startOff[oIndex])
            {
                o.SetActive(!switchOn);
            }
            else
            {
                o.SetActive(switchOn);
            }
            oIndex += 1;
        }
        if (thePanel != null)
        {
            if (switchOn)
            {
                if (leverBone != null && !PlayerMove.reset)
                {
                    leverBone.transform.Rotate(168.45f, 0, 0);
                }
                thePanel.gameObject.GetComponent<Renderer>().material.color = Color.green;
            }
            else
            {
                if (leverBone != null && !PlayerMove.reset)
                {
                    leverBone.transform.Rotate(-168.45f, 0, 0);
                }
                thePanel.gameObject.GetComponent<Renderer>().material.color = new Color(255.0f / 255.0f, 165.0f / 255.0f, 0);
            }
        }
    }
}
