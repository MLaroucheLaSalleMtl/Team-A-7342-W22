using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : IState
{

    private FSM manager;
    private Parameters param;

    private AnimatorStateInfo currInfo;


    public AttackState(FSM manager)
    {
        this.manager = manager;
        this.param = manager.param;
    }
    public void OnEnter()
    {
        param.anim.Play("Evil Wizard_Attack");
    }

    public void OnUpdate()
    {
        currInfo = param.anim.GetCurrentAnimatorStateInfo(0);

        if (param.isHit)
        {
            manager.StateTransit(StateType.Attack);
        }
        if(currInfo.normalizedTime >= .95f)
        {
            manager.StateTransit(StateType.Patrol);
        }
    }

    public void OnExit()
    {

    }
}
