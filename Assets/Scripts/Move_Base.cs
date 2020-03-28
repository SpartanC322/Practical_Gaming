using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Base : MonoBehaviour
{
    List<Board_Position> selectableTiles = new List<Board_Position>();
    Stack<Board_Position> path = new Stack<Board_Position>();
    Board_Position current_tile;
    GameObject[] tiles;
    private Vector3 heading = new Vector3();
    private int move = 5;
    private float half_height = 0;
    private float jump_height = 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Init()
    {
        tiles = GameObject.FindGameObjectsWithTag("Cube");

        half_height = GetComponent<Collider>().bounds.extents.y;
    }

    public void Get_Current_Tile()
    {
        current_tile = Get_Destination_Tile(gameObject);
        current_tile.SetAsCurrent();
    }

    public Board_Position Get_Destination_Tile(GameObject target)
    {
        RaycastHit hit;

        Board_Position tile = null;

        if (Physics.Raycast(target.transform.position, -Vector3.up, out hit, 1))
        {
            tile = hit.collider.GetComponent<Board_Position>();
        }

        return tile;
    }

    public void Compute_List_Of_Adacents()
    {
        foreach (GameObject tile in tiles)
        {
            Board_Position t = tile.GetComponent<Board_Position>();
            t.Find_Adjacent_Tiles(jump_height);
        }
    }

    public void Find_Selectable_Tiles()
    {
        Compute_List_Of_Adacents();
        Get_Current_Tile();

        Queue<Board_Position> process = new Queue<Board_Position>();
        current_tile.SetAsVisited();

        while (process.Count > 0)
        {
            Board_Position t = process.Dequeue();

            selectableTiles.Add(t);
            t.SetAsSelectable();


            if (t.CheckDistance() < move)
            {
                foreach (Board_Position tile in t.CheckAdjaceny())
                {
                    if (!tile.CheckIsVisited())
                    {
                        tile.SetParent(t);
                        tile.SetAsVisited();
                        tile.SetDistance(1 + t.CheckDistance());
                        process.Enqueue(tile);
                    }
                }
            }
        }
    }
}
