using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StateType //list out all the types of state
{
    Idle, Patrol, Attack
}

[Serializable] 
public class Parameters
{
    public int health;
    public float moveSpeed;
    public Transform[] patrolPoints;
    //public Transform[] chasePoints;
    public Animator anim;

}
public class FSM : MonoBehaviour
{
    private IState currState;
    private Dictionary<StateType, IState> states = new Dictionary<StateType, IState>();
    public Parameters param = new Parameters();

    void Start()
    {
        states.Add(StateType.Idle, new IdleState(this));
        states.Add(StateType.Patrol, new PatrolState(this));


        StateTransit(StateType.Idle);//start from idle state

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StateTransit(StateType type)
    {
        if(currState != null) //if curr state is not null
        {
            currState.OnExit(); //do the OnExit, end the curr state
        }

        currState = states[type]; //switch to the type of state we want
        currState.OnEnter(); //do OnEnter for the new state
    }

    public void FlipDirection(Transform target) //change the attack direction of where the player is 
    {
        if(target != null)
        {
            if(transform.position.x > target.position.x)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else if(transform.position.x < target.position.x)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
        }
    }
}
