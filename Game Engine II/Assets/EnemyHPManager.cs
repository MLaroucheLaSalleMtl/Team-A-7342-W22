using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHPManager : MonoBehaviour
{
    public int enemyMaxHP;
    public int enemyCurrentHP;
    // Start is called before the first frame update
    void Start()
    {
        enemyCurrentHP = enemyMaxHP;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyCurrentHP == 0)
        {
            Destroy(gameObject);
        }
    }

    public void HurtEnemy(int damage)
    {
        enemyCurrentHP -= damage;
    }

    public void SetMaxHP()
    {
        enemyCurrentHP = enemyMaxHP;
    }
}
