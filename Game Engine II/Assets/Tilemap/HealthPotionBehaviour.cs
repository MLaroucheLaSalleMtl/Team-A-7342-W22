using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotionBehaviour : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<PlayerHPManager>().playerCurrentHP < 10)
        {
            collider.GetComponent<PlayerHPManager>().playerCurrentHP++;
            Destroy(gameObject);
        }
        else
        {
            return;
        }
    }
}
