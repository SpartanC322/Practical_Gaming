using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Movement : MonoBehaviour
{
    private float current_speed = 1;
    private float turning_speed = 90;
    private Camera_Control_Test my_camera;


    // Start is called before the first frame update
    void Start()
    {
        //my_camera = FindObjectOfType<Camera_Control_Test>();

       // my_camera.follow(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (should_walk_forward()) walk_forward();
        if (should_sprint_forward()) sprint_forward();
        if (should_turn_left()) turn_left();
        if (should_turn_right()) turn_right();
        if (should_walk_backward()) walk_backward();
        if (should_disconnect_camera()) disconnect_camera();
    }

    private bool should_disconnect_camera()
    {
        return Input.GetKey(KeyCode.Space);
    }
    private void disconnect_camera()
    {
        //Make code to check if connected first
        transform.parent = null;
    }

    private void turn_right()
    {
        transform.Rotate(Vector3.up, -turning_speed * Time.deltaTime);
    }

    private bool should_turn_right()
    {
        return Input.GetKey(KeyCode.A);
    }

    private void turn_left()
    {
        transform.Rotate(Vector3.up, turning_speed * Time.deltaTime);
    }

    private bool should_turn_left()
    {
        return Input.GetKey(KeyCode.D);
    }

    private void walk_backward()
    {
        transform.position -= current_speed * transform.forward * Time.deltaTime;
    }

    private bool should_walk_backward()
    {
        return Input.GetKey(KeyCode.S);
    }

    private bool should_sprint_forward()
    {
        return Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W);
    }

    private void sprint_forward()
    {
        transform.position += current_speed * 2 * transform.forward * Time.deltaTime;
    }

    private void walk_forward()
    {
        transform.position += current_speed * transform.forward * Time.deltaTime;
    }

    private bool should_walk_forward()
    {
        return Input.GetKey(KeyCode.W);
    }


}
