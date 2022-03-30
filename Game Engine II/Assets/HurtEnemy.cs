using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemy : MonoBehaviour
{
    public bool hide = true;
    public GameObject[] DamageArea;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            for (int i = 0; i < DamageArea.Length; i++)
            {
                DamageArea[i].SetActive(!hide);
            }
        }
    }
}
