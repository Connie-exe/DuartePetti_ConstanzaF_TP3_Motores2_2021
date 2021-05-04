using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool gameOver = false;//se declara el bool de confirmación gameover como false

    public static bool winCondition = false;//se declara el bool de confirmación winCondition como false

    public static int actualPlayer = 0;//se declara el integer de actuaPlayer que vale 0

    public List<Controller_Target> targets;//se declara una lista de targets

    public List<Controller_Player> players;//se declara una lista de players

    void Start()
    {
        Physics.gravity = new Vector3(0, -30, 0);//se setea la gravedad con una fuerza de 30
        gameOver = false;//se inicializa el bool en false
        winCondition = false;//se inicializa el bool en false
        SetConstraits();//se llama a la clase SetConstraits
    }

    void Update()
    {
        GetInput();//se llama a la clase GetInput
        CheckWin();//se llama a la clase CheckWin

    }

    private void CheckWin()
    {
        int i = 0;//se inicializa i en 0
        foreach(Controller_Target t in targets)//por cada player en target
        {
            if (t.playerOnTarget)//si playerOnTarget es true
            {
                i++;//i aumenta en 1
                //Debug.Log(i.ToString());
            }
        }
        if (i >= 7)//si i vale más o igual que 7
        {
            winCondition = true;//el bool de wincondition pasa a valer true
        }
    }

    private void GetInput()
    {
        if (Input.GetKeyDown(KeyCode.Q))//si se presiona la tecla q
        {
            if (actualPlayer <= 0)//si actualPlayer es menor o igual a 0
            {
                actualPlayer = 6;//actual player valerá 6
                SetConstraits();//se llama a la clase SetConstraits
            }
            else//de lo contrario
            {
                actualPlayer--;//actual player disminuirá en uno (cada vez que se toque la tela q)
                SetConstraits();//se llama al clase SetConstraits
            }
        }
        if (Input.GetKeyDown(KeyCode.E))//si se presiona la tecla e
        {
            if (actualPlayer >= 6)//si el actual player es mayor o igual a 6
            {
                actualPlayer = 0;//actual player pasa a valer 0
                SetConstraits();//se llama a la clase SetConstraits
            }
            else//de lo contrario
            {
                actualPlayer++;//actual player aumentará en uno (cada vez que se toque la tela e)
                SetConstraits();//se llama a la clase SetConstraits
            }
        }
    }

    private void SetConstraits()
    {
        foreach(Controller_Player p in players)//para cada uno que esté en players
        {
            if (p == players[actualPlayer])//si p es igual al actual player de la lista players
            {
                p.rb.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;//el objeto no podrá moverse en el eje z y tampoco po´drá rotar
            }
            else//de lo contrario
            {
                p.rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;//el objeto no podrá moverse en el eje x, no z, y tampoco podrá rotar 
            }
        }
    }
}
