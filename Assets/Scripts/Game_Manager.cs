using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    GameBoard the_board;
    Unit_Base_Class currently_selected_unit;
    // Start is called before the first frame update
    void Start()
    {
        currently_selected_unit = FindObjectOfType<Unit_Base_Class>();
        the_board = new GameBoard();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
               BoardPosition selected_cell =  hit.transform.GetComponent<BoardPosition>();
                if (selected_cell)
                {
                    currently_selected_unit.MoveToPosition(selected_cell.unit_position());
                    selected_cell.highlight();

                }
                
            }
        }
    }
}
