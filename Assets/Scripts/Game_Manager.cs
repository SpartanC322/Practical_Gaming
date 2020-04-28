using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    Game_Board the_board;
    Unit_Base_Class currently_selected_unit;
    enum Manager_States { Setting_Up, Player_1_Turn, Player_2_Turn }
    Manager_States current = Manager_States.Player_1_Turn;
    Ray ray;
    RaycastHit hit;
    Unit_Base_Class targetUnit;
    float distanceToDestination;
    float distanceToTarget;
    int damageModifier;
    ClassSelectUI myClassSelectUI;
    UI_Class ui_Class;
    int state = 0;

    public void set_Manager_State(int state)
    {
        if (state == 1)
        {
            current = Manager_States.Player_1_Turn;
        }
        if (state == 2)
        {
            current = Manager_States.Player_2_Turn;
        }
        Debug.Log(current);
    }

    // Start is called before the first frame update
    void Start()
    {
        ui_Class = FindObjectOfType<UI_Class>();
        currently_selected_unit = FindObjectOfType<Unit_Base_Class>();
        the_board = new Game_Board();

        myClassSelectUI = FindObjectOfType<ClassSelectUI>();
    }

    // Update is called once per frame
    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        switch(current)
        {
            case Manager_States.Setting_Up:

                state = 0;

                break;

            case Manager_States.Player_1_Turn:

                state = 1;

                break;

            case Manager_States.Player_2_Turn:

                state = 2;

                break;
        }
        if (Input.GetMouseButtonUp(0))
        {

            if(!currently_selected_unit.classSelected)
            {
                myClassSelectUI = FindObjectOfType<ClassSelectUI>();

                myClassSelectUI.showUI();


            }

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                Unit_Base_Class unit_selected = hit.transform.GetComponent<Unit_Base_Class>();
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

                Board_Position selected_cell =  hit.transform.GetComponent<Board_Position>();
                if (selected_cell)
                {
                    distanceToDestination = Vector3.Distance(selected_cell.transform.position, currently_selected_unit.transform.position);
                    Debug.Log("Distance: " + distanceToDestination);

                    if (distanceToDestination <= currently_selected_unit.distanceCanMove)
                    {
                        currently_selected_unit.MoveToPosition(selected_cell.unit_position());
                        selected_cell.highlight();
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
            targetUnit = hit.collider.GetComponent<Unit_Base_Class>();

            if (Input.GetMouseButtonDown(1))
                //MouseButton 1 is a right click
            {
                if(targetUnit.GetComponent<Unit_Base_Class>() != null)
                {
                    damageModifier = Random.Range(5, 10);
                    distanceToTarget = Vector3.Distance(currently_selected_unit.transform.position, targetUnit.transform.position);

                    if(distanceToTarget <= currently_selected_unit.attackRange)
                    {
                        if(currently_selected_unit.unitClass == "Range")
                        {
                            if(distanceToTarget < 2)
                            {
                                print("Ranger is too close");
                            }

                            else
                            {
                                targetUnit.health -= currently_selected_unit.damage + damageModifier;
                                print("That's a lot of damage!");
                            }
                        }

                        else
                        {
                            //Class is not range
                            targetUnit.health -= currently_selected_unit.damage + damageModifier;
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


    public void choseNormalClass()
    {
        currently_selected_unit.normal_Class();

        currently_selected_unit.classSelected = true;
    }

    public void choseRangeClass()
    {
        currently_selected_unit.range_Class();

        currently_selected_unit.classSelected = true;
    }

    public void choseHeavyClass()
    {
        currently_selected_unit.heavy_Class();

        currently_selected_unit.classSelected = true;
    }
}
