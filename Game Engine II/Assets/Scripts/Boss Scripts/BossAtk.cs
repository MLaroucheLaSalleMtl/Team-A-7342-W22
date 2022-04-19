using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAtk : MonoBehaviour
{
    public int bossCurrHealth;
    public int bossDmg;

    private SpriteRenderer sr;
    private Color originalColor;
    public float flashtime;

    public void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        originalColor = sr.color;
    }

    public void Update()
    {
        if (bossCurrHealth <=0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDmg(int damage)
    {
        bossCurrHealth -= damage;
        FlashColor(flashtime);
    }

    void FlashColor(float time)
    {
        sr.color = Color.red;
        Invoke("ResetColor", time);
    }

    void ResetColor()
    {
        sr.color = originalColor;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Monk")
        {
            collision.gameObject.GetComponent<PlayerHPManager>().HurtPlayer(bossDmg);
        }
    }


}
