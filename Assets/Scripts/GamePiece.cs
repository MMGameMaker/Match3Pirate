using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePiece : MonoBehaviour
{
    public int score;

    private int x;
    private int y;

    public int X
    {
        get { return x; }
        set
        {
            if (IsMovable())
            {
                x = value;
            }
        }
    }

    public int Y
    {
        get { return y; }
        set { 
            if (IsMovable())
            {
                y = value;
            } 
        }
    }

    private GridManagement.PieceType type;

    public GridManagement.PieceType Type
    {
        get { return type; }
    }

    private GridManagement grid;

    public GridManagement GridRef
    {
        get { return grid; }
    }

    private MoveablePiece moveableComponent;
    public MoveablePiece MoveableComponent
    {
        get { return moveableComponent; }
    }

    private ColorPiece colorComponent;
    public ColorPiece ColorComponent
    {
        get { return colorComponent; }
    }

    private ClearablePiece clearableComponent;

    public ClearablePiece ClearableComponent
    {
        get { return clearableComponent; }
    }


    private void Awake()
    {
        moveableComponent = GetComponent<MoveablePiece>();
        colorComponent = GetComponent<ColorPiece>();
        clearableComponent = GetComponent<ClearablePiece>();
    }

    public void Init(int _x, int _y, GridManagement _grid, GridManagement.PieceType _type)
    {
        this.x = _x;
        this.y = _y;
        this.grid = _grid;
        this.type = _type;
    }

    private void OnMouseDown()
    {
        grid.PressPiece(this);
    }

    private void OnMouseEnter()
    {
        grid.EnterPiece(this);
    }

    private void OnMouseUp()
    {
        grid.ReleasePiece();
    }


    public bool IsMovable()
    {
        return moveableComponent != null;
    }

    public bool IsColored()
    {
        return colorComponent != null;
    }

    public bool IsClearable()
    {
        return clearableComponent != null;
    }

}
