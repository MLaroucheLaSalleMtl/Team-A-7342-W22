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
        param.anim.Play("Evil Wizard_Walk");
    }

    public void OnUpdate()
    {
        manager.FlipDirection(param.patrolPoints[patrolPos]);

        manager.transform.position = Vector2.MoveTowards(manager.transform.position,
            param.patrolPoints[patrolPos].position, param.moveSpeed * Time.deltaTime);

        //if there is a target and it's still within the range of the chasing, then play the chase
        if (param.target != null &&
            param.target.position.x >= param.chasePoints[0].position.x &&
             param.target.position.x <= param.chasePoints[1].position.x)
        {
            manager.StateTransit(StateType.React);
        }


        if (Vector2.Distance(manager.transform.position, param.patrolPoints[patrolPos].position) < 0.1f)
        {
            manager.StateTransit(StateType.Idle);
        }


    }

    public void OnExit()
    {
        patrolPos++;

        if(patrolPos>= param.patrolPoints.Length)
        {
            //restart the patrol state

            patrolPos = 0;
        }
    }
}
