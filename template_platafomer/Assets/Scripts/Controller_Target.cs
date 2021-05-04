using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_Target : MonoBehaviour
{
    public int targetNumber;// se declara el integer del número del objetivo

    public bool playerOnTarget;//se declara el bool de confirmación para ver si el player es el objetivo o no

    private void Start()
    {
        playerOnTarget = false;//el bool vale false
    }

    private void OnTriggerEnter(Collider other)//si el objeto colisiona con...
    {
        if (other.gameObject.CompareTag("Player"))//el objeto de etiqueta Player
        {
            if (other.GetComponent<Controller_Player>().playerNumber == targetNumber)//si el número de player del Controller_Player es igual al número de objetivo
            {
                playerOnTarget = true;//el bool pasa a valer true
                //Debug.Log("P on T");
            }
        }
    }

    private void OnTriggerExit(Collider other)//si el objeto deja de colionar con...
    {
        if (other.gameObject.CompareTag("Player"))//el objeto con la etiqueta Player
        {
            if (other.GetComponent<Controller_Player>().playerNumber == targetNumber)//si el número de player de Controller_Player es iual a al número de objetivo
            {
                playerOnTarget = false;//el bool pasa a ser false
                //Debug.Log("P off T");
            }
        }
    }
}
