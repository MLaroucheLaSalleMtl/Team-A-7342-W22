using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class isHitState : IState
{
    private BossHurtEffects hurtEffect;
    private FSM manager;
    private Parameters param;
    //public float changeTime;
    //private SpriteRenderer sr;
    //private Color originalColor;

    private AnimatorStateInfo info;
    public isHitState(FSM manager)
    {
        this.manager = manager;
        this.param = manager.param;
     
    }

  

    public void OnEnter()
    {
        
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
