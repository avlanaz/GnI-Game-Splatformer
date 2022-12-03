using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dropdown : MonoBehaviour
{
    // Start is called before the first frame update
    public UIController controller;
    void Start()
    {
        
    }

    // Update is called once per frame
    public void handleInputData(int val) {
        controller.clickLevel(val);
    }
}
