using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isHitState : IState
{
    private FSM manager;
    private Parameters param;

    private AnimatorStateInfo info;
    public isHitState(FSM manager)
    {
        this.manager = manager;
        this.param = manager.param;
    }
    public void OnEnter()
    {
        param.anim.Play("Evil Wizard_isHit");
        param.health--;
    }

    public void OnUpdate()
    {
        info = param.anim.GetCurrentAnimatorStateInfo(0);

        if (param.health <= 0)
        {
            manager.StateTransit(StateType.Death);
        }
        if (info.normalizedTime >= .95f)
        {
            param.target = GameObject.FindWithTag("Player").transform;

            manager.StateTransit(StateType.Chase);
        }
    }

    public void OnExit()
    {
        param.isHit = false;
    }
}
