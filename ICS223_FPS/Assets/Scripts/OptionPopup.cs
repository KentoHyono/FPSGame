using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionPopup : MonoBehaviour
{
    [SerializeField] private UIContoller contoller;
    [SerializeField] private SettingPopup settingPopup;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void Open()
    {
        gameObject.SetActive(true);
    }
    public void Close()
    {
        gameObject.SetActive(false);
    }
    public bool IsActive()
    {
        return gameObject.activeSelf;
    }
    public void OnSettingsButton()
    {
        Close();
        settingPopup.Open();
    }
    public void OnExitGameButton()
    {
        Debug.Log("Exit game");
        Application.Quit();
    }
    public void OnReturnToGameButton()
    {
        Debug.Log("Return to game");
        contoller.SetGameActive(true);
        Close();
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
