using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    public int totalTime = 30;

    public bool phaseEnding = false;
    public bool nextPhaseStarting = false;

    public int numBlocks = 0;

    public int currLevel;

    public int startResourceVal;
    public int inventoryWood;
    public int inventoryBrick;
    public int inventorySteel;
    public int playerPts;

    bool gameOver;
    public GameObject placer;
    //public OrbitCamera orbitCamera;
    public AudioSource source; //audio player without loop
    public AudioClip eQuake; //block drop
    bool audioOn;



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
        //placer.GetComponent<Renderer>().enabled = true;
        source.clip = eQuake;
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
        gameOver = false;
        //placer.SetActive(false);
        audioOn = true;
        




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

        audioPlayer(audioOn);

        if (currPhase == GameState.buildPhase){
            
            StopCoroutine(phaseTimerCount());
            OrbitCamera.orbitCamera.StopCoroutine(OrbitCamera.orbitCamera.Shake());
            phaseTimer = totalTime;
            quakeActive = false;
            audioOn = true;
            

        }
        if(currPhase == GameState.actionPhase)
        {
            quakeActive = true;
            OrbitCamera.orbitCamera.StartCoroutine(OrbitCamera.orbitCamera.Shake());
            //source.Play();
            audioOn = false;
        }
        if(currPhase == GameState.actionPhase && phaseTimer == totalTime)
        {           
            StartCoroutine(phaseTimerCount());
            //OrbitCamera.orbitCamera.StartCoroutine(OrbitCamera.orbitCamera.Shake(totalTime,5));
            
            
        }
        if(currPhase == GameState.actionPhase && phaseTimer == 0)
        {
            StopCoroutine(phaseTimerCount());
            OrbitCamera.orbitCamera.StopCoroutine(OrbitCamera.orbitCamera.Shake());
            EventSystem.Instance.changePhase((LevelPhase)currPhase);
            phaseTimer = totalTime;
            levelReward();
            placer.GetComponent<Rigidbody>().velocity = Vector3.zero;
            audioOn = true;

        }

        if(getScene() == globalDataManager.startScreen)
        {
            audioOn = true;
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


    void audioPlayer(bool playing)
    {
        if(playing == false && source.isPlaying == false)
        {
            source.Play();
        }
        if(playing==true && source.isPlaying == true)
        {
            source.Stop();
            
        }
    }


    IEnumerator phaseTimerCount()
    {
        
        while (phaseActive)
        {
            //Debug.Log("+1 phase timer");
            if(phaseTimer != 0)
            {
                phaseTimer -= 1;
                //print("time: " + phaseTimer);
                yield return new WaitForSeconds(1f);
            }
            if(phaseTimer == 0)
            {
                phaseTimer = totalTime;
                yield break; 
            }
            
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

   public void setScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }

    public Scene getScene()
    {
        return SceneManager.GetActiveScene();
    }

    public void startTimer()
    {
        StopAllCoroutines();
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

    public bool getGameOver()
    {
        return gameOver;
    }

    public void setGameOver(bool isGameOver)
    {
        gameOver = isGameOver;
    }

    public void resetData()
    {
        quakeActive = false;
        phaseActive = true;
        phaseTimer = 0;
        currPhase = GameState.buildPhase;
        currLevel = 0;
        activeBlock = AvailableBlocks.BASE_LIGHT;
        inventoryBrick = inventorySteel = inventoryWood = startResourceVal = 50;
        playerPts = 0;
        gameOver = false;
        audioOn = false;
    }

    public void levelReward()
    {
        inventoryBrick += 25;
        inventorySteel += 20;
        inventoryWood += 20;
        playerPts += 100;
    }
}
