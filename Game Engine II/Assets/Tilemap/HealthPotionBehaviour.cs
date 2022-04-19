using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotionBehaviour : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<PlayerHPManager>().playerCurrentHP < collider.GetComponent<PlayerHPManager>().playerMaxHP)
        {
            collider.GetComponent<PlayerHPManager>().playerCurrentHP += 2;
            Destroy(gameObject);
        }
        else
        {
            return;
        }
    }
}
