using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Class : MonoBehaviour
{
    Game_Manager manager;
    public CanvasGroup Turn_UI;
    public Button End_Turn;

    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<Game_Manager>();
        End_Turn.onClick.AddListener(turn_End);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void turn_End()
    {
        if (manager.get_state() == 1)
        {
            manager.set_state(2);
            manager.set_Manager_State(manager.get_state());
        }
        else if (manager.get_state() == 2)
        {
            manager.set_state(0);
            manager.set_Manager_State(manager.get_state());
        }
    }
}
