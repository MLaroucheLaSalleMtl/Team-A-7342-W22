using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : IState
{

    private FSM manager;
    private Parameters param;

   
    public ChaseState(FSM manager)
    {
        this.manager = manager;
        this.param = manager.param;
    }
    public void OnEnter()
    {
        //play the chase anim
        param.anim.Play("Bat_Move");
    }

    public void OnUpdate()
    {
        manager.FlipDirection(param.target);
        //if there is a target approaches, enemy moves towards to target.
        if (param.target)
        {
            manager.transform.position = Vector2.MoveTowards(manager.transform.position,
                param.target.position, param.chaseSpeed * Time.deltaTime);
        }
        //if there is no target, and target is out of the range of active, then switch back to idle state.
        if (param.target== null || manager.transform.position.x < param.chasePoints[0].position.x ||
             manager.transform.position.x > param.chasePoints[1].position.x) 
        {
            manager.StateTransit(StateType.Idle);
        }
    }

    public void OnExit()
    {
       
    }
}
