using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider HPBar;
    public BossAtk bossHP;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        HPBar.maxValue = bossHP.bossCurrHealth;
        HPBar.value = bossHP.bossCurrHealth;
    }

}
