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
    private float move_time = 1.5f;
    private bool player_2;
    public bool class_Selected = false;
    private bool has_moved = true;
    private int health = 100;
    public int damage = 10;
    public int distance_can_move = 15;
    public int attack_Range = 3;
    public string unit_class = "Normal";
 

    public void normal_Class()
    {
        //sets stats to normal class stats
        unit_class = "Normal";
        health = 100;
        damage = 10;
        distance_can_move = 10;
        attack_Range = 2;
    }

    public void range_Class()
    {
        //sets stats to range class stats
        unit_class = "Range";
        health = 100;
        damage = 5;
        distance_can_move = 10;
        attack_Range = 5;
    }

    public void heavy_Class()
    {
        //sets stats to heavy class stats
        unit_class = "Heavy";
        health = 150;
        damage = 15;
        distance_can_move = 5;
        attack_Range = 2;
    }
    
    public void set_Player_2()
    {
        player_2 = true;
    }

    public bool get_Player_2()
    {
        return player_2;
    }

    public void set_Health(int new_Health)
    {
        health = new_Health;
    }

    public int get_Health()
    {
        return health;
    }

    public void has_Moved()
    {
        has_moved = true;
    }

    public void has_Not_Moved()
    {
        has_moved = false;
    }

    public bool has_It_Moved()
    {
        return has_moved;
    }
  
    // Start is called before the first frame update
    void Start()
    {
        my_animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(health < 1)
        {
            Destroy(this.gameObject);
        }
        
        switch (currently)
        {
            case Unit_State.Moving:

                transform.position = Vector3.Lerp(my_starting_position, my_destination, timer/move_time);
                timer += Time.deltaTime;
                if (timer > move_time)
                {
                    transform.position = my_destination;
                    currently = Unit_State.Stationary;
                    my_animator.SetBool("is_walking", false);
                    has_Moved();
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
            has_moved = true;
        }
    }
}
