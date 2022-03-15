using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementFollowPlayer : MonoBehaviour
{

    public Transform player;
    public float moveSpeed = 3f;
    public float activeMovingRadius;
    private Rigidbody2D Rigidbody;
    private Vector2 movement;

    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.position - transform.position;
        direction.Normalize();
        movement = direction;
    }

    private void FixedUpdate()
    {
        float distance = (transform.position - player.position).sqrMagnitude;
        if (distance <= activeMovingRadius * activeMovingRadius)
        {
            anim.SetBool("attack", true);
            moveCharacter(movement);
        }
    }

    void moveCharacter(Vector2 direction)
    {
        Rigidbody.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }
}
