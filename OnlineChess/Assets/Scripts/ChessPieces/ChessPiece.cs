using System;
using System.Collections.Generic;
using UnityEngine;

public enum ChessPieceType
{
    None = 0,
    Pawn = 1,
    Rook = 2,
    Knight = 3,
    Bishop = 4,
    Queen = 5,
    King = 6
}

public enum Team
{
    White = 0,
    Black = 1
}

public class ChessPiece : MonoBehaviour
{
    public Team team;
    public int currentX;
    public int currentY;
    public ChessPieceType type;

    protected Vector3 desiredPosition;
    private Vector3 desiredScale;

    private void Start()
    {
        desiredScale = transform.localScale;
        transform.rotation = Quaternion.Euler(team == Team.White ? new Vector3(-90, 0, -90) : new Vector3(-90, 0, 90));
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * 10);
        transform.localScale = Vector3.Lerp(transform.localScale, desiredScale, Time.deltaTime * 10);
    }

    public virtual void SetPosition(Vector3 position, bool force = false)
    {
        desiredPosition = position;
        if (force)
        {
            transform.position = desiredPosition;
        }
    }

    public virtual void SetScale(Vector3 scale, bool force = false)
    {
        desiredScale = scale;
        if (force)
        {
            transform.localScale = desiredScale;
        }
    }

    public virtual List<Vector2Int> GetAvailableMoves(ref ChessPiece[,] board, int tileCountX, int tileCountY)
    {
        List<Vector2Int> result = new List<Vector2Int>();

        return result;
    }

    protected bool IsOnBoard(int x, int y, int tileSizeX, int tileSizeY)
    {
        return x >= 0 && x < tileSizeX && y >= 0 && y < tileSizeY;
    }

    public virtual SpecialMove GetSpecialMoves(ref ChessPiece[,] chessPieces, ref List<Vector2Int[]> moveList, ref List<Vector2Int> availableMoves)
    {
        return SpecialMove.None;
    }
}
