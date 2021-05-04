using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_Camera : MonoBehaviour
{
    public List<GameObject> players;//declara una lista de players
    private Camera _camera;//declara la cámara
    public float dampTime = 0.15f;
    public float smoothTime = 2f;
    public float zoomvalue;//se declara el valor del zoom
    private Vector3 velocity = Vector3.zero;


    void Start()
    {
        _camera = GetComponent<Camera>();//se llama al componente cámara de unity
    }

    void LateUpdate()
    {
        if (players[GameManager.actualPlayer] != null)//si el player (el player que esté actual en ese momento en el gamenagermanager) es distinto de null
        {
            Vector3 point = _camera.WorldToViewportPoint(players[GameManager.actualPlayer].transform.position);//el point transforma la visión de la cámara en el mundo a la pantalla en este caso en la posición del player actual
            Vector3 delta = players[GameManager.actualPlayer].transform.position - _camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z));
            Vector3 destination = transform.position + delta;
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
        }
    }
}
