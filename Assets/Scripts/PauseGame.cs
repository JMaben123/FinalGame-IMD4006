using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{

    public GameObject pauseScreen;

    // Start is called before the first frame update
    void Start()
    {
        EventSystem.Instance.OnGamePause += OnPauseGame;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPauseGame()
    {
        if (!pauseScreen.activeSelf)
        {
            pauseScreen.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            pauseScreen.SetActive(false);
            Time.timeScale = 1;
        }
    }
    
    //Quit game button
    public void QuitGame()
    {
        SceneManager.LoadScene("StartScene"); //Exits current screen and loads the title screen
    }

    private void OnDestroy()
    {
        EventSystem.Instance.OnGamePause -= OnPauseGame;
    }

    public void ResumeGame()
    {
        
    }
}
