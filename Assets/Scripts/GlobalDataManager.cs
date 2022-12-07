using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalDataManager : MonoBehaviour
{
    public static GlobalDataManager globalDataManager;
    public TextMeshProUGUI timerText;
    //game phases to control what the player can do at what time
    public enum GameState
    {
        buildPhase,
        actionPhase
    }
    public enum AvailableBlocks
    {
        BASE_LIGHT,
        BASE_NORMAL,
        BASE_HEAVY,
        MID_LIGHT,
        MID_NORMAL,
        MID_HEAVY,
        TOP_LIGHT,
        TOP_NORMAL,
        TOP_HEAVY
    }

    public AvailableBlocks activeBlock;

    public int phaseTimer;
    public bool phaseActive;

    public GameState currPhase;
    public Scene startScreen;
    public Scene mainGame;
    public Scene endGame;

    public int activeWoodCost = 0;
    public int activeBrickCost = 0;
    public int activeSteelCost = 0;
    public int activeCoinCost = 0;

    public bool quakeActive;

    public float volume = 1f;

    public bool phaseEnding = false;
    public bool nextPhaseStarting = false;

    public int numBlocks = 0;

    public int currLevel;

    public int startResourceVal;
    public int inventoryWood;
    public int inventoryBrick;
    public int inventorySteel;
    public int playerPts;


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
        phaseTimer = 0;
        currPhase = GameState.buildPhase;
        currLevel = 0;
        activeBlock = AvailableBlocks.BASE_LIGHT;
        inventoryBrick = inventorySteel = inventoryWood = startResourceVal = 50;
        //SceneManager.SetActiveScene(startScreen);
        //StartCoroutine(phaseTimerCount());
        //timerText.text = "Time Remaining In Phase: " + phaseTimer;
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Debug.Log("GAME MANAGER " + currPhase);
        //Debug.Log("GAME MANAGER " + quakeActive);
        //switch for game state
        if (!phaseActive)
        {
            phaseActive = true;
        }
        

        if (currPhase == GameState.buildPhase){
            
            StopCoroutine(phaseTimerCount());
            phaseTimer = 0;
            quakeActive = false;
        }
        if(currPhase == GameState.actionPhase)
        {
            quakeActive = true;
        }
        if(currPhase == GameState.actionPhase && phaseTimer == 0)
        {
            
            StartCoroutine(phaseTimerCount());
        }
        if(currPhase == GameState.actionPhase && phaseTimer == 60)
        {
            StopCoroutine(phaseTimerCount());
            EventSystem.Instance.changePhase((LevelPhase)currPhase);
            phaseTimer = 0;
        }

        //timerText.text = "Time Remaining In Phase: " + (60 - phaseTimer);
        /*if(currPhase == GameState.actionPhase && phaseTimer == 60)
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
        }*/
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

    public void startTimer()
    {
        StartCoroutine(phaseTimerCount());
    }

    public void resetGame()
    {
        //set points to 0
    }

    public bool getQuake()
    {
        return quakeActive;
    }

    public void setLevel(int lvl)
    {
        currLevel = lvl;
    }

    public int getLevel()
    {
        return currLevel;
    }

    public string getCurrentBlock()
    {
        return activeBlock.ToString();
    }

    public void setCurrentBlock(string newActiveBlock)
    {
        switch (newActiveBlock)
        {
            case "BASE_LIGHT":
                activeBlock = AvailableBlocks.BASE_LIGHT;
                break;
            case "BASE_NORMAL":
                activeBlock = AvailableBlocks.BASE_NORMAL;
                break;
            case "BASE_HEAVY":
                activeBlock = AvailableBlocks.BASE_HEAVY;
                break;
            case "MID_LIGHT":
                activeBlock = AvailableBlocks.MID_LIGHT;
                break;
            case "MID_NORMAL":
                activeBlock = AvailableBlocks.MID_NORMAL;
                break;
            case "MID_HEAVY":
                activeBlock = AvailableBlocks.MID_HEAVY;
                break;
            case "TOP_LIGHT":
                activeBlock = AvailableBlocks.TOP_LIGHT;
                break;
            case "TOP_NORMAL":
                activeBlock = AvailableBlocks.TOP_NORMAL;
                break;
            case "TOP_HEAVY":
                activeBlock = AvailableBlocks.TOP_HEAVY;
                break;
            default:
                Debug.Log("CHANGE FAILED BLOCK REMAINS: " + activeBlock.ToString());
                break;
        }
    }


}
