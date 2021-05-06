using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinuosEnemies : MonoBehaviour
{
    public Transform startpos;
    public Transform target;


    public float moveSpeed = 5; //move speed
    public float rotationSpeed = 5; //speed of turning
    private Rigidbody rb;
    //private Vector3 mytransform;

    void Update()
    {
        //transform.position = Vector3.Lerp(startpos.position, target.position, Time.time);
        //transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 03f);

        //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target.position - transform.position), rotationSpeed * Time.deltaTime);


        //move towards the player
        transform.position += target.position * Time.deltaTime * moveSpeed;
    }

    public virtual void OnCollisionEnter(Collision collision)//si el objeto colisiona con...
    {
        if (collision.gameObject.CompareTag("Limit"))//con el objeto de etiqueta Water
        {
            Destroy(this.gameObject);//se destruye este objeto
        }
    }
}
