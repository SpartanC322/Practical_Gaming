using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    Game_Board the_board;
    Unit_Base_Class currently_selected_unit;
    Ray ray;
    RaycastHit hit;
    Unit_Base_Class target_Unit;
    float distanceToDestination;
    float distance_To_Target;
    int damage_Modifier;
    Class_Select_UI my_Class_Select_UI;

    // Start is called before the first frame update
    void Start()
    {
        currently_selected_unit = FindObjectOfType<Unit_Base_Class>();
        the_board = new Game_Board();

        my_Class_Select_UI = FindObjectOfType<Class_Select_UI>();
    }

    // Update is called once per frame
    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        if (Input.GetMouseButtonUp(0))
        {

            if(!currently_selected_unit.class_Selected)
            {
                my_Class_Select_UI = FindObjectOfType<Class_Select_UI>();

                my_Class_Select_UI.show_UI();
            }

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                Unit_Base_Class unit_selected = hit.transform.GetComponent<Unit_Base_Class>();
                if (unit_selected)
                {
                    currently_selected_unit = unit_selected;
                }

                Board_Position selected_cell =  hit.transform.GetComponent<Board_Position>();
                if (selected_cell)
                {
                    distanceToDestination = Vector3.Distance(selected_cell.transform.position, currently_selected_unit.transform.position);
                    Debug.Log("Distance: " + distanceToDestination);

                    if (distanceToDestination <= currently_selected_unit.distance_Can_Move)
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
            target_Unit = hit.collider.GetComponent<Unit_Base_Class>();

            if (Input.GetMouseButtonDown(1))
                //MouseButton 1 is a right click
            {
                if(target_Unit.GetComponent<Unit_Base_Class>() != null)
                {
                    damage_Modifier = Random.Range(5, 10);
                    distance_To_Target = Vector3.Distance(currently_selected_unit.transform.position, target_Unit.transform.position);

                    if(distance_To_Target <= currently_selected_unit.attackRange)
                    {
                        if(currently_selected_unit.unitClass == "Range")
                        {
                            if(distance_To_Target < 2)
                            {
                                print("Ranger is too close");
                            }

                            else
                            {
                                target_Unit.health -= currently_selected_unit.damage + damage_Modifier;
                                print("That's a lot of damage!");
                            }
                        }//end of if class is Range

                        else
                        {
                            //Class is not range
                            target_Unit.health -= currently_selected_unit.damage + damage_Modifier;
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


    public void chose_Normal_Class()
    {
        currently_selected_unit.normal_Class();

        currently_selected_unit.class_Selected = true;
    }

    public void chose_Range_Class()
    {
        currently_selected_unit.range_Class();

        currently_selected_unit.class_Selected = true;
    }

    public void chose_Heavy_Class()
    {
        currently_selected_unit.heavy_Class();

        currently_selected_unit.class_Selected = true;
    }
}
