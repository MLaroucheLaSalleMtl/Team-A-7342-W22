using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyHPManager : MonoBehaviour
{
    public int enemyMaxHP;
    [SerializeField] private int enemyCurrentHP;

    
    public int EnemyCurrentHP 
    { 
        get => enemyCurrentHP;
        set 
        { 
            enemyCurrentHP = value;

            if (enemyCurrentHP <= 0)
            {
                gameObject.SetActive(false);
                OnDie();
            }
        }
    }

    public event Action<EnemyHPManager> die;

    // Start is called before the first frame update
    void Start()
    {
        EnemyCurrentHP = enemyMaxHP;
        this.gameObject.SetActive(true);
    }

    public void OnDie()
    {
        die?.Invoke(this);
    }

    public void MonsterTakeDamage(int damage)
    {
        EnemyCurrentHP -= damage;
    }

    public void SetMaxHP()
    {
        EnemyCurrentHP = enemyMaxHP;
    }

    //DEBUGGING
    public void OnValidate()
    {
        EnemyCurrentHP = enemyCurrentHP;
    }
}
