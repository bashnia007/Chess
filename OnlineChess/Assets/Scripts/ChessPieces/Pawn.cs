using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : ChessPiece
{
    public override List<Vector2Int> GetAvailableMoves(ref ChessPiece[,] board, int tileCountX, int tileCountY)
    {
        List<Vector2Int> result = new List<Vector2Int>();

        int direction = (team == 0) ? 1 : -1;

        // One step forward
        if (board[currentX, currentY + direction] == null)
        {
            result.Add(new Vector2Int(currentX, currentY + direction));
        }

        // Two steps forward
        if (board[currentX, currentY + direction] == null)
        {
            // White
            if (team == 0 && currentY == 1 && board[currentX, currentY + direction * 2] == null)
            {
                result.Add(new Vector2Int(currentX, currentY + direction * 2));
            }
            // Black
            if (team == 1 && currentY == 6 && board[currentX, currentY + direction * 2] == null)
            {
                result.Add(new Vector2Int(currentX, currentY + direction * 2));
            }
        }

        // Killing
        if (currentX != tileCountX - 1)
        {
            if (board[currentX + 1, currentY + direction] != null && board[currentX + 1, currentY + direction].team != team)
            {
                result.Add(new Vector2Int(currentX + 1, currentY + direction));
            }
        }
        if (currentX != 0)
        {
            if (board[currentX - 1, currentY + direction] != null && board[currentX - 1, currentY + direction].team != team)
            {
                result.Add(new Vector2Int(currentX - 1, currentY + direction));
            }
        }

        return result;
    }
}
