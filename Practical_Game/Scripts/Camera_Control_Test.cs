using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Control_Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    internal void follow(Camera_Manager camera_Manager)
    {
        transform.parent = camera_Manager.transform;
    }
}
