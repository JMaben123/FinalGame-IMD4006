using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalDataManager : MonoBehaviour
{
    public static GlobalDataManager globalDataManager;
    //game phases to control what the player can do at what time
    public enum GameState
    {
        buildPhase,
        actionPhase
    }

    public int phaseTimer;
    public bool phaseActive;

    public GameState currPhase;
    public Scene startScreen;
    public Scene mainGame;
    public Scene endGame;

    public int playerPts;

    public bool quakeActive;

    public float volume = 1f;

    public bool phaseEnding = false;
    public bool nextPhaseStarting = false;

    public int numBlocks = 0;

    public int currLevel;


    private void Awake()
    {
        if(globalDataManager == null)
        {
            DontDestroyOnLoad(gameObject);
            globalDataManager = this;
        }
        else if(globalDataManager != this)
        {
            Destroy(gameObject);
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        quakeActive = false;
        phaseActive = true;
        currPhase = GameState.buildPhase;
        currLevel = 0;
        //SceneManager.SetActiveScene(startScreen);
        StartCoroutine(phaseTimerCount());

       
    }

    // Update is called once per frame
    void Update()
    {
        //switch for game state
        if (!phaseActive)
        {
            phaseActive = true;
        }

        if(currPhase == GameState.actionPhase && phaseTimer == 60)
        {
            currPhase = GameState.buildPhase;
            quakeActive = false;
            phaseTimer = 0;
        }
        if(currPhase == GameState.buildPhase && phaseTimer == 60)
        {
            currPhase = GameState.actionPhase;
            quakeActive = true;
            phaseTimer = 0;
        }
    }

    IEnumerator phaseTimerCount()
    {
        while (phaseActive)
        {
            //Debug.Log("+1 phase timer");

            phaseTimer += 1;
            yield return new WaitForSeconds(1f);
        }
    }

    //change what the game state is, if build/action, (re)start timer
    public void setGameState(GameState newPhase)
    {
        currPhase = newPhase;
    }

    //gets the game state to control other scripts
    public GameState getGameState()
    {
        return currPhase;
    }

    void setScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }

    public void resetGame()
    {
        //set points to 0
    }

    public bool getQuake()
    {
        return quakeActive;
    }

}
