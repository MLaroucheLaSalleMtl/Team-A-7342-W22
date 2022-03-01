using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState
{

    private FSM manager;
    private Parameters param;

    private float timer;
    public IdleState(FSM manager)
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
        timer += Time.deltaTime;
        if(timer >= param.idleTime)
        {
            manager.StateTransit(StateType.Patrol);
        }
    }

    public void OnExit()
    {
        timer = 0;
    }
}


