using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    Game_Board the_board;
    Unit_Base_Class currently_selected_unit;
    float distanceToDestination;

    // Start is called before the first frame update
    void Start()
    {
        currently_selected_unit = FindObjectOfType<Unit_Base_Class>();
        the_board = new Game_Board();
    }

    // Update is called once per frame
    void Update()
    {
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

                Board_Position selected_cell = hit.transform.GetComponent<Board_Position>();
                if (selected_cell)
                {
                    distanceToDestination = Vector3.Distance(selected_cell.transform.position, currently_selected_unit.transform.position);
                    Debug.Log("Distance: " + distanceToDestination);

                    if (distanceToDestination <= 10)
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
    }
}
