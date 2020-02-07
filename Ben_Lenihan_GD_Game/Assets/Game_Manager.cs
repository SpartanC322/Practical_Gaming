using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    Unit_Base_Class currently_selected_unit;
    // Start is called before the first frame update
    void Start()
    {
        currently_selected_unit = FindObjectOfType<Unit_Base_Class>(); 

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
                if (currently_selected_unit) currently_selected_unit.MoveToPosition(hit.point);
            }
        }


    }
}
