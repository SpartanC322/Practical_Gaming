using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    Game_Board the_board;
    Unit_Base_Class currently_selected_unit;
    float distanceToDestination;
    Ray ray;
    RaycastHit hit;
    Unit_Base_Class targetUnit;
    float distanceToTarget;
    int damageModifier; //RM

    // Start is called before the first frame update
    void Start()
    {
        currently_selected_unit = FindObjectOfType<Unit_Base_Class>();
        the_board = new Game_Board();
    }

    // Update is called once per frame
    void Update()
    {

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);//RM
        

        if (Input.GetMouseButtonUp(0))
        {
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
        }//end of input.getMouseButtonUP()

        if (Physics.Raycast(ray, out hit))//Lines 65 - 102 added by RM
        {
            targetUnit = hit.collider.GetComponent<Unit_Base_Class>();
            //print(targetUnit);

            if (Input.GetMouseButtonDown(1))//1 = right click
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
                        }//if class is Range

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
                }//end of targetUnit exists
            }//end of mouse right click
        }//end of raycast check 
    }
}
