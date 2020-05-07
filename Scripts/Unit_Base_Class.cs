using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit_Base_Class : MonoBehaviour, Unit_Interface
{
    protected enum Unit_State { Stationary, Moving, Attacking }
    protected Animator my_animator;
    protected Unit_State currently = Unit_State.Stationary;
    protected Vector3 my_starting_position;
    protected Vector3 my_destination;
    protected float timer;
    protected float move_time = 1.5f;
    protected bool player_2;
    protected bool class_Is_Selected = false;
    protected bool has_moved = true;
    protected int health = 100;
    protected int damage;
    protected int distance_can_move;
    protected int attack_range;
    protected string unit_class;
 
    public abstract void Set_Heavy();

    public abstract void Set_Normal();

    public abstract void Set_Ranged();
    
    public abstract void set_Player_2();

    public abstract bool get_Player_2();

    public abstract void set_Health(int new_Health);

    public abstract int get_Health();

    public abstract void has_Moved();

    public abstract int get_Attack_Range();

    public abstract void set_Class_Selected();

    public abstract int get_Damage();

    public abstract string get_Class();

    public abstract int get_Distance_Can_Move();

    public abstract bool is_Class_Selected();

    public abstract void has_Not_Moved();

    public abstract bool has_It_Moved();

    internal abstract void MoveToPosition(Vector3 destination);
  
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

                my_animator.SetBool("is_walking", false);

                break;

            case Unit_State.Attacking:

                break;
        } 
    }
}
