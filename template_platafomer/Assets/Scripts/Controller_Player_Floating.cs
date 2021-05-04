using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_Player_Floating : Controller_Player
{
    public override void OnCollisionEnter(Collision collision)//si el objeto colisiona con...
    {
        if (collision.gameObject.CompareTag("Floor"))//con un objeto con etiqueta Floor
        {
            onFloor = true;//el bool onFloor vale true
        }
        //This makes the player invulnerable to water.
    }
}
