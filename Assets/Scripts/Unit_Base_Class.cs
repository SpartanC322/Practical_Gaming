using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit_Base_Class : MonoBehaviour
{
    enum Unit_State { Stationary, Moving, Attacking }
    Animator my_animator;
    Unit_State currently = Unit_State.Stationary;
    private Vector3 my_starting_position;
    private Vector3 my_destination;
    private float timer;
    private float MOVE_TIME = 1.5f;

    public int health = 100;
    public string unitClass = "Normal";
    public int damage = 10;
    public int distance_Can_Move = 15;
    public int attackRange = 3;

    public bool class_Selected = false;

    public void normal_Class()
    {
        //sets stats to normal class stats
        unitClass = "Normal";
        health = 100;
        damage = 10;
        distance_Can_Move = 10;
        attackRange = 2;

    }

    public void range_Class()
    {
        //sets stats to range class stats
        unitClass = "Range";
        health = 100;
        damage = 5;
        distance_Can_Move = 10;
        attackRange = 5;

    }

    public void heavy_Class()
    {
        //sets stats to heavy class stats
        unitClass = "Heavy";
        health = 150;
        damage = 15;
        distance_Can_Move = 5;
        attackRange = 2;
    }

  
    // Start is called before the first frame update
    void Start()
    {
        my_animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if(health < 1)//RM
        {
            Destroy(this.gameObject);
        }
        

        switch (currently)
        {
            case Unit_State.Moving:

                transform.position = Vector3.Lerp(my_starting_position, my_destination, timer/MOVE_TIME);
                timer += Time.deltaTime;
                if (timer > MOVE_TIME)
                {
                    transform.position = my_destination;
                    currently = Unit_State.Stationary;
                    my_animator.SetBool("is_walking", false);
                }
                break;

            case Unit_State.Stationary:

                break;

            case Unit_State.Attacking:

                break;
        } 
    }

    internal void MoveToPosition(Vector3 destination)
    {
        if (currently == Unit_State.Stationary)
        {
            currently = Unit_State.Moving;
            my_animator.SetBool("is_walking", true);
            my_starting_position = transform.position;
            transform.LookAt(destination);
            my_destination = destination;
            timer = 0f;
        }
    }
}
