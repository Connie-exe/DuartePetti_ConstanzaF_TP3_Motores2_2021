using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFromPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            this.GetComponent<Light>().enabled = true;

        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            this.GetComponent<Light>().enabled = false;
        }
    }

}
