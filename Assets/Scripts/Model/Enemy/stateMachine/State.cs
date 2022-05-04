using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State 
{
    protected float launchTime;
    protected string name;
    protected FSM fsm;
    protected baseScript baseScript2;
    


    //constructor
    public State(baseScript baseScript2, FSM fsm, string name) 
    {
    
        this.baseScript2 = baseScript2;
        this.fsm = fsm;
        this.name = name;
    }

    //enter state function
    public virtual void Begin()
        {
            launchTime = Time.time;
            baseScript2.animator.SetBool (name, true);
        }

    //enter state function
    public virtual void End() // can be redefined in derived classes
    {
         baseScript2.animator.SetBool (name, false);
    }

    //does the logic for the state
    public virtual void modelUpdate() // can be redefined in derived classes
    {

    }

    //does the physics for the state
    public virtual void physUpdate()// can be redefined in derived classes
    {

    }

    
    
}
