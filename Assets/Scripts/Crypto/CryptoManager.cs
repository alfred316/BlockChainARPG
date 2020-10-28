using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;
using UnityEngine.SceneManagement;


public class CryptoManager : MonoBehaviour
{
    public Button connectButton;
    public Button approveButton;
    public Button stakeButton;

    public GameObject firstLogin;
    public GameObject secondLogin;
    public GameObject inputField;

    public GameObject Gates;
    public GameObject Gates1;

    public GameObject statusui;

    //public Text inputField;

    [DllImport("__Internal")]
    private static extern void ConnectToMetaMask(string objectName, string callback);

    [DllImport("__Internal")]
    private static extern void ApproveUSDC(string objectName, string callback, string amount);

    [DllImport("__Internal")]
    private static extern void StakeEntry(string objectName, string callback, string amount);


    // Start is called before the first frame update
    void Start()
    {
        Button btn = connectButton.GetComponent<Button>();
        btn.onClick.AddListener(OnClickConnectMetaMask);

        approveButton.onClick.AddListener(OnClickApproveUSDC);

        stakeButton.onClick.AddListener(OnClickStake);
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    //for button1
    public void OnClickStake() //stake
    {
        //getting text from input field
        //string inputText = inputField.text;
        //int inputText = int.Parse(inputField.GetComponent<Text>().text);

        if (Application.platform == RuntimePlatform.WebGLPlayer)
        {
            StakeEntry(gameObject.name, "StakeEntryCallback", "1000000");
        }
        else
        {
            Debug.Log("DAI has been staked");
            StakeEntryCallback("Switching to main scene");
        }
    }

    //for button2
    public void OnClickApproveUSDC() //approve
    {
        //getting text from input field
        //string inputText = inputField.text;
        //int inputText = int.Parse(inputField.GetComponent<Text>().text);

        if (Application.platform == RuntimePlatform.WebGLPlayer)
        {
            ApproveUSDC(gameObject.name, "ApproveUSDCCallback", "1000000");
        }
        else
        {
            Debug.Log("DAI has been approved");
        }
    }

    public void OnClickConnectMetaMask() //connect mask
    {
        Debug.Log("OnClickConnectMetaMask");

        if (Application.platform == RuntimePlatform.WebGLPlayer)
        {
            ConnectToMetaMask(gameObject.name, "ConnectToMetaMaskCallback");
        }
        else
        {
            ConnectToMetaMaskCallback("Connect To MetaMask Callback from Unity");
        }
    }

    void ConnectToMetaMaskCallback(string data)
    {
        firstLogin.SetActive(false);
        secondLogin.SetActive(true);
    }

    void ApproveUSDCCallback(string data)
    {
    }

    void StakeEntryCallback(string data)
    {
        //SwitchToLandScene();
        Gates.SetActive(true);
        Gates1.SetActive(false);
        secondLogin.SetActive(false);
        statusui.SetActive(true);
        Time.timeScale = 1;
    }

    void SwitchToLandScene()
    {
        //SceneManager.LoadScene("PersistentScene");
        SceneManager.LoadScene("CaveZombies");
    }
}
