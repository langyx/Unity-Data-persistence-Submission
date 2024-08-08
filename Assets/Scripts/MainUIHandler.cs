using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainUIHandler : MonoBehaviour
{
    public TextMeshProUGUI highScoreText;

    // Start is called before the first frame update
    void Start()
    {
        NewHighScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewHighScore()
    {
        if (PlayerSettingManager.Instance != null)
        {
            highScoreText.text = PlayerSettingManager.Instance.GetHighScoreMessage();
        }
    }
}
