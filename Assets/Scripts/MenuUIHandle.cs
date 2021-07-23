using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandle : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] InputField nameInput;
    public Text HighScoreText;
    private void Start()
    {
        string highScoreName = MainManager.Instance.highScoreName;
        int highScore = MainManager.Instance.highScore;
        ChangeHighScoreText(highScoreName, highScore);
    }

    void ChangeHighScoreText(string highScoreName, int highScore)
    {
        HighScoreText.text = "Best score: " + highScoreName + ": " + highScore;
    }

    public void Play()
    {
        getNameInput();
        if (MainManager.Instance.name != "")
        {
            SceneManager.LoadScene(1);
        }
        
    }

    public void Exit()
    {
        MainManager.Instance.SaveHighScore();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }

    void getNameInput()
    {
        MainManager.Instance.name = nameInput.text;
    }
}
