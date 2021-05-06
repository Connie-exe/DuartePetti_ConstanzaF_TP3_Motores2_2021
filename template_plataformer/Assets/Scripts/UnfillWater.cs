using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnfillWater : MonoBehaviour
{


    public GameObject water;
    private Animation anim;

    void Start()
    {

        water = GameObject.Find("Door_Sliding");
        anim = gameObject.GetComponent<Animation>();

    }


     public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            anim.Play("unfillingWater");
        }
    }
    
}
