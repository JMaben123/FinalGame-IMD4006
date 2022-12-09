using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{

    public GameObject gameOverScreen;
    public TextMeshProUGUI pointsText;
    // Start is called before the first frame update
    void Start()
    {
        EventSystem.Instance.OnGameOver += OnGameIsOver;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnGameIsOver()
    {
        GlobalDataManager.globalDataManager.setGameOver(true);
        gameOverScreen.SetActive(true);        
        Debug.Log("GAMEOVER");
        Time.timeScale = 0;
        pointsText.SetText("Score: \n" + calcFinalPoints());
    }

    int calcFinalPoints()
    {
        int inventoryPts = GlobalDataManager.globalDataManager.inventoryWood + GlobalDataManager.globalDataManager.inventoryBrick + GlobalDataManager.globalDataManager.inventorySteel;
        int totalPts = (inventoryPts + GlobalDataManager.globalDataManager.playerPts + (GlobalDataManager.globalDataManager.numBlocks * 3)) * GlobalDataManager.globalDataManager.currLevel;
        return totalPts;
    }

    private void OnDestroy()
    {
        EventSystem.Instance.OnGameOver -= OnGameIsOver;
    }
}
