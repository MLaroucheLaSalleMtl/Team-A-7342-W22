using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHPManager : MonoBehaviour
{
    public int playerMaxHP;
    public int playerCurrentHP;
    // Start is called before the first frame update
    void Start()
    {
        playerCurrentHP = playerMaxHP;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerCurrentHP <= 0)
        {
            gameObject.SetActive(false);
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
