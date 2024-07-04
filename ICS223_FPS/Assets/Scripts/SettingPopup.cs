using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingPopup : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI difficultyValue;
    [SerializeField] Slider difficultySlider;
    [SerializeField] OptionPopup optionPopup;
    // Start is called before the first frame update
    void Start()
    {
        difficultySlider.value = PlayerPrefs.GetInt("difficulty", 1);
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

    public void OnOKButton()
    {
        PlayerPrefs.SetInt("difficulty", (int)difficultySlider.value);
        Close();
        optionPopup.Open();
    }

    public void OnCancelButton()
    {
        difficultySlider.value = PlayerPrefs.GetInt("difficulty", 1);
        UpdateDifficulty(difficultySlider.value);

        Close();
        optionPopup.Open();
    }

    public void UpdateDifficulty(float difficulty)
    {
        difficultyValue.text = difficulty.ToString();
    }

    public void OnDifficultyValueChanged(float difficulty)
    {
        UpdateDifficulty(difficulty);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
