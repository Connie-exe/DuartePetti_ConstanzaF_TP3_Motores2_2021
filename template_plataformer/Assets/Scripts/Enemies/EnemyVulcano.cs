using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVulcano : MonoBehaviour
{
    public int numberOfProjectiles;//se declara el n´mero de proyectiles
    public float projectileSpeed;//se declara la velocidad de los proyectiles
    public GameObject hellbullet;//se declara al gameobject que representará a las hellbullets

    private Vector3 startPos;//se declara la posición inicial
    private const float radius = 1f;//se declara el radio que vale 1df

    public float timeUp;
    public float timeToShoot;
    void Start()
    {
        timeUp = 3f;
        timeToShoot = 0f;

    }

    void Update()
    {
        if (timeToShoot >= timeUp)
        {
            startPos = transform.position;//la posición inicial va a ser la popsición del objeto
            SpawnProjectile(numberOfProjectiles);//se llama a la clase SpawnProjectile
            timeToShoot = 0f;
        }
        timeToShoot += Time.deltaTime;

    }

    private void SpawnProjectile(int numberOfProjectiles)//la clase tiene como valor el integer del número de proyectiles que devuelve
    {
        float angleShoot = 360 / numberOfProjectiles;//se divide al float de angleshoot (que representa el área de 360 grado alrededor del shooter) por la cantidad de proyectiles
        float angle = 0f;//se inicializa el angle
        for (int i = 0; i <= numberOfProjectiles - 1; i++)//i inicia valiendo 0 y hasta que valga menor o igual al número de proyectiles menos 1 irá aumentando de a uno
        {
            //utilizando las dunciones de seno y coseno de math se posiciona el lugar de las balas
            float projectileXPos = startPos.x + Mathf.Sin((angle * Mathf.PI) / 180 * radius);
            float projectileZPos = startPos.z + Mathf.Cos((angle * Mathf.PI) / 180 * radius);

            Vector3 projectileVector = new Vector3(projectileXPos, projectileZPos, 0);//ahora se pasan los valores aun vector3 para que estén en el espacio
            Vector3 projectileMoveDirection = (projectileVector - startPos).normalized * projectileSpeed;//y se multiplica la dirección en la que se mueven en el espacio por la velocidad del proyectil (.normalized es para suavizar los movimientos y que quede más bonito)

            GameObject obj = Instantiate(hellbullet, startPos, Quaternion.identity);//se instancia en esa posición al prefab que representa a la hellbullet en unity
            obj.GetComponent<Rigidbody>().velocity = new Vector3(projectileMoveDirection.x, 0, projectileMoveDirection.z);//se llama al rigidbody (función de su velocidad) y se le da el valor del vector3 con los valores de direccón de la hellbullet

            angle += angleShoot;//al angle se le suma en cada vuelta el angleshoot 
        }
    }
}
