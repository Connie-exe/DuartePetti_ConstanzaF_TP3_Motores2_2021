using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_Player_DoubleJump : Controller_Player
{
    private int jumpCounter=0;//se declara un contador de saltos

    public override bool IsOnSomething()
    {
        return Physics.BoxCast(transform.position, new Vector3(transform.localScale.x * 0.9f, transform.localScale.y / 3, transform.localScale.z * 0.9f), Vector3.down, out downHit, Quaternion.identity, downDistanceRay);
    }

    public override void Jump()
    {
        if (IsOnSomething())//si la clase IsOnSomething() es true 
        {
            if (Input.GetKeyDown(KeyCode.W))//si se presiona la tecla w
            {
                jumpCounter = 1;//el contador pasa a valer 1
                rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);//el rigidbody se mueve hacia arriba con la fuerza de jumpforce 
            }
        }
        else//de lo contrario
        {
            if (Input.GetKeyDown(KeyCode.W))//si se presiona la tecla w
            {
                if (jumpCounter > 0)//y el contador de saltos vale más que 0
                {
                    rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);//el rigidbody se mueve hacia arriba con la fuerza de jumpforce 
                    jumpCounter--;//al contador se le resta 1
                }
            }
        }
    }
}
