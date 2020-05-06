using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit_Class : Unit_Base_Class
{
    public override void Set_Heavy()
    {
        health = 150;
        damage = 15;
        distance_can_move = 15;
        attack_range = 2;
        unit_class = "Heavy";
    }

    public override void Set_Normal()
    {
        health = 100;
        damage = 10;
        distance_can_move = 15;
        attack_range = 2;
        unit_class = "Normal";
    }

    public override void Set_Ranged()
    {
        health = 80;
        damage = 10;
        distance_can_move = 20;
        attack_range = 6;
        unit_class = "Ranged";
    }

    public override void set_Player_2()
    {
        player_2 = true;
    }

    public override bool get_Player_2()
    {
        return player_2;
    }

    public override void set_Health(int new_Health)
    {
        health = new_Health;
    }

    public override int get_Health()
    {
        return health;
    }

    public override void has_Moved()
    {
        has_moved = true;
    }

    public override void has_Not_Moved()
    {
        has_moved = false;
    }

    public override bool has_It_Moved()
    {
        return has_moved;
    }

    public override int get_Attack_Range()
    {
        return attack_range;
    }

    public override void set_Class_Selected()
    {
        class_Is_Selected = true;
    }

    public override int get_Damage()
    {
        return damage;
    }

    public override string get_Class()
    {
        return unit_class;
    }
    
    public override int get_Distance_Can_Move()
    {
        return distance_can_move;
    }

    public override bool is_Class_Selected()
    {
        return class_Is_Selected;
    }

    internal override void MoveToPosition(Vector3 destination)
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
