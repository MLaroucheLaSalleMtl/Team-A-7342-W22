using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StateType //list out all the types of state
{
    Idle, Patrol, React, Chase, Attack
}

[Serializable] 
public class Parameters
{
    public int health;
    public float moveSpeed;
    public float chaseSpeed;
    public float idleTime;
    public Transform[] patrolPoints;//only for those small monster
    public Transform[] chasePoints;
    public Transform target;
    public Animator anim;

    public LayerMask targetLayer;
    public float attackRange;
    public Transform attackPoint;

    public bool isHit;
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
        states.Add(StateType.Chase, new ChaseState(this));
        states.Add(StateType.Attack, new AttackState(this));

        StateTransit(StateType.Idle);//start from idle state
        param.anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        currState.OnUpdate();
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

    //if player enter the active area,(hit the collider)
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.CompareTag("Player"))
        {
            param.target = collision.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            param.target = null;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(param.attackPoint.position, param.attackRange);
    }
}
