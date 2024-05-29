using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI score;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void UpdateScore(int scoreP1, int scoreP2)
    {
        score.text = scoreP1 + " : " + scoreP2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
