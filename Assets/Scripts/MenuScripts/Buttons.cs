using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using TMPro;
using System.Runtime.CompilerServices;

public class Buttons : MonoBehaviour
{
    public TextMeshProUGUI bestPlayer;
    public TMP_InputField nameField;
    public void startButton()
    {
        SceneManager.LoadScene(1);
    }
    public void quitButton()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void OnNameSelect()
    {
        menuManager.Instance.currentPlayer = nameField.text;
    }
    void Start()
    {
        bestPlayer.text = $"Best Score : {menuManager.Instance.savedName} : {menuManager.Instance.savedScore}";
    }
}
