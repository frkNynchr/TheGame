using UnityEngine;
using System.Collections;
using UnityEngine.TextCore.Text;

public class CharAndroid : MonoBehaviour
{
    MyCharacter cr;
    void Start()
    {
        cr = GetComponent<MyCharacter>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void left()
    {
        cr.leftB = true;
    }
    public void right()
    {
        cr.rightB = true;
    }
    public void leftUp()
    {
        cr.leftB = false;
    }
    public void rightUp()
    {
        cr.rightB = false;
    }
    public void jump()
    {
        if (cr.isFloor)
        {
            cr.Jump();
            cr.dJump = true;
        }
        else
        {
            if (cr.dJump)
            {
                cr.Jump();
                cr.dJump = false;
            }
        }
    }

}
