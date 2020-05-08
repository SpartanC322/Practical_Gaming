using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    protected Game_Board the_board;
    protected Unit_Class currently_selected_unit;
    protected Unit_Class[] all_units;
    protected List<GameObject> player_1_Units = new List<GameObject>();
    protected List<GameObject> player_2_Units = new List<GameObject>();
    protected enum Manager_States { Setting_Up, Player_1_Turn, Player_2_Turn }
    protected Manager_States current = Manager_States.Setting_Up;
    protected Ray ray;
    protected RaycastHit hit;
    protected Unit_Class target_Unit;
    protected float distance_To_Destination;
    protected float distance_To_Target;
    protected int damage_Modifier;
    protected bool reset = false;
    protected ClassSelectUI myClassSelectUI;
    protected UI_Class ui_Class;
    protected int state = 0;
    protected int number_of_units_wanted = 5;
    protected bool has_been_setup = false;
    protected bool is_player_2;
    protected Animator Unit_Animation;


    // Start is called before the first frame update
    void Start()
    {
        ui_Class = FindObjectOfType<UI_Class>();
        currently_selected_unit = FindObjectOfType<Unit_Class>();
        the_board = new Game_Board();

        myClassSelectUI = FindObjectOfType<ClassSelectUI>();
    }

    // Update is called once per frame
    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        switch (current)
        {
            case Manager_States.Setting_Up:

                if (has_been_setup == false)
                {
                    setup_Player_1();
                    setup_Player_2();
                    has_been_setup = true;
                }
                Debug.Log(current);

                all_units = FindObjectsOfType<Unit_Class>();

                reset = true;

                reset_All_Units();

                state = 1;

                set_Manager_State(state);

                break;

            case Manager_States.Player_1_Turn:

                Debug.Log(current);

                break;

            case Manager_States.Player_2_Turn:

                Debug.Log(current);

                break;
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (currently_selected_unit.is_Class_Selected() == false)
            {
                if ((get_state() == 1) && (currently_selected_unit.get_Player_2() == false))
                {
                    myClassSelectUI = FindObjectOfType<ClassSelectUI>();

                    myClassSelectUI.showUI();
                }
                if ((get_state() == 2 && (currently_selected_unit.get_Player_2() == true)))
                {
                    myClassSelectUI = FindObjectOfType<ClassSelectUI>();

                    myClassSelectUI.showUI();
                }
            }

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                Unit_Class unit_selected = hit.transform.GetComponent<Unit_Class>();
                if (unit_selected)
                {
                    if (currently_selected_unit.get_Player_2() == false && state == 1)
                    {
                        currently_selected_unit = unit_selected;
                    }
                    if (currently_selected_unit.get_Player_2() == true && state == 2)
                    {
                        currently_selected_unit = unit_selected;
                    }
                }

                Board_Position selected_cell = hit.transform.GetComponent<Board_Position>();
                if (selected_cell)
                {
                    distance_To_Destination = Vector3.Distance(selected_cell.transform.position, currently_selected_unit.transform.position);
                    Debug.Log("Distance: " + distance_To_Destination);

                    if ((distance_To_Destination <= currently_selected_unit.get_Distance_Can_Move()) && currently_selected_unit.has_It_Moved() == false)
                    {
                        currently_selected_unit.MoveToPosition(selected_cell.unit_position());
                        selected_cell.highlight();
                        currently_selected_unit.has_Moved();
                    }

                    else
                    {
                        Debug.Log("Too far");
                    }
                }
            }
        }

        if (Physics.Raycast(ray, out hit))
        {
            target_Unit = hit.collider.GetComponent<Unit_Class>();

            if (Input.GetMouseButtonDown(1))
            //MouseButton 1 is a right click
            {
                if (target_Unit.GetComponent<Unit_Class>() != null)
                {
                    damage_Modifier = Random.Range(5, 10);
                    distance_To_Target = Vector3.Distance(currently_selected_unit.transform.position, target_Unit.transform.position);

                    if (distance_To_Target <= currently_selected_unit.get_Attack_Range())
                    {
                        if (currently_selected_unit.get_Class() == "Range")
                        {
                            if (distance_To_Target < 2)
                            {
                                print("Ranger is too close");
                            }

                            else
                            {
                                target_Unit.set_Health(-(currently_selected_unit.get_Damage() + damage_Modifier));
                                print("That's a lot of damage!");
                            }
                        }

                        else
                        {
                            //Class is not range
                            target_Unit.set_Health(-(currently_selected_unit.get_Damage() + damage_Modifier));
                            print("That's a lot of damage!");
                        }
                    }

                    else
                    {
                        print("Target too far");
                    }
                }
            }
        }
    }

    public void set_Manager_State(int state)
    {
        if (state == 0)
        {
            current = Manager_States.Setting_Up;
        }
        else if (state == 1)
        {
            current = Manager_States.Player_1_Turn;
        }
        else if (state == 2)
        {
            current = Manager_States.Player_2_Turn;
        }
    }

    public void reset_All_Units()
    {
        if (reset == true)
        {
            foreach (Unit_Class unit in all_units)
            {
                unit.has_Not_Moved();
            }
            reset = false;
        }
    }

    public void set_state(int new_state)
    {
        state = new_state;
    }

    public int get_state()
    {
        return state;
    }

    public void choseNormalClass()
    {
        currently_selected_unit.Set_Normal();

        currently_selected_unit.set_Class_Selected();
    }

    public void choseRangeClass()
    {
        currently_selected_unit.Set_Ranged();

        currently_selected_unit.set_Class_Selected();
    }

    public void choseHeavyClass()
    {
        currently_selected_unit.Set_Heavy();

        currently_selected_unit.set_Class_Selected();
    }

    public void setup_Player_1()
    {
        for (int i = 0; i < (number_of_units_wanted - 2); i++)
        {
            is_player_2 = false;
            GameObject player_1_Unit = Instantiate(Resources.Load("Prefabs/Unit"), new Vector3(i + 2, 0.5f, 0), Quaternion.identity) as GameObject;
            player_1_Unit.AddComponent<Unit_Class>();
            player_1_Unit.GetComponent<Unit_Class>().set_Player_2(is_player_2);
            Unit_Animation = Resources.Load("Unit_Animation") as Animator;
            Unit_Animation = player_1_Unit.AddComponent<Animator>();
            player_1_Units.Add(player_1_Unit);
        }
    }

    public void setup_Player_2()
    {
        for (int i = 0; i < number_of_units_wanted; i++)
        {
            is_player_2 = true;
            GameObject player_2_Unit = Instantiate(Resources.Load("Prefabs/Unit"), new Vector3((the_board.get_Length() - 1) - i, 0.5f, (the_board.get_Width() - 1)), Quaternion.identity) as GameObject;
            player_2_Unit.AddComponent<Unit_Class>();
            player_2_Unit.GetComponent<Unit_Class>().set_Player_2(is_player_2);
            Unit_Animation = Resources.Load("Unit_Animation") as Animator;
            Unit_Animation = player_2_Unit.AddComponent<Animator>();
            player_2_Unit.transform.Rotate(0f, 180f, 0f);
            player_2_Units.Add(player_2_Unit);
        }
    }
}