using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCube : MonoBehaviour
{


    public bool credit;

    public bool halt = false;
    public ParticleSystem dead;
    public GameObject text;

    private void OnTriggerEnter(Collider other)
    {
        //DissolveController controller = this.gameObject.AddComponent<DissolveController>();
        //controller.destroyEffect = this.dead;
        if (credit)
        {
            text.SetActive(false);
            Destroy(this.gameObject);
            return;
        }

        if (!halt&&!other.CompareTag("Player"))
        {
            ChangeColor();
            Instantiate(dead, transform.position, Quaternion.identity);
            if (this.gameObject.name == "levels") {
                Invoke("shooted", 0f);

            }else 
            {
                Invoke("shooted", 1f);
            }
            halt = true;
            text.SetActive(false);
            GetComponent<MeshRenderer>().enabled = false;
        }


    }

    public void setLevelCube()
    {
        if (halt)
        {

        }

        text.SetActive(true);
        GetComponent<MeshRenderer>().enabled = true;
    }

    public void shooted()
    {
        halt = false;


            if (this.gameObject.name == "new")
            {
                GameObject.Find("Canvas").GetComponent<UIController>().clickLevel(0);

            }
            else if (this.gameObject.name == "levels")
            {
                GameObject.Find("Canvas").GetComponent<UIController>().clickSelectLevel();

            }
            else if (this.gameObject.name == "quit")
            {

                Application.Quit();

            }
        }
    private void ChangeColor()
    {
        for (int i = 0; i < dead.transform.childCount; i++)
        {
            var currentmain = dead.transform.GetChild(i).GetComponent<ParticleSystem>().main;
            currentmain.startColor = this.gameObject.GetComponent<Renderer>().material.color;
            var currnetShape = dead.transform.GetChild(i).GetComponent<ParticleSystem>().shape;
            currnetShape.scale = this.transform.localScale;
        }
    }
    

}
