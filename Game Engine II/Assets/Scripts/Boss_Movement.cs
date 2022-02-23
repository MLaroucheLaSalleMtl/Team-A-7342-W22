using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Movement : MonoBehaviour
{
    public float speed;
    public float activeRadius;
    public float loseRadius;

    private Transform playerTransform;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        //playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    //void Active
    // Update is called once per frame
    void Update()
    {
        if (playerTransform != null)
        {
            float distance = (transform.position - playerTransform.position).sqrMagnitude;
            if(distance <= activeRadius * activeRadius) // if distance betw player and boss smaller than the active radius, boss start following.
            {
                //transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);
                Attack();
            }
            else if(distance < loseRadius * loseRadius)
            {

            }
        }
    }

    void Attack()
    {

    }
}
