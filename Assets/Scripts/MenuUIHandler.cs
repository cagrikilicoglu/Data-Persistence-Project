using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    public InputField usernameInput;
    public TextMeshProUGUI highScoreText;


    public void Start()
    {
        GetHighScore();
    }

    public void GetUserName()
    {
        PersistenceManager.Instance.nameString = usernameInput.text;
    }

    public void GetHighScore()
    {
        highScoreText.text = "High Score : " + PersistenceManager.Instance.highScoreUser + " : " + PersistenceManager.Instance.highScore;
        
    }


    public void StartNew()
    {
        SceneManager.LoadScene(1);
        GetUserName();
    }
    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void ShowHighScores()
    {
        SceneManager.LoadScene(2);
    }

    public void GoBackToMainMenu ()
    {
        SceneManager.LoadScene(0);
    }
}
