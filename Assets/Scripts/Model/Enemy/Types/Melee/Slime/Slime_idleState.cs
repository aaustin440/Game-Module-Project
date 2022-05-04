using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime_idleState : idleState
{
    
    private Slime slime; //private instead of protected as I don't want to inherit this class
    public Slime_idleState(baseScript baseScript2, FSM fsm, string name, dataIdle idleData, Slime slime) : base(baseScript2, fsm, name, idleData)
    {
        this.slime = slime;
    }

    public override void Begin()
    {
        base.Begin();
        // slime.enemyVel(0);
        // slime.animator.SetBool("idle", true);
    }

    public override void End()
    {
        base.End();
        // slime.animator.SetBool("idle", false);
    }

    public override void modelUpdate()
    {
        base.modelUpdate();
        //afetr the idle state, enter the walk state
        if (idleFinished)
        {
            fsm.alterState(slime.walkState);
        }
    }

    public override void physUpdate()
    {
        base.physUpdate();
    }
}
