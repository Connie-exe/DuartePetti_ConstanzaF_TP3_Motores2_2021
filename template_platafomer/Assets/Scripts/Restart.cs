using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//para poder acceder a las escenas de unity

public class Restart : MonoBehaviour
{
    void Update()
    {
        GetInput();//se llama a la clase 
    }

    private void GetInput()
    {
        if (Input.GetKeyDown(KeyCode.R))//si se presiona la tecla r
        {
            Time.timeScale = 1;//el tiempo transurre con normalidad
            SceneManager.LoadScene(0);//la escena 0 vuelve a cargarse
        }
    }
}
