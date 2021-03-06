using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bishop : ChessPiece
{
    public override List<Vector2Int> GetAvailableMoves(ChessPiece[,] board, int tileCountX, int tileCountY)
    {
        var result = new List<Vector2Int>();

        // Up right
        for (int i = 1; i < tileCountX; i++)
        {
            int x = currentX + i;
            int y = currentY + i;

            if (!IsOnBoard(x, y, tileCountX, tileCountY)) break;

            if (board[x, y] != null)
            {
                if (board[x, y].team != team)
                {
                    result.Add(new Vector2Int(x, y));
                }
                break;
            }
            result.Add(new Vector2Int(x, y));
        }

        // Up left
        for (int i = 1; i < tileCountX; i++)
        {
            int x = currentX - i;
            int y = currentY + i;

            if (!IsOnBoard(x, y, tileCountX, tileCountY)) break;

            if (board[x, y] != null)
            {
                if (board[x, y].team != team)
                {
                    result.Add(new Vector2Int(x, y));
                }
                break;
            }
            result.Add(new Vector2Int(x, y));
        }

        // Down right
        for (int i = 1; i < tileCountX; i++)
        {
            int x = currentX + i;
            int y = currentY - i;

            if (!IsOnBoard(x, y, tileCountX, tileCountY)) break;

            if (board[x, y] != null)
            {
                if (board[x, y].team != team)
                {
                    result.Add(new Vector2Int(x, y));
                }
                break;
            }
            result.Add(new Vector2Int(x, y));
        }

        // Down left
        for (int i = 1; i < tileCountX; i++)
        {
            int x = currentX - i;
            int y = currentY - i;

            if (!IsOnBoard(x, y, tileCountX, tileCountY)) break;

            if (board[x, y] != null)
            {
                if (board[x, y].team != team)
                {
                    result.Add(new Vector2Int(x, y));
                }
                break;
            }
            result.Add(new Vector2Int(x, y));
        }

        return result;
    }
}
