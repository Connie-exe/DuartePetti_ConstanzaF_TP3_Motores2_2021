using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallerPlayer : Controller_Player
{
    private Vector3 scaleChange, positionChange, scaleNormal, positionNormal;
    public GameObject player;
    //public float timeUp;
    //public float timeSmaller;

    private bool _sPressed;
    private bool _xPressed;

    public void Awake()
    {
        scaleChange = new Vector3(-0.01f, -1f, -0.01f);
        positionChange = new Vector3(0.0f, 1f, 0.0f);
        scaleNormal = new Vector3(1, 1.5f, 1);
        positionNormal = new Vector3(18.5f, -0.5f, -0.09f);

    }

    public void Start()
    {
        //timeUp = 3f;
        //timeSmaller = 0f;
    }
    public override void FixedUpdate()
    {
        base.FixedUpdate();
        if (Input.GetKeyDown(KeyCode.S))
        {
            GetSmaller();
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            GetBigger();
        }
    }

    //public bool SPressed()
    //{
    //    if (Input.GetKeyDown(KeyCode.S))
    //    {
    //        _sPressed = true;
    //    }
    //    return _sPressed;
    //}

    //public bool XPressed()
    //{
    //    if (Input.GetKeyDown(KeyCode.X))
    //    {
    //        _xPressed = true;
    //    }
    //    return _xPressed;
    //}

    public void GetSmaller()
    {
        player.transform.localScale += scaleChange;
        //player.transform.position += positionChange;

        if (player.transform.localScale.y < 0.1f || player.transform.localScale.y > 1.0f)
        {
            scaleChange = -scaleChange;
            //positionChange = -positionChange;
        }
    }

    public void GetBigger()
    {
        player.transform.localScale = scaleNormal;
        //player.transform.position = positionNormal;

        //if (player.transform.localScale.y < 0.1f || player.transform.localScale.y > 1.0f)
        //{
        //    scaleChange = -scaleChange;
        //    positionChange = -positionChange;
        //}
    }
}
