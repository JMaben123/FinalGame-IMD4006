using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuControl : MonoBehaviour
{
    public GameObject tut;
    public void PlayGame()
    {
        SceneManager.LoadScene("MainGameScene");
        Time.timeScale = 1;
    }

    public void CloseGame()
    {
        Application.Quit();
    }

    public void ShowTutorial()
    {
        tut.SetActive(true);
    }
    public void QuitToTitle()
    {
        SceneManager.LoadScene("StartScene");
        GlobalDataManager.globalDataManager.resetData();

        
        
    }
}
