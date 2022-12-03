using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public enum inColor
{
    red,
    blue,
    white
}

public class Shoot : MonoBehaviour
{
    public Transform firepoint;
    public GameObject bullet;

    private int bullet_speed = 3000;

    inColor bullet_color = inColor.red;

    

    public Material red;
    public Material blue;
    public Material white;

    public float shootCount = 0.5f;
    public float shootRate = 0.5f;
    //shoot audio
    public AudioSource shootSound;
    // Start is called before the first frame update



    void Start()
    {
    }

    public inColor nowC()
    {
        return bullet_color;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerMove.isDead) {
            return;
        }
        shootCount += Time.deltaTime;

         if (Input.GetButtonDown("Fire1")&&!UIController.pause&& shootCount > shootRate&& EventSystem.current.IsPointerOverGameObject()==false)
        {
            shootCount = 0;
            Vector3 screenPoint = UnityEngine.Camera.main.WorldToScreenPoint(firepoint.position);
            Vector2 direction = (Vector2)(Input.mousePosition- screenPoint);
            direction.Normalize();
            var e = Instantiate(bullet, firepoint.position, firepoint.rotation);
            e.transform.rotation = Quaternion.LookRotation(new Vector2(-direction.y, direction.x));
            e.GetComponent<Rigidbody>().AddForce(direction * bullet_speed);
            //play the shoot sound
            shootSound.volume = PlayerPrefs.GetFloat("SFX");
            shootSound.Play();

            // change its color depends on colors of bullet (bullet's tag)
            switch (bullet_color)
            {
                case inColor.red:
                    e.transform.GetComponent<Renderer>().material = red;
                    e.tag = "redBullet";
                    break;
                case inColor.blue:
                    e.transform.GetComponent<Renderer>().material = blue;
                    e.tag = "blueBullet";
                    break;
                case inColor.white:
                    e.transform.GetComponent<Renderer>().material = white;
                    e.tag = "clearBullet";
                    break;
                default: break;

            }

        }

        // 1-2 switch firing color
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            
            bullet_color = inColor.red;

        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            
            bullet_color = inColor.blue;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            
            bullet_color = inColor.white;
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0f) // forward
        {
            if(bullet_color == inColor.red)
            {
                bullet_color = inColor.blue;
            }else if(bullet_color == inColor.blue)
            {
                bullet_color = inColor.white;
            }
            else if (bullet_color == inColor.white)
            {
                bullet_color = inColor.red;
            }

        }
        else if (Input.GetAxis("Mouse ScrollWheel") > 0f) // backwards
        {
            if (bullet_color == inColor.red)
            {
                bullet_color = inColor.white;
            }
            else if (bullet_color == inColor.blue)
            {
                bullet_color = inColor.red;
            }
            else if (bullet_color == inColor.white)
            {
                bullet_color = inColor.blue;
            }
        }

    }
}