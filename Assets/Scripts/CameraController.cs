using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform startingPos;
    public Transform zoomPos;
    public Transform target;
    public GameObject gameCam;
    public Transform topLeftEnd;
    public Transform bottomRightEnd;

    private const float initWaitTime = 1.0f;
    private Vector3 newPos;
    private float initTimer = 0f;
    private float actualZ;

    // Start is called before the first frame update
    void Start()
    {
        actualZ = gameCam.transform.position.z;
        if (startingPos != null) {
            gameCam.transform.position = startingPos.position;
            while (initTimer < initWaitTime) {
                initTimer += Time.deltaTime;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Check if Z key is pressed => Zoom
        if (Input.GetKey(KeyCode.Tab) && zoomPos != null) {
            newPos = zoomPos.position;
            return;
        }

        Vector3 pos = gameCam.transform.position;
        Vector3 targetPos = target.position;
        float newX, newY;
        newX = target.position.x;
        newY = target.position.y;

        if (targetPos.y < -255) {
            
        } else {

            // Bound the x and y position of the camera
            if (targetPos.x < topLeftEnd.position.x) {
                newX = topLeftEnd.position.x;
            } else if (targetPos.x > bottomRightEnd.position.x) {
                newX = bottomRightEnd.position.x;
            }

            if (targetPos.y > topLeftEnd.position.y) {
                newY = topLeftEnd.position.y;
            } else if (targetPos.y < bottomRightEnd.position.y) {
                newY = bottomRightEnd.position.y;
            }
            newPos = new Vector3(newX, newY, actualZ);

        }
    }

    private void LateUpdate() {
        gameCam.transform.position = newPos;
    }
}
