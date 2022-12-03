using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelControl : MonoBehaviour
{

    bool aimingLEFT = false;
    int rotateSpeed = 20;
    public Transform firePoint;

    public Transform body;
    public Transform arms;

    

    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale != 0)
        {

            rotateBody();
            followArm();
        }
    }

    private void followArm()
    {
        Vector3 screenPoint = UnityEngine.Camera.main.WorldToScreenPoint(body.position);
        Vector2 direction = (Vector2)(Input.mousePosition - screenPoint);
        direction.Normalize();
        if (direction.y<0)
        {
            arms.rotation = Quaternion.Euler(new Vector3(0, 0, -Vector2.Angle(Vector2.right, direction)));
        }
        else
        {
            arms.rotation = Quaternion.Euler(new Vector3(0, 0, Vector2.Angle(Vector2.right, direction)));
        }
        

    }

    private void rotateBody()
    {
        Vector3 screenPoint = UnityEngine.Camera.main.WorldToScreenPoint(body.position);
        Vector2 direction = (Vector2)(Input.mousePosition - screenPoint);
        Vector2 right = ((Vector2)body.position + Vector2.right - (Vector2)body.position);

        if (Vector2.Angle(right, direction) >= 90)
        {
            // turnLeft
            aimingLEFT = true;
        }
        else
        {
            // turnRight
            aimingLEFT = false;
        }


        if (aimingLEFT && body.rotation.eulerAngles.y < 180)
        {
            body.Rotate(Vector3.up * rotateSpeed);
            if (body.rotation.eulerAngles.y > 180)
            {
                body.localRotation = Quaternion.Euler(0, 180, 0);
            }
        }
        else if (!aimingLEFT && body.rotation.eulerAngles.y > 0)
        {
            body.Rotate(Vector3.down * rotateSpeed);
            if (body.rotation.eulerAngles.y < 0)
            {
                body.localRotation = Quaternion.Euler(0, 0, 0);
            }
        }
    }
}
