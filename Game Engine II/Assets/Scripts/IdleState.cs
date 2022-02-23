using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState
{

    private FSM manager;
    private Parameters param;

    public IdleState(FSM manager)
    {
        this.manager = manager;
        this.param = manager.param;
    }
    public void OnEnter()
    {

    }

    public void OnUpdate()
    {

    }

    public void OnExit()
    {

    }
}
