using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHurtEffects : MonoBehaviour
{

    public float changeTime;
    private SpriteRenderer sr;
    private Color originalColor;

    private BossHurtEffects hurtEffect;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        originalColor =sr.color;
    }

    // Update is called once per frame
    void Update()
    {
        //base.Update();
    }

    void FlashColor(float time)
    {
        sr.color = new Color(255, 0, 0, 255);
        Invoke("ResetColor", time);
    }


    void ResetColor()
    {
        sr.color = originalColor;
    }
}
