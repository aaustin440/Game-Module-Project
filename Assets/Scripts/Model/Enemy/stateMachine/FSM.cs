using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM 
{
    public State currState { get; set;}

    public void Initialize(State startState)
    {
         currState = startState;
         currState.Begin();
     }

    public void alterState(State newState)
    {
         currState.End(); //exits previous state so can enter the new state
         currState = newState; //switch current state to new state
         currState.Begin(); //enters the new state
         
    }
}
