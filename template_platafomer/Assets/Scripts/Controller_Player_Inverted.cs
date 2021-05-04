using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_Player_Inverted : Controller_Player
{
    public override void FixedUpdate()
    {
        base.rb.AddForce(new Vector3(0, 30f, 0));//llama al rigidbody y lo setea en el valor 30 en el eje y para esté "arriba"
        base.FixedUpdate();
    }

    public override bool IsOnSomething()
    {
        return Physics.BoxCast(transform.position, new Vector3(transform.localScale.x * 0.9f, transform.localScale.y / 3, transform.localScale.z * 0.9f), Vector3.up, out downHit, Quaternion.identity, downDistanceRay);
    }

    public override void Jump()
    {
        if (IsOnSomething())//si la clase IsOnSomething es true
        {
            if (Input.GetKeyDown(KeyCode.W))//si se presiona la tecla w
            {
                rb.AddForce(new Vector3(0, -jumpForce, 0), ForceMode.Impulse);//el rigidbody se mueve hacia abajo con la fuerza de jumpforce en negativo (para que se mueva hacia abajo)
            }
        }
    }
}
