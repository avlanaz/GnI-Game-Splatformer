using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Vector3 localAnchorPoint;
    public float movementSpeed;
    public float initialDelay=0;
    public float interval=0;
    public bool oneWay = false;
    public bool playerTriggered = false;

    // private attributes
    private Vector3 direction;
    private GameObject parentTemp;
    private bool inInitialDelay;
    private bool inDelay;
    private bool oneWayComplete;
    private float initialCountdown;
    private float delayCountdown;
    private bool beenTriggered = true;
    

    // Start is called before the first frame update
    void Start()
    {
        direction = localAnchorPoint.normalized;
        parentTemp = new GameObject("movingPlatformParent");
        parentTemp.transform.position = this.transform.position;
        this.transform.SetParent(parentTemp.transform);
        inDelay = false;
        inInitialDelay = true;
        initialCountdown = initialDelay;
        oneWayComplete = false;
        beenTriggered = !playerTriggered;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!inDelay && !inInitialDelay && beenTriggered)
        {
            if (transform.localPosition.magnitude >= localAnchorPoint.magnitude && Vector3.Dot(transform.localPosition, localAnchorPoint) > 0)
            {
                direction = -localAnchorPoint.normalized;
                if (oneWay) {
                    oneWayComplete = true;
                }
            }
            else if (Vector3.Dot(transform.localPosition, localAnchorPoint) < 0)
            {
                direction = localAnchorPoint.normalized;
                inDelay = true;
                delayCountdown = interval;
            }
            if (!oneWayComplete)
            {
                transform.localPosition += direction * Time.deltaTime * movementSpeed;
            }


        }
        else if (inInitialDelay && beenTriggered)
        {
            initialCountdown -= Time.deltaTime;
            if (initialCountdown < 0)
            {
                inInitialDelay = false;
            }
        }
        else if (inDelay && beenTriggered) {
            delayCountdown -= Time.deltaTime;
            if (delayCountdown < 0) {
                inDelay = false;
            }
        }

        // reset code
        if (PlayerMove.reset)
        {
            transform.position = this.transform.parent.position;
            direction = localAnchorPoint.normalized;
            inDelay = false;
            inInitialDelay = true;
            oneWayComplete = false;
            initialCountdown = initialDelay;
            beenTriggered = !playerTriggered;
            foreach (Transform child in this.transform)
            {
                if (child.gameObject.CompareTag("Player"))
                {
                    child.SetParent(null);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) {
            other.gameObject.transform.SetParent(this.transform);
            beenTriggered = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.transform.SetParent(null);
        }
    }
}
