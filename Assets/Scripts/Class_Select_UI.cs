using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//RM, make sure to add this otherwise you'll get an error when trying to use some of the UI code. 

public class Class_Select_UI : MonoBehaviour
{
    public CanvasGroup select_Class_UI;
    public Button normal_Class_Btn;
    public Button range_Class_Btn;
    public Button heavy_Class_Btn;

    Game_Manager my_Game_Manager;


    // Start is called before the first frame update
    void Start()
    {
        select_Class_UI.alpha = 0f;

        my_Game_Manager = FindObjectOfType<Game_Manager>();

        normal_Class_Btn.onClick.AddListener(normal_Btn_Clicked);
        range_Class_Btn.onClick.AddListener(range_Btn_Clicked);
        heavy_Class_Btn.onClick.AddListener(heavy_Btn_Clicked);


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void show_UI()
    {
        select_Class_UI.alpha = 1f;
    }

    public void hide_UI()
    {
        select_Class_UI.alpha = 0f;
    }

    public void normal_Btn_Clicked()
    {
        my_Game_Manager.chose_Normal_Class();

        hide_UI();
    }

    public void range_Btn_Clicked()
    {
        my_Game_Manager.chose_Range_Class();

        hide_UI();
    }

    public void heavy_Btn_Clicked()
    {
        my_Game_Manager.chose_Heavy_Class();

        hide_UI();
    }
}
