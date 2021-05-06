using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaDrops : MonoBehaviour
{
    public virtual void OnCollisionEnter(Collision collision)//si el objeto colisiona con...
    {
        if (collision.gameObject.CompareTag("Water"))//con el objeto de etiqueta Water
        {
            Destroy(this.gameObject);//se destruye este objeto
        }
        if (collision.gameObject.CompareTag("Floor"))//con el objeto de etiqueta Water
        {
            Destroy(this.gameObject);//se destruye este objeto
        }
    }
}
