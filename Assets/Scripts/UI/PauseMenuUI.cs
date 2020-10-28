using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuUI : MonoBehaviour
{
    public GameObject PauseUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (PauseUI.activeInHierarchy)
            {
                PauseUI.SetActive(false);
                Time.timeScale = 1;
            }
            else if (!PauseUI.activeInHierarchy)
            {
                PauseUI.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }
}
