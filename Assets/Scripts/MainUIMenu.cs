using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.SceneManagement;

public class MainUIMenu : MonoBehaviour
{

    public TMP_InputField _playerNameInput;
    public int _topScore;
    public TextMeshProUGUI _topScoreText;

    private void Start()
    {
        if (DataSaver.Instance._topScore != 0)
        {
            _topScoreText.text = DataSaver.Instance._topScoreText;
        }
        _playerNameInput.text = DataSaver.Instance._playerName;

    }

    public void Play()
    {
        DataSaver.Instance._playerName = _playerNameInput.text;
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        //test for topscore
        DataSaver.Instance._topScoreText = "Top Score: " + "SenpaiVR" + " (" + _topScore + ")";
        DataSaver.Instance._playerName = _playerNameInput.text;
        DataSaver.Instance.SaveInfo();

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif

    }
}
