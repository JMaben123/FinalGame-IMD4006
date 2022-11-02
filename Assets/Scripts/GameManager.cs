using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //game phases to control what the player can do at what time
    enum GameState
    {
        startPhase,
        buildPhase,
        actionPhase,
        endPhase,
        paused
    }

    int phaseTimer;
    bool phaseActive;

    GameState currPhase;
    public Scene startScreen;
    public Scene mainGame;
    public Scene endGame;

    // Start is called before the first frame update
    void Start()
    {
        phaseActive = false;
        currPhase = GameState.startPhase;
        SceneManager.SetActiveScene(startScreen);
        StartCoroutine(phaseTimerCount()); 
    }

    // Update is called once per frame
    void Update()
    {
        //switch for game state
        if(currPhase == GameState.actionPhase && phaseTimer == 60)
        {
            setGameState(GameState.buildPhase);
        }
    }

    IEnumerator phaseTimerCount()
    {
        while (phaseActive)
        {
            phaseTimer += 1;
            yield return new WaitForSeconds(1f);
            
        }
    }

    //change what the game state is, if build/action, (re)start timer
    void setGameState(GameState newPhase)
    {
        GameState prevState = currPhase;
        currPhase = newPhase;
        if(newPhase == GameState.actionPhase || newPhase == GameState.buildPhase)
        {
            phaseTimer = 0;
            phaseActive = true;
            Debug.Log(getGameState() + phaseTimer);
        }
        if(newPhase == GameState.paused)
        {
            
        }
    }

    //gets the game state to control other scripts
    GameState getGameState()
    {
        return currPhase;
    }

    void setScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }

}
