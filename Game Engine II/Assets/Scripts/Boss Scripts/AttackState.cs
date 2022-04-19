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

        
        if(currInfo.normalizedTime >= .95f)
        {
            manager.StateTransit(StateType.Chase);
        }
    }

    public void OnExit()
    {

    }

    //public void TriggerAttack()
    //{
    //    TriggerAttack();
    //    Collider2D[] detectedObjects = Physics2D.OverlapCircleAll(param.attackPoint, param.attackRange, Locomotion.whatIsPlayer);

    //    foreach (Collider2D collider in detectedObjects)
    //    {
    //       // collider.transform
    //    }
    //}
}
