using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehavior : MonoBehaviour
{
    [SerializeField] private GameObject doorGameObject1;
    [SerializeField] private GameObject doorGameObject2;
    [SerializeField] private GameObject doorGameObject3;
    private iDoor door1;
    private iDoor door2;
    private iDoor door3;

    private void Awake()
    {
        door1 = doorGameObject1.GetComponent<iDoor>();
        door2 = doorGameObject2.GetComponent<iDoor>();
        door3 = doorGameObject3.GetComponent<iDoor>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<Locomotion>() != null)
        {
            door1.OpenDoor();
            door2.OpenDoor();
            door3.OpenDoor();
        }
    }
}
