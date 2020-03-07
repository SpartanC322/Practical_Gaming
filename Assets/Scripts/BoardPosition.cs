using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardPosition:MonoBehaviour
{
    private bool walkable = true;
    private int i;
    private int j;
    GameBoard the_board;
    Renderer out_renderer;

    private List<BoardPosition> BoardPositionsList = new List<BoardPosition>();

    internal void you_are_at(int i, int j, GameBoard gameBoard)
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
    internal void tile_not_walkable()
    {
        walkable = false;
    }

    internal void highlight()
    {
        out_renderer.material.color = Color.red;
    }
}
