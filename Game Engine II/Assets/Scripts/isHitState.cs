using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isHitState : IState
{
    private FSM manager;
    private Parameters param;
    public float changeTime;
    private SpriteRenderer sr;
    private Color originalColor;

    private AnimatorStateInfo info;
    public isHitState(FSM manager)
    {
        this.manager = manager;
        this.param = manager.param;
        sr = GetComponent<SpriteRenderer>();
        originalColor = sr.color;
    }

    private T GetComponent<T>()
    {
        throw new NotImplementedException();
    }

    public void OnEnter()
    {
        
        param.health--;
        FlashColor(changeTime);
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

    void FlashColor(float time)
    {
        sr.color = new Color(255, 255, 0, 255);
        Invoke("ResetColor", time);
    }

    private void Invoke(string v, float time)
    {
        throw new NotImplementedException();
    }

    void ResetColor()
    {
        sr.color = originalColor;
    }
}
