using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalManager : MonoBehaviour
{
    GameObject PortalOut;
    GameObject PortalIn;
    // Start is called before the first frame update
    void Start()
    {
        PortalOut = GameObject.FindGameObjectWithTag("PortalOut");
        PortalIn = GameObject.FindGameObjectWithTag("PortalIn");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(transform.tag == "PortalOut")
        {
            if (other.transform.tag == "Player")
            {
                other.transform.position = PortalIn.transform.position + new Vector3(0, 0, 3);
            }
        }

        if (transform.tag == "PortalIn")
        {
            if (other.transform.tag == "Player")
            {
                other.transform.position = PortalOut.transform.position - new Vector3(0, 0, 3);
            }
        }

    }
}
