using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIHandler : MonoBehaviour
{
    public TextMeshProUGUI highScoreText;
    public TMP_InputField userNameInputField;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerSettingManager.Instance != null)
        {
            highScoreText.text = PlayerSettingManager.Instance.GetHighScoreMessage();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartNew()
    {
        if (PlayerSettingManager.Instance != null)
        {
            PlayerSettingManager.Instance.userName = userNameInputField.text;
        }
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
