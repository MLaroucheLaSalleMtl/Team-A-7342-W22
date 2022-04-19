using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHPManager : MonoBehaviour
{
    public int playerMaxHP;
    public int playerCurrentHP;

    private GameManager manager;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameManager.instance;
        playerCurrentHP = playerMaxHP;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerCurrentHP <= 0)
        {
            manager.Death();
        }
    }

    public void HurtPlayer(int damage)
    {
        playerCurrentHP -= damage;
    }

    public void SetMaxHP()
    {
        playerCurrentHP = playerMaxHP;
    }
}
