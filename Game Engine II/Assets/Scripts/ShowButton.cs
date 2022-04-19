using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowButton : MonoBehaviour
{
    public List<GameObject> EnemyInRoom = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        RegisterEnemies();
        gameObject.SetActive(false);
    }

    public void RemoveEnemy(EnemyHPManager enemy)
    {
        EnemyInRoom.Remove(enemy.gameObject);
        if (EnemyInRoom.Count <= 0) 
        {
            gameObject.SetActive(true);
        }
    }

    public void RegisterEnemies()
    {
        foreach (GameObject enemy in EnemyInRoom)
        {
            enemy.GetComponent<EnemyHPManager>().die += RemoveEnemy;
        }
    }

}
