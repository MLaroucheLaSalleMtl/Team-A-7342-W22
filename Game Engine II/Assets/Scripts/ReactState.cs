using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactState : IState
{

    private FSM manager;
    private Parameters param;

    private AnimatorStateInfo currInfo;//get current animation


    public ReactState(FSM manager)
    {
        this.manager = manager;
        this.param = manager.param;
    }
    public void OnEnter()
    {
        param.anim.Play("Evil Wizard_React");
    }

    public void OnUpdate()
    {
        currInfo = param.anim.GetCurrentAnimatorStateInfo(0);


        if (currInfo.normalizedTime >= .95f) //when it close to 1, react ends, start chasing
        {
            manager.StateTransit(StateType.Chase);
        }
    }

    public void OnExit()
    {

    }
}
