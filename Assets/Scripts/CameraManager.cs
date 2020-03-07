using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private float current_speed = 6;
    float camera_horz_angle = 0;
    Vector3 camera_look_direction;

    public float dragSpeed = 2;
    private Vector3 dragOrigin;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (should_move_forward()) move_forward();
        if (should_move_backward()) move_backward();
        if (should_move_left()) move_left();
        if (should_move_right()) move_right();
        if (should_turn_left()) turn_left();
        if (should_turn_right()) turn_right();
        transform.rotation = look_rotation();

        if (should_drag_camera())
        {
            dragOrigin = Input.mousePosition;
            return;
        }

        if (should_drag_camera())
        {
            drag_camera();
        }
    }

    Quaternion look_rotation()
    {
        camera_look_direction = new Vector3(Mathf.Cos(camera_horz_angle), -0.5f, Mathf.Sin(camera_horz_angle));
        return Quaternion.LookRotation(camera_look_direction, Vector3.up);
    }

    private void drag_camera()
    {
        Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - dragOrigin);
        Vector3 move = new Vector3(pos.x * dragSpeed, 0, pos.y * dragSpeed);

        transform.Translate(move, Space.World);
    }

    private bool should_drag_camera()
    {
        return Input.GetMouseButton(2);
    }

    private void move_right()
    {
        transform.position += current_speed * transform.right * Time.deltaTime;
    }

    private bool should_move_right()
    {
        return Input.GetKey(KeyCode.D);
    }

    private void move_left()
    {
        transform.position -= current_speed * transform.right * Time.deltaTime;
    }

    private bool should_move_left()
    {
        return Input.GetKey(KeyCode.A) || (Input.GetMouseButton(0) && Input.GetAxis("Horizontal")<-0.01) ;
    }

    private void move_forward()
    {
        transform.position += current_speed * transform.up * Time.deltaTime;
    }

    private bool should_move_forward()
    {
        return Input.GetKey(KeyCode.W) || (Input.GetAxis("Mouse ScrollWheel") > 0.01f);
    }

    private void move_backward()
    {
        transform.position -= current_speed * transform.forward * Time.deltaTime;
    }

    private bool should_move_backward()
    {
        return Input.GetKey(KeyCode.S) || (Input.GetAxis("Mouse ScrollWheel") <-0.01 );
    }

    private void turn_right()
    {
        camera_horz_angle += 2 * Time.deltaTime;
    }

    private bool should_turn_right()
    {
        return Input.GetKey(KeyCode.Q);
    }

    private void turn_left()
    {
        camera_horz_angle -= 2 * Time.deltaTime;
    }

    private bool should_turn_left()
    {
        return Input.GetKey(KeyCode.E);
    }


}
