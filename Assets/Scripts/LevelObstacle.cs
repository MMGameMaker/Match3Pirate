using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelObstacle : Level
{
    public int numMoves;
    public GridManagement.PieceType[] obstaclesTypes;

    private int moveUsed = 0;
    private int numObstaclesLeft;

    // Start is called before the first frame update
    void Start()
    {
        type = LevelType.OBSTACLE;

        for(int i=0; i< obstaclesTypes.Length; i++)
        {
            numObstaclesLeft += grid.GetPiecesOfType(obstaclesTypes[i]).Count; 
        }

        hud.SetlevelType(type);
        hud.SetScore(currentScore);
        hud.SetTarget(numObstaclesLeft);
        hud.SetRemaining(numMoves);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnMove()
    {
        moveUsed++;

        hud.SetRemaining(numMoves - moveUsed);

        if (numMoves - moveUsed ==0 && numObstaclesLeft > 0)
        {
            GameLose();
        }
    }

    public override void OnPieceCleared(GamePiece piece)
    {
        base.OnPieceCleared(piece);

        for(int i=0; i<obstaclesTypes.Length; i++)
        {
            if(obstaclesTypes[i] == piece.Type)
            {
                numObstaclesLeft--;
                hud.SetTarget(numObstaclesLeft);

                if(numObstaclesLeft == 0)
                {
                    currentScore += 1000 * (numMoves - moveUsed);
                    hud.SetScore(currentScore);
                    GameWin();
                }
            }
        }
    }

}
