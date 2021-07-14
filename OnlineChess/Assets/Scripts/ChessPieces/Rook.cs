using System.Collections.Generic;
using UnityEngine;

public class Rook : ChessPiece
{
    public override List<Vector2Int> GetAvailableMoves(ref ChessPiece[,] board, int tileCountX, int tileCountY)
    {
        List<Vector2Int> result = new List<Vector2Int>();

        // Right
        for (int x = currentX + 1; x < tileCountX; x++)
        {
            if (board[x, currentY] != null)
            {
                if (board[x, currentY].team != team)
                {
                    result.Add(new Vector2Int(x, currentY));
                }
                break;
            }
            result.Add(new Vector2Int(x, currentY));
        }

        // Left
        for (int x = currentX - 1; x >= 0; x--)
        {
            if (board[x, currentY] != null)
            {
                if (board[x, currentY].team != team)
                {
                    result.Add(new Vector2Int(x, currentY));
                }
                break;
            }
            result.Add(new Vector2Int(x, currentY));
        }

        // Up
        for (int y = currentY + 1; y < tileCountY; y++)
        {
            if (board[currentX, y] != null)
            {
                if (board[currentX, y].team != team)
                {
                    result.Add(new Vector2Int(currentX, y));
                }
                break;
            }
            result.Add(new Vector2Int(currentX, y));
        }

        // Down
        for (int y = currentY - 1; y >= 0; y--)
        {
            if (board[currentX, y] != null)
            {
                if (board[currentX, y].team != team)
                {
                    result.Add(new Vector2Int(currentX, y));
                }
                break;
            }
            result.Add(new Vector2Int(currentX, y));
        }

        return result;
    }
}
