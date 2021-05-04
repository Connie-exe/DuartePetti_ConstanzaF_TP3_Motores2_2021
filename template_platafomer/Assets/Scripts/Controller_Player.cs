using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_Player : MonoBehaviour
{
    public float jumpForce = 10;//se declara la fuerza de salto que vale 10f

    public float speed = 5;//se declara la velocidad que vale 5

    public int playerNumber; //se declara el número de jugador

    public Rigidbody rb;//se declara el rigidbody

    private BoxCollider col;//se declara el box collider

    public LayerMask floor;//se declara el layermask(actuará como el suelo)

    internal RaycastHit leftHit,rightHit,downHit;

    public float distanceRay,downDistanceRay;

    private bool canMoveLeft, canMoveRight,canJump;//bools de confirmación
    internal bool onFloor;//bool de confirmación

    private void Start()
    {
        rb = GetComponent<Rigidbody>();//se llama al rigidbody
        col = GetComponent<BoxCollider>();//se llama al collider
        rb.constraints = RigidbodyConstraints.FreezePositionX| RigidbodyConstraints.FreezePositionZ|RigidbodyConstraints.FreezeRotation;//se dice setea que el rigidbody no puede moverse sobre le eje x, ni sobre le eje y. Y tampoco puede rotar.
    }

    public virtual void FixedUpdate()
    {
        if (GameManager.actualPlayer == playerNumber)//si el jugador actual del GameManager es igual al número del player en ese script
        {
            Movement();//llama a la clase Movement
        }
    }

    private void Update()
    {
        if (GameManager.actualPlayer == playerNumber)//si el jugador actual del GameManager es igual al número del player en ese script
        {
            Jump();//llama a la función ]Jump
            if (SomethingLeft())//si la función SomethingLeft es true
            {
                canMoveLeft = false;//el bool canMoveLeft es false
            }
            else//se lo contrario
            {
                canMoveLeft = true;//el bool canMoveLeft es true
            }
            if (SomethingRight())//si la función SomethingRight es true
            {
                canMoveRight = false;//el bool canMoveRight es false
            }
            else//de lo contrario
            {
                canMoveRight = true;//el bool canMoveRight es true
            }

            if (IsOnSomething())//si la función IsOnSomething es true
            {
                canJump = true;//el bool canJump es true
            }
            else//de lo contrario
            {
                canJump = false;//el bool canJump es false
            }

        }
        else//de lo contrario
        {
            if (onFloor)//si el bool onFloor es true
            {
                rb.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;//el rigidbody no puede moverse ni rotar
            }
            else//de lo contrario
            {
                if (IsOnSomething())//si la clase IsOnSomething es true
                {
                    if (downHit.collider.gameObject.CompareTag("Player"))
                    {
                        rb.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;//el rigidbody no puede moverse en el eje z y no puede rota
                    }
                }
            }
        }
    }




    public virtual bool IsOnSomething()
    {
        return Physics.BoxCast(transform.position, new Vector3(transform.localScale.x * 0.9f, transform.localScale.y/3,transform.localScale.z*0.9f), Vector3.down, out downHit, Quaternion.identity, downDistanceRay);
    }

    public virtual bool SomethingRight()
    {
        Ray landingRay = new Ray(new Vector3(transform.position.x,transform.position.y-(transform.localScale.y / 2.2f),transform.position.z), Vector3.right);
        Debug.DrawRay(landingRay.origin, landingRay.direction, Color.green);
        return Physics.Raycast(landingRay, out rightHit, transform.localScale.x/1.8f);
    }

    public virtual bool SomethingLeft()
    {
        Ray landingRay = new Ray(new Vector3(transform.position.x, transform.position.y - (transform.localScale.y/2.2f), transform.position.z), Vector3.left);
        Debug.DrawRay(landingRay.origin, landingRay.direction, Color.green);
        return Physics.Raycast(landingRay, out leftHit, transform.localScale.x/1.8f);
    }

    private void Movement()
    {
        if (Input.GetKey(KeyCode.A) && canMoveLeft)//si se presiona la tecla a y canMoveLeft es true
        {
                rb.velocity = new Vector3(1 * -speed , rb.velocity.y, 0);//el rigidbody se mueve con el valor de speed hacia x negativa (izquierda)
        }
        else if (Input.GetKey(KeyCode.D) && canMoveRight)// de lo contrario si se presiona la tecla d y canMoveRight es true
        {
                rb.velocity = new Vector3(1 * speed, rb.velocity.y, 0);//el rigidbody se mueve con el valor de speed hacia x positiva (derecha)
        }
        else //de lo contrario
        {
            rb.velocity = new Vector3(0, rb.velocity.y, 0);//el rigidbody se mueve hacia arriba
        }
        //if (!canMoveLeft)
        //    rb.velocity = new Vector3(0, rb.velocity.y, 0);
        //if (!canMoveRight)
        //    rb.velocity = new Vector3(0, rb.velocity.y, 0);
    }

    public virtual void Jump()
    {
        if (Input.GetKeyDown(KeyCode.W))//si se presiona la tecla w
        {
            if (canJump)//si canJump es true
            {
                rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);//el rigidbody salta con la fuerza de jumpforce, forcemode especifica como aplicar la fuerza en el rigidbody. Impulse aplica la fuerza utilizando la misma masa del rigidbody
            }
        }
    }

    public virtual void OnCollisionEnter(Collision collision)//si el objeto colisiona con...
    {
        if (collision.gameObject.CompareTag("Water"))//con el objeto de etiqueta Water
        {
            Destroy(this.gameObject);//se destruye este objeto
            GameManager.gameOver = true;//el bool gameover del script GameManager se vuelve true
        }
        if (collision.gameObject.CompareTag("Floor"))//con el objeto de etiqueta Floor
        {
            onFloor = true;//el bool onFloor vale true
        }

    }

    private void OnCollisionExit(Collision collision)//si este objeto deja de colisionar con...
    {
        if (collision.gameObject.CompareTag("Floor"))//con el objeto de etiqueta Floor
        {
            onFloor = false;//el bool onFloor vale false
        }
    }
}
