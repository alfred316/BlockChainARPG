using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalManager : MonoBehaviour
{
    GameObject PortalOut;
    GameObject PortalIn;

    GameObject InSpawn;
    GameObject OutSpawn;
    // Start is called before the first frame update
    void Start()
    {
        PortalOut = GameObject.FindGameObjectWithTag("PortalOut");
        PortalIn = GameObject.FindGameObjectWithTag("PortalIn");

        InSpawn = GameObject.FindGameObjectWithTag("InSpawn");
        OutSpawn = GameObject.FindGameObjectWithTag("OutSpawn");
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
                other.transform.position = new Vector3(OutSpawn.transform.position.x, other.transform.position.y, OutSpawn.transform.position.z + 3);
            }
        }

        if (transform.tag == "PortalIn")
        {
            if (other.transform.tag == "Player")
            {
                other.transform.position = new Vector3(InSpawn.transform.position.x, other.transform.position.y, InSpawn.transform.position.z - 3);
            }
        }

    }
}
