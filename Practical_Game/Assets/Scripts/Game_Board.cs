using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Board : MonoBehaviour
{
    Board_Position[,] the_board;
    private int BOARD_WIDTH = 20;
    private int BOARD_LENGTH = 20;

    public Game_Board()
    {
        the_board = new Board_Position[BOARD_WIDTH, BOARD_LENGTH];
        for (int i = 0; i < BOARD_WIDTH; i++)
            for (int j = 0; j < BOARD_LENGTH; j++)
            {
                GameObject the_ground = Instantiate(Resources.Load("Prefabs/Tile"), new Vector3(i, 0, j), Quaternion.identity) as GameObject;
                Board_Position new_ground = the_ground.AddComponent<Board_Position>();
                new_ground.you_are_at(i, j, this);
            }
    }

    public Board_Position get_tile(int i, int j)
    {
        return the_board[i, j];
    }

    public Vector3 get_tile_position(int i, int j)
    {
        return new Vector3(i, 0, j);
    }

    public int get_Width()
    {
        return BOARD_WIDTH;
    }

    public int get_Length()
    {
        return BOARD_LENGTH;
    }
}
