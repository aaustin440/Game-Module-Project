using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class idleState : State
{
    protected dataIdle idleData;

    protected bool turnAround; //flipAfterIdle
    protected bool idleFinished; 

    protected float idleTimer;

    public idleState(baseScript baseScript2, FSM fsm, string name, dataIdle idleData) : base(baseScript2, fsm, name)
    {
        this.idleData = idleData;
    }

    public override void Begin()
    {
        base.Begin();
        baseScript2.enemyVel(0f);
        idleFinished = false;
        setIdleTimer();
        //idleData.animator.SetBool("idle", true);

    }

    public override void End()
    {
        base.End();
        //idleData.animator.SetBool("idle", false);
        if(turnAround)
        {
           baseScript2.turn();
        }

    }

    public override void modelUpdate()
    {
        base.modelUpdate();

        if(Time.time >= launchTime + idleTimer) //launch time got from State class
        {
            idleFinished = true;
        }
    }

    public override void physUpdate()
    {
        base.physUpdate();
    }

    public void needTurn(bool turn)
    {
        turnAround = turn;
    }

    private void setIdleTimer()
    {
        idleTimer = Random.Range(idleData.minIdltime, idleData.maxIdltime);
    }


}
