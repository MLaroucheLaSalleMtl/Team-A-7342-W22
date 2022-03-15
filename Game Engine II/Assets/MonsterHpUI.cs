using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterHpUI : MonoBehaviour
{
    public Slider HPBar;
    public EnemyHPManager enemyHP;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HPBar.maxValue = enemyHP.enemyMaxHP;
        HPBar.value = enemyHP.enemyCurrentHP;
    }
}
