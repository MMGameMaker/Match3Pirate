using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMoves : Level
{
    public int numMoves;
    public int targetScore;

    private int moveUsed = 0;

    // Start is called before the first frame update
    void Start()
    {
        type = LevelType.MOVES;

        hud.SetlevelType(type);
        hud.SetScore(currentScore);
        hud.SetTarget(targetScore);
        hud.SetRemaining(numMoves);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnMove()
    {
        base.OnMove();

        moveUsed++;

        hud.SetRemaining(numMoves - moveUsed);

        if(numMoves - moveUsed == 0)
        {

            if(currentScore >= targetScore)
            {
                GameWin();
            }
            else
            {
                GameLose();
            }
        }

    }

}
