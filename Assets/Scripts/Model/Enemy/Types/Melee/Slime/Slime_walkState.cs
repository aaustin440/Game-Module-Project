using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime_walkState : walkState
{
    private Slime slime; //private instead of protected as I don't want to inherit this class

    public Slime_walkState(baseScript baseScript2, FSM fsm, string name, dataWalk walkData, Slime slime) : base(baseScript2, fsm, name, walkData)
    {
        this.slime = slime;
    }

    public override void Begin()
    {
        base.Begin();
        slime.enemyVel(walkData.speed);
        slime.animator.SetBool("walk", true);
    }

    public override void End()
    {
        base.End();
        slime.animator.SetBool("walk", false);
    }

    public override void modelUpdate()
    {
        base.modelUpdate();

        if (!isGround || isWall)
        {
            //slime.turn();
            //TODO: add transition to idle state\
            slime.idleState.needTurn(true);
            fsm.alterState(slime.idleState);

        }
        
    }

    public override void physUpdate()
    {
        base.physUpdate();
    }
}
