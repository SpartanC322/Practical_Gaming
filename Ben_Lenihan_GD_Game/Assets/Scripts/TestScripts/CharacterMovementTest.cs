using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    bool is_idling = true;
    private float current_speed = 1;
    private float turning_speed = 90;
    CameraControl my_camera;
    Animator myAnimation;

    // Start is called before the first frame update
    void Start()
    {
        myAnimation = GetComponent<Animator>();
        my_camera = FindObjectOfType<CameraControl>();

        my_camera.follow(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (should_walk_forward()) walk_forward();
        else
            stop_walking();
        if (should_sprint_forward()) sprint_forward();
        else
            stop_sprinting_forward();
        if (should_turn_left()) turn_left();
        if (should_turn_right()) turn_right();
        if (should_walk_backward()) walk_backward();
        else
            stop_walking_backward();
        if (should_disconnect_camera()) disconnect_camera();
    }

    private void stop_sprinting_forward()
    {
        myAnimation.SetBool("is_sprinting", false);
    }

    private void stop_walking()
    {
        myAnimation.SetBool("is_walking", false);
    }

    private void stop_walking_backward()
    {
        myAnimation.SetBool("is_walking_backward", false);
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
        is_idling = false;
        myAnimation.SetBool("is_walking_backward", true);
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
        is_idling = false;
        myAnimation.SetBool("is_sprinting", true);
        transform.position += current_speed * 2 * transform.forward * Time.deltaTime;
    }

    private void walk_forward()
    {
        is_idling = false;
        myAnimation.SetBool("is_walking", true);
        transform.position += current_speed * transform.forward * Time.deltaTime;
    }

    private bool should_walk_forward()
    {
        return Input.GetKey(KeyCode.W);
    }

  
}
