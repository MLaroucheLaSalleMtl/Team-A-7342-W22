using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotionBehaviour : MonoBehaviour
{
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.GetComponent<PlayerHPManager>().playerCurrentHP<10)
        {
            collider.GetComponent<PlayerHPManager>().playerCurrentHP++;
            Destroy(gameObject);
        }
        else
        {
            return;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
