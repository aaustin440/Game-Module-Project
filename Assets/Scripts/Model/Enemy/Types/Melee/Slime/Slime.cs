using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : baseScript
{

    [SerializeField] private dataIdle idleData;
    [SerializeField] private dataWalk walkData;
    public Slime_idleState idleState { get; private set; }
    public Slime_walkState walkState { get; private set; }

    public override void Start()
    {
        base.Start();
        idleState = new Slime_idleState(this, fsm, "idle", idleData, this); // use "idle" for animator
        walkState = new Slime_walkState(this, fsm, "walk", walkData, this); //use "walk" for animator

        fsm.Initialize(walkState);
        
    }
}
