using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingPopup : BasePopup
{
    [SerializeField] TextMeshProUGUI difficultyValue;
    [SerializeField] Slider difficultySlider;
    [SerializeField] OptionPopup optionPopup;
    // Start is called before the first frame update
    void Start()
    {
        difficultySlider.value = PlayerPrefs.GetInt("difficulty", 1);
    }

    public void OnOKButton()
    {
        PlayerPrefs.SetInt("difficulty", (int)difficultySlider.value);
        Messenger<int>.Broadcast(GameEvent.DIFFICULTY_CHANGED, (int)difficultySlider.value);
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
