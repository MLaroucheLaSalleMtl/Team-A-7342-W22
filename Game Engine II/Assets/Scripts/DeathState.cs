using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathState : IState
{
    private FSM manager;
    private Parameters param;

    public DeathState(FSM manager)
    {
        this.manager = manager;
        this.param = manager.param;
    }

    public void OnEnter()
    {
        param.anim.Play("Evil Wizard_Death");
    }

    public void OnUpdate()
    {

    }

    public void OnExit()
    {

    }
}
