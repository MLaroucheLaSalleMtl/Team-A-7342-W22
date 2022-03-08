using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHpUI : MonoBehaviour
{

    public Slider HPBar;
    public Text HPText;
    public PlayerHPManager playerHP;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HPBar.maxValue = playerHP.playerMaxHP;
        HPBar.value = playerHP.playerCurrentHP;
        HPText.text = "HP: " + playerHP.playerCurrentHP + "/" + playerHP.playerMaxHP;
    }
}
