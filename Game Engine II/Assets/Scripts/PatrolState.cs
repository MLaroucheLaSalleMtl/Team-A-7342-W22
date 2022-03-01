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
        manager.transform.position = Vector2.MoveTowards(manager.transform.position,
            param.patrolPoints[patrolPos].position, param.moveSpeed * Time.deltaTime);

        if(Vector2.Distance(manager.transform.position, param.patrolPoints[patrolPos].position) < 0.1f)
        {
            manager.StateTransit(StateType.Patrol);
        }


    }

    public void OnExit()
    {
        patrolPos++;

        if(patrolPos>= param.patrolPoints.Length)
        {
            patrolPos = 0;
        }
    }
}
