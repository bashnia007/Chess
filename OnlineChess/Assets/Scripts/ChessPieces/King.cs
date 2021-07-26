using System.Collections.Generic;
using UnityEngine;

public class King : ChessPiece
{
    public override List<Vector2Int> GetAvailableMoves(ref ChessPiece[,] board, int tileCountX, int tileCountY)
    {
        var result = new List<Vector2Int>();

        List<Vector2Int> moves = new List<Vector2Int>();
        moves.Add(new Vector2Int(1, 1));
        moves.Add(new Vector2Int(1, 0));
        moves.Add(new Vector2Int(1, -1));
        moves.Add(new Vector2Int(0, 1));
        moves.Add(new Vector2Int(0, -1));
        moves.Add(new Vector2Int(-1, 1));
        moves.Add(new Vector2Int(-1, 0));
        moves.Add(new Vector2Int(-1, -1));

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

    public override SpecialMove GetSpecialMoves(ref ChessPiece[,] chessPieces, ref List<Vector2Int[]> moveList, ref List<Vector2Int> availableMoves)
    {
        SpecialMove r = SpecialMove.None;

        var kingMove = moveList.Find(m => m[0].x == 4 && m[0].y == ((team == 0) ? 0 : 7));
        var leftRock = moveList.Find(m => m[0].x == 0 && m[0].y == ((team == 0) ? 0 : 7));
        var rightRock = moveList.Find(m => m[0].x == 7 && m[0].y == ((team == 0) ? 0 : 7));

        if (kingMove == null && currentX == 4)
        {
            // White team
            if (team == 0)
            {
                // Left Rock
                if (leftRock == null)
                {
                    if (chessPieces[0, 0].type == ChessPieceType.Rook && chessPieces[0, 0].team == 0)
                    {
                        if (chessPieces[3, 0] == null && chessPieces[2, 0] == null && chessPieces[1, 0] == null)
                        {
                            availableMoves.Add(new Vector2Int(2, 0));
                            r = SpecialMove.Castling;
                        }
                    }
                }

                // Right Rock
                if (rightRock == null)
                {
                    if (chessPieces[7, 0].type == ChessPieceType.Rook && chessPieces[7, 0].team == 0)
                    {
                        if (chessPieces[6, 0] == null && chessPieces[5, 0] == null)
                        {
                            availableMoves.Add(new Vector2Int(6, 0));
                            r = SpecialMove.Castling;
                        }
                    }
                }
            }
            else
            {
                // Left Rock
                if (leftRock == null)
                {
                    if (chessPieces[0, 7].type == ChessPieceType.Rook && chessPieces[0, 7].team == 1)
                    {
                        if (chessPieces[3, 7] == null && chessPieces[2, 7] == null && chessPieces[1, 7] == null)
                        {
                            availableMoves.Add(new Vector2Int(2, 7));
                            r = SpecialMove.Castling;
                        }
                    }
                }

                // Right Rock
                if (rightRock == null)
                {
                    if (chessPieces[7, 7].type == ChessPieceType.Rook && chessPieces[7, 7].team == 1)
                    {
                        if (chessPieces[6, 7] == null && chessPieces[5, 7] == null)
                        {
                            availableMoves.Add(new Vector2Int(6, 7));
                            r = SpecialMove.Castling;
                        }
                    }
                }
            }
        }

        return r;
    }
}
