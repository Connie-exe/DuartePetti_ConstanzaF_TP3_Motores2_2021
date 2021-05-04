using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_Player_Trampoline : Controller_Player
{
    public float trampolineForce;//se declara la fuerza del trampolín

    public override void OnCollisionEnter(Collision collision)//si el objeto con...
    {
        if (collision.gameObject.CompareTag("Player"))//con el objeto de etiqueta Player
        {
            Rigidbody rigidbody = collision.gameObject.GetComponent<Rigidbody>();//se llama al rigidbody del objeto
            rigidbody.AddForce(new Vector3(0, jumpForce * trampolineForce, 0), ForceMode.Impulse);//y el rigidbody se mueve hacia arriba multiplicando la fuerza del salto y la fuerza del trampolín
        }
        base.OnCollisionEnter(collision);
    }
}
