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

    private List<Board_Position> List_Of_Adjacents = new List<Board_Position>();

    private bool visited_tile = false;
    private Board_Position parent = null;
    private int distance = 0;

    private List<Board_Position> BoardPositionsList = new List<Board_Position>();

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

    public void Reset()
    {
    selectable_tile = false;
    destination_tile = false;
    current_tile = false;
    visited_tile = false;
    parent = null;
    distance = 0;
    }

    public void Check_Tile(Vector3 direction, float jump_height)
    {
        Vector3 half_extents = new Vector3(0.25f, ((1 + jump_height)/2),0.25f);
        Collider[] colliders = Physics.OverlapBox(transform.position + direction, half_extents);

        foreach (Collider item in colliders)
        {
            Board_Position tile = item.GetComponent<Board_Position>();
            if (tile != null && tile.walkable_tile)
            {
                RaycastHit hit;
                if (Physics.Raycast(tile.transform.position, Vector3.up, out hit, 1))
                {
                    List_Of_Adjacents.Add(tile);
                }
            }
        }
    }

    public void Find_Adjacent_Tiles(float jump_height)
    {
        Reset();

        Check_Tile(Vector3.forward, jump_height);
        Check_Tile(-Vector3.forward, jump_height);
        Check_Tile(Vector3.right, jump_height);
        Check_Tile(-Vector3.right, jump_height);
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

    public void SetAsVisited()
    {
        this.visited_tile = true;
    }

    public void SetParent(Board_Position new_parent)
    {
        this.parent = new_parent;
    }

    public void SetDistance(int new_distance)
    {
        distance = new_distance;
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

    public bool CheckIsVisited()
    {
        return visited_tile;
    }

    public int CheckDistance()
    {
        return distance;
    }

    public List<Board_Position> CheckAdjaceny()
    {
        return List_Of_Adjacents;
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
