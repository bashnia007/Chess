using System;
using System.Collections.Generic;
using UnityEngine;

public class Knight : ChessPiece
{
    public override List<Vector2Int> GetAvailableMoves(ref ChessPiece[,] board, int tileCountX, int tileCountY)
    {
        List<Vector2Int> result = new List<Vector2Int>();

        List<Vector2Int> moves = new List<Vector2Int>();
        moves.Add(new Vector2Int(1, 2));
        moves.Add(new Vector2Int(2, 1));
        moves.Add(new Vector2Int(-1, 2));
        moves.Add(new Vector2Int(2, -1));
        moves.Add(new Vector2Int(1, -2));
        moves.Add(new Vector2Int(-2, 1));
        moves.Add(new Vector2Int(-1, -2));
        moves.Add(new Vector2Int(-2, -1));

        foreach (var move in moves)
        {
            int x = currentX + move.x;
            int y = currentY + move.y;

            if (IsOnBoard(x, y, tileCountX, tileCountY) && (board[x, y] == null || board[x, y].team != team))
            {
                result.Add(new Vector2Int(x, y));
            }
        }

        return result;
    }
}
