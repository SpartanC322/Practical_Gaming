using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Unit_Interface 
{
    void Set_Heavy();
    void Set_Normal();
    void Set_Ranged();
    void set_Player_2();
    bool get_Player_2();
    void set_Health(int new_Health);
    int get_Health();
    void has_Moved();
    int get_Attack_Range();
    void has_Not_Moved();
    bool has_It_Moved();
    void set_Class_Selected();
    int get_Damage();
    string get_Class();
    int get_Distance_Can_Move();
    bool is_Class_Selected();
}
