using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIContoller : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreValue;
    [SerializeField] private Image healthBar;
    [SerializeField] private Image crossHair;
    [SerializeField] private OptionPopup optionsPopup;
    [SerializeField] private SettingPopup settingPopup;

    private int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        updateScore(score);
        healthBar.fillAmount = 1;
        healthBar.color = Color.green;
        SetGameActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !optionsPopup.IsActive() && !settingPopup.IsActive())
        {
            SetGameActive(false);
            optionsPopup.Open();
        }
    }

    public void SetGameActive(bool active)
    {
        if (active)
        {
            Time.timeScale = 1; // unpause the game
            Cursor.lockState = CursorLockMode.Locked; // lock the cursor
            Cursor.visible = false;
            crossHair.gameObject.SetActive(true); // display the crosshair
        } else
        {
            Time.timeScale = 0; // pause the game
            Cursor.lockState = CursorLockMode.None; // unlock the cursor
            Cursor.visible = true;
            crossHair.gameObject.SetActive(false); // hide the crosshair
        }
    }

    public void updateScore(int newScore)
    {
        scoreValue.text = newScore.ToString();
    }
}
