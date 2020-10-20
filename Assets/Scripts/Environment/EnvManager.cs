using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvManager : MonoBehaviour
{
    public BreakableEnv envWall;

    // Start is called before the first frame update
    void Start()
    {
        envWall = new BreakableEnv();
    }

    // Update is called once per frame
    void Update()
    {
        if(envWall.GetIsBroken())
        {
            Destroy(gameObject);
        }
    }

}
