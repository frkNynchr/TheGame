using System;
using UnityEngine;
using UnityEngine.UI;

public class floorTrigger : MonoBehaviour
{
    MyCharacter ch;
    void Start()
    {
        ch = transform.root.gameObject.GetComponent<MyCharacter>();
    }
    void OnTriggerEnter2D()
    {
        ch.isFloor = true;
    }
    void OnTriggerStay2D()
    {
        ch.isFloor = true;
    }
    void OnTriggerExit2D()
    {
        ch.isFloor = false;
    }
}
