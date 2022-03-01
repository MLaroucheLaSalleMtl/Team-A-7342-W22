using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;



public class Locomotion : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    private Vector2 direction = new Vector2();
    [SerializeField] private float speed = 300.0f;
    private Animator anim;
    private bool attack;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Animate()
    {
        anim.SetFloat("h", direction.x);
        anim.SetFloat("v", direction.y);
        anim.SetFloat("magnitude", rigidbody.velocity.magnitude);
        
        
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        
        direction = context.ReadValue<Vector2>();

    }
    private void Move()
    {
        Vector2 position = new Vector2();
        position += (direction.normalized * speed) * Time.fixedDeltaTime;
        rigidbody.velocity = position;
    }
    public void OnFire(InputAction.CallbackContext context)
    {
        attack = context.performed;
    }
    private void Attack()
    {
        if (attack == true)
        {
            anim.SetTrigger("isAttack");
            attack = false;
        }
       
    }

  
    void FixedUpdate()
    {
        Move();
        Attack();
        Animate();
    }
    
}
