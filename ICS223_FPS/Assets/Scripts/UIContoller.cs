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
    [SerializeField] private GameOverPopup gameOverPopup;

    private int score = 0;
    private int popupsActive = 0;
    // Start is called before the first frame update

    private void Awake()
    {
        Messenger<float>.AddListener(GameEvent.HEALTH_CHANGED, OnHealthChange);
        Messenger.AddListener(GameEvent.POPUP_OPENDED, OnPopupOpened);
        Messenger.AddListener(GameEvent.POPUP_CLOSED, OnPopupClosed);
    }

    private void OnDestroy()
    {
        Messenger<float>.RemoveListener(GameEvent.HEALTH_CHANGED, OnHealthChange);
        Messenger.RemoveListener(GameEvent.POPUP_OPENDED, OnPopupOpened);
        Messenger.RemoveListener(GameEvent.POPUP_CLOSED, OnPopupClosed);
    }

    void Start()
    {
        updateScore(score);
        UpdateHealth(1.0f);
        SetGameActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && popupsActive == 0)
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
            Messenger.Broadcast(GameEvent.GAME_ACTIVE);
        } else
        {
            Time.timeScale = 0; // pause the game
            Cursor.lockState = CursorLockMode.None; // unlock the cursor
            Cursor.visible = true;
            crossHair.gameObject.SetActive(false); // hide the crosshair
            Messenger.Broadcast(GameEvent.GAME_INACTIVE);
        }
    }

    private void OnPopupOpened()
    {
        if (popupsActive == 0)
        {
            SetGameActive(false);
        }
        popupsActive++;
    }

    private void OnPopupClosed()
    {
        popupsActive--;
        if (popupsActive == 0)
        {
            SetGameActive(true);
        }
    }

    private void OnHealthChange(float healthPercentage)
    {
        UpdateHealth(healthPercentage);
    }

    private void UpdateHealth(float healthPercentage)
    {
        healthBar.fillAmount = healthPercentage;
        healthBar.color = Color.Lerp(Color.red, Color.green, healthPercentage);
    }

    public void updateScore(int newScore)
    {
        scoreValue.text = newScore.ToString();
    }

    public void ShowGameOverPopup()
    {
        gameOverPopup.Open();
    }
}
