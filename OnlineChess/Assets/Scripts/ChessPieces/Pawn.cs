using System.Collections.Generic;
using UnityEngine;

public class Pawn : ChessPiece
{
    public override List<Vector2Int> GetAvailableMoves(ChessPiece[,] board, int tileCountX, int tileCountY)
    {
        List<Vector2Int> result = new List<Vector2Int>();

        int direction = (team == Team.White) ? 1 : -1;


        // One step forward
        if (board[currentX, currentY + direction] == null)
        {
            result.Add(new Vector2Int(currentX, currentY + direction));
        }

        // Two steps forward
        if (board[currentX, currentY + direction] == null)
        {
            // White
            if (team == Team.White && currentY == 1 && board[currentX, currentY + direction * 2] == null)
            {
                result.Add(new Vector2Int(currentX, currentY + direction * 2));
            }
            // Black
            if (team == Team.Black && currentY == 6 && board[currentX, currentY + direction * 2] == null)
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

    public override SpecialMove GetSpecialMoves(ref ChessPiece[,] board, ref List<Vector2Int[]> moveList, ref List<Vector2Int> availableMoves)
    {
        int direction = (team == Team.White) ? 1 : -1;

        if ((team == Team.White && currentY == 6) || (team == Team.Black && currentY == 1))
        {
            return SpecialMove.Promotion;
        }

        // En Passant
        if (moveList.Count > 0)
        {
            Vector2Int[] lastMove = moveList[moveList.Count - 1];
            // if the last piece moved was a pawn
            if (board[lastMove[1].x, lastMove[1].y].type == ChessPieceType.Pawn)
            {
                // If the last move was +2
                if (Mathf.Abs(lastMove[0].y - lastMove[1].y) == 2)
                {
                    if (board[lastMove[1].x, lastMove[1].y].team != team)
                    {
                        // if boath pawns are on the same Y
                        if (lastMove[1].y == currentY)
                        {
                            // left
                            if (lastMove[1].x == currentX - 1)
                            {
                                availableMoves.Add(new Vector2Int(currentX - 1, currentY + direction));
                                return SpecialMove.EnPassant;
                            }
                            // right
                            if (lastMove[1].x == currentX + 1)
                            {
                                availableMoves.Add(new Vector2Int(currentX + 1, currentY + direction));
                                return SpecialMove.EnPassant;
                            }
                        }
                    }
                }
            }
        }

        return SpecialMove.None;
    }

    public override void SetPosition(Vector3 position, bool force = false)
    {
        position += Vector3.up * 2f;
        desiredPosition = position;
        if (force)
        {
            transform.position = desiredPosition;
        }
    }
}
