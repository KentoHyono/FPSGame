using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionPopup : BasePopup
{
    [SerializeField] private SettingPopup settingPopup;

    // Start is called before the first frame update
    void Start()
    {
        
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
        Close();
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
