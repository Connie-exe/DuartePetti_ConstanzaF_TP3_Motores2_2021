using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//para poder usar la ui

public class Controller_Hud : MonoBehaviour
{
    public Text gameOverText;//se declara el text

    void Start()
    {
        gameOverText.gameObject.SetActive(false);//se desactiva el text
    }

    void Update()
    {
        if (GameManager.gameOver)//si el gameover de GameManager es true
        {
            Time.timeScale = 0;//el tiempo deja de transcurrir
            gameOverText.text = "Game Over" ;//el text de game over escribe lo que dice entre comillas
            gameOverText.gameObject.SetActive(true);//el text de gameover se activa y aparece en pantalla
        }
        if (GameManager.winCondition)//si la win condition de GameManager es true
        {
            Time.timeScale = 0;//el tiempo deja de transcurrir
            gameOverText.text = "You Win";//el text gameover escribe lo qe dice en comillas
            gameOverText.gameObject.SetActive(true);//el text se activa y aparece en pantalla
        }
    }
}
