using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruyeBloques : Controller_Player
{
    public override void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bloque"))
        {
            if(onFloor == false)
            {
                Destroy(collision.gameObject);
            }
        }

    }
}
