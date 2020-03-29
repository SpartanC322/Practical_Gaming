using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board_Position : MonoBehaviour
{
    private bool walkable_tile = true;
    private bool selectable_tile = false;
    private bool destination_tile = false;
    private bool current_tile = false;
    private int i;
    private int j;
    Game_Board the_board;
    Renderer out_renderer;

    private void Update()
    {
        if (selectable_tile)
        {
            GetComponent<Renderer>().material.color = Color.red;
        }

        if (destination_tile)
        {
            GetComponent<Renderer>().material.color = Color.green;
        }

        if (current_tile)
        {
            GetComponent<Renderer>().material.color = Color.grey;
        }
    }

    public void SetAsWalkable()
    {
        this.walkable_tile = true;
    }

    public void SetAsSelectable()
    {
        this.selectable_tile = true;
    }

    public void SetAsDestination()
    {
        this.destination_tile = true;
    }

    public void SetAsCurrent()
    {
        this.current_tile = true;
    }

    public bool CheckIsWalable()
    {
        return walkable_tile;
    }

    public bool CheckIsSelected()
    {
        return selectable_tile;
    }

    public bool CheckIsDestination()
    {
        return destination_tile;
    }

    public bool CheckIsCurrent()
    {
        return current_tile;
    }

    internal void you_are_at(int i, int j, Game_Board gameBoard)
    {
        this.i = i;
        this.j = j;
        the_board = gameBoard;
        out_renderer = GetComponent<Renderer>();
    }

    internal Vector3 unit_position()
    {
       return transform.position + 0.5f* Vector3.up;
    }

    internal void highlight()
    {
        out_renderer.material.color = Color.red;
    }
}
