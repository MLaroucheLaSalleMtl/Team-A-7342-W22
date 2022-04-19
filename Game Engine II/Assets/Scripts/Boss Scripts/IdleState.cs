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
        param.anim.Play("Evil Wizard_Idle");
    }

    public void OnUpdate()
    {
        timer += Time.deltaTime;

        //if target is not null, and within the range of chasing
        if (param.target != null &&
            param.target.position.x >= param.chasePoints[0].position.x &&
             param.target.position.x <= param.chasePoints[1].position.x)
        {
            manager.StateTransit(StateType.React);
        }

        if (timer >= param.idleTime)
        {
            manager.StateTransit(StateType.Patrol);
        }
    }

    public void OnExit()
    {
        //reset the timer
        timer = 0;
    }
}


