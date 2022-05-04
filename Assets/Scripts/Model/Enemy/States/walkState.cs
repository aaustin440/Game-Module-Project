using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walkState : State
{
    protected dataWalk walkData;

    protected bool isWall;
    protected bool isGround;
    
    public walkState(baseScript baseScript2, FSM fsm, string name, dataWalk walkData) : base(baseScript2, fsm, name)
    {
        this.walkData = walkData;
    }

    public override void Begin()  //override the inherited Begin from State class
    {
        base.Begin();
        baseScript2.enemyVel(walkData.speed);

        isGround = baseScript2.lookGround();
        isWall = baseScript2.lookWall();
        //walkData.animator.SetBool("walk", true);
    }

    public override void End()
    {
        base.End();
        //walkData.animator.SetBool("walk", false);
    }

    public override void modelUpdate()
    {
       base.modelUpdate();
    }

    //checks if the enemy at edge of platform or if wall infront of enemy
    public override void physUpdate()
    {
       base.physUpdate();
       isGround = baseScript2.lookGround();
        isWall = baseScript2.lookWall();
       
    }

}
