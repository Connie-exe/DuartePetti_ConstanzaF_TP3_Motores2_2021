using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonedWater : MonoBehaviour
{
    public Material poisonedWater;//se declara el material poisonedWater
    private Renderer render;

    void Start()
    {
        poisonedWater = GetComponent<Material>();
        render = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public virtual void OnCollisionEnter(Collision collision)//si el objeto colisiona con...
    {
        if (collision.gameObject.CompareTag("Poisoner"))//si el objeto colisiona con otro objeto de etiqueta zombie bullet
        {
            Debug.Log("Now the water is poisoned");//se escribe en consola que ahora es poisoned
            transform.gameObject.tag = "PoisonedWater";//la etiqueta de este objeto cambia a PoisonedWater
            //transform.gameObject.layer = 13;//el layer de este objeto cambia a 13
            this.GetComponent<MeshRenderer>().material = poisonedWater;//el material de este objeto cambia a colorzombie
        }
        if (collision.gameObject.CompareTag("Potion"))//si el objeto colisiona con otro objeto de etiqueta zombie bullet
        {
            Debug.Log("Now the water is cured");//se escribe en consola que ahora es poisoned
            transform.gameObject.tag = "Water";//la etiqueta de este objeto cambia a PoisonedWater
            //transform.gameObject.layer = 13;//el layer de este objeto cambia a 13
        }
    }
}
