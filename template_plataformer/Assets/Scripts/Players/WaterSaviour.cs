using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSaviour : Controller_Player
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletForce = 20f;
    void Start()
    {
        
    }

    // Update is called once per frame
    public override void FixedUpdate()
    {
        base.FixedUpdate();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }
    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);//el gameobject bullet es igual a el bullet prefab en la posición del firepoint y con la rotación de firepoint 
        Rigidbody rb = bullet.GetComponent<Rigidbody>();//rigidbody es igual a el rigidbody de bullet
        rb.AddForce(firePoint.right * -bulletForce, ForceMode.Impulse);//el rigidbody se mueve hacia adelante con la fuerza de bullet
    }

}
