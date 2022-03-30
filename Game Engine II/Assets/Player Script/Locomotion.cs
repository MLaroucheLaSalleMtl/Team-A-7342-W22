using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;



public class Locomotion : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private Vector2 direction = new Vector2();
    [SerializeField] private float speed = 300.0f;
    private Animator anim;

    //Attack of the character
    private bool attack;
    
    

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
    }

    private void Animate() //controls the movement of the character
    {
        anim.SetFloat("h", direction.x);
        anim.SetFloat("v", direction.y);
        anim.SetFloat("magnitude", _rigidbody.velocity.magnitude);
        
        
    }

    public void OnMove(InputAction.CallbackContext context) //get the input from the player for the movement
    {
        
        direction = context.ReadValue<Vector2>();

    }
    private void Move() //move the character
    {
        Vector2 position = new Vector2();
        position += (direction.normalized * speed) * Time.fixedDeltaTime;
        _rigidbody.velocity = position;
    }

    public void OnFire(InputAction.CallbackContext context) //get the input from the player for the attack
    {
        attack = context.performed;
    }

    private void Attack()//controls only the animation for the attack
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
