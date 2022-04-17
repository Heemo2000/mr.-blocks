using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class LevelUI : MonoBehaviour
{
    [SerializeField]private TMP_Text resultText;
    [SerializeField]private GameObject levelUIPanel;
    [SerializeField]private GameObject pausePanel;
    private bool _isGamePaused;

    public bool IsGamePaused { get => _isGamePaused; }

    private void Start() {
        levelUIPanel.SetActive(false);
        pausePanel.SetActive(false);
    }
    public void ShowResult(bool isWin)
    {
        levelUIPanel.SetActive(true);
        if(isWin)
        {
            resultText.text = "You \nwin!";
        }
        else
        {
            resultText.text = "You \nlose.";
        }
    }

    public void Reload()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void PauseGame()
    {
        
        _isGamePaused = true;
        pausePanel.SetActive(true);
    }

    public void ResumeGame()
    {
        _isGamePaused = false;
        pausePanel.SetActive(false);
    }
}
