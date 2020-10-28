using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUIFunction : MonoBehaviour
{
    public GameObject firstLogin;
    public GameObject secondLogin;
    public GameObject DAInumber;

    public GameObject items;
    public GameObject slots;

    public Texture img1;
    public Texture img2;
    public Texture img3;
    public Texture img4;
    public Texture blackimg;



    private int DAI_number;
    private bool[] itemstatus = new bool[] { false, false, false, false };

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < items.transform.childCount; i++)
        {
            if (items.transform.GetChild(i).GetComponent<Text>().text != "Empty")
            {
                if (itemstatus[i] == false)
                {
                    switch (Random.Range(0, 3))
                    {
                        case 0:
                            slots.transform.GetChild(i).GetComponent<RawImage>().texture = img1;
                            break;
                        case 1:
                            slots.transform.GetChild(i).GetComponent<RawImage>().texture = img2;
                            break;
                        case 2:
                            slots.transform.GetChild(i).GetComponent<RawImage>().texture = img3;
                            break;
                        case 3:
                            slots.transform.GetChild(i).GetComponent<RawImage>().texture = img4;
                            break;
                        default:
                            break;
                    }
                    itemstatus[i] = true;
                }                
            }
            else
            {
                slots.transform.GetChild(i).GetComponent<RawImage>().texture = blackimg;
            }
        }
    }

    public void MetaMaskLoginFunction()
    {
        firstLogin.SetActive(false);
        secondLogin.SetActive(true);
    }

    public void ApproveFunction()
    {
        DAI_number = int.Parse(DAInumber.GetComponent<Text>().text);
        Debug.Log("you enter: " + DAI_number + " DAI");
    }

    public void StakeFunction()
    {
        Debug.Log("dosomthing");
    }
}
