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
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "floor")
        {
            ch.isFloor = true;
        }
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "floor") ch.isFloor = true;
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "floor") ch.isFloor = false;
    }
}
