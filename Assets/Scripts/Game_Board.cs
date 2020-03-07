using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoard
{

    BoardPosition[,] the_board;
    private int BOARD_WIDTH = 100;
    private int BOARD_LENGTH = 100;

    public GameBoard()
    {
        the_board = new BoardPosition[BOARD_WIDTH, BOARD_LENGTH];
        for (int i = 0; i < BOARD_WIDTH; i++)
            for (int j = 0; j < BOARD_LENGTH; j++)
            {
                GameObject the_ground = GameObject.CreatePrimitive(PrimitiveType.Cube);
                the_ground.transform.position = get_tile_position(i, j);
                BoardPosition new_ground = the_ground.AddComponent<BoardPosition>();
                the_board[i, j] = new_ground;
                new_ground.you_are_at(i, j, this);
            }
    }

    public BoardPosition get_tile(int i, int j)
    {
        return the_board[i, j];
    }

    public Vector3 get_tile_position(int i, int j)
    {
        return new Vector3(i, 0, j);
    }
}
