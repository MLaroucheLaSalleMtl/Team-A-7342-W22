using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : IState
{

    private FSM manager;
    private Parameters param;

    private int patrolPos;

    public PatrolState(FSM manager)
    {
        this.manager = manager;
        this.param = manager.param;
    }
    public void OnEnter()
    {
        param.anim.Play("Bat_Move");
    }

    public void OnUpdate()
    {
        manager.FlipDirection(param.patrolPoints[patrolPos]);
    }

    public void OnExit()
    {

    }
}
