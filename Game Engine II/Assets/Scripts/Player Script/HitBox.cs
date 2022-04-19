using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
   public int damage = 5;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //EnemyHPManager enemy = collision.GetComponent<EnemyHPManager>();
/*
        if(enemy)
        {
            enemy.MonsterTakeDamage(damage);
        }*/

        if (collision.CompareTag("Enemy"))
        {
            Debug.Log("Enemy hit");
            collision.GetComponent<EnemyHPManager>().MonsterTakeDamage(damage);
        }
    }

}
