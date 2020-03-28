using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Board
{

    Board_Position[,] the_board;
    private int BOARD_WIDTH = 50;
    private int BOARD_LENGTH = 50;

    public Game_Board()
    {
        the_board = new Board_Position[BOARD_WIDTH, BOARD_LENGTH];
        for (int i = 0; i < BOARD_WIDTH; i++)
            for (int j = 0; j < BOARD_LENGTH; j++)
            {
                GameObject the_ground = GameObject.CreatePrimitive(PrimitiveType.Cube);
                the_ground.transform.position = get_tile_position(i, j);
                Board_Position new_ground = the_ground.AddComponent<Board_Position>();
                the_board[i, j] = new_ground;
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
}
