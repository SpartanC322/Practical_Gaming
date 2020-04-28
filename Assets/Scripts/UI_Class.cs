using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Class : MonoBehaviour
{
    Game_Manager myGameManager;
    public CanvasGroup Turn_UI;
    public Button End_Turn;
    int state;

    // Start is called before the first frame update
    void Start()
    {
        myGameManager = FindObjectOfType<Game_Manager>();
        End_Turn.onClick.AddListener(turn_End);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void turn_End()
    {
        if (state == 0)
        {
            state = 1;
            myGameManager.set_Manager_State(state);
        }
        else if (state == 1)
        {
            state = 2;
            myGameManager.set_Manager_State(state);
        }
        else if (state == 2)
        {
            state = 1;
            myGameManager.set_Manager_State(state);
        }

        Debug.Log(state);
    }
}
