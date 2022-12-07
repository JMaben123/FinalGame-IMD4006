using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is the material and currency/point manager script.

//This script controls how many materials the player currently owns, how many points the player has received from a successful defense,
//and manages the shopping system.

public class PointManager : MonoBehaviour
{

    //Define variables for all different building block types
    int woodReq = 0; //Default material variables
    int steelReq = 0;
    int brickReq = 0;
    int pointsReq = 0;

    //Define variables for the player's inventory (these values are how much the player has currently in their reserves)
    int wood = 50;
    int steel = 50;
    int brick = 50;
    //Define points data and value
    int points = 60;
    GlobalDataManager globalData;

    //Define the ID that checks what the player's UI cursor is on
    int uiID = 0; //default - block ID = 0

    //BM points values
    int numLevels = 0;
    int ptsPerLevel = 10; //BM: pts per level built

    int lvlsSurvived = 0;
    int ptsPerLvlSurvive = 20; //BM: pts per level that survives action phase

    int flagHeight = 0;
    int ptsPerHeight = 10; //BM: pts for the height of the 

    //Define switches
    bool isBlockPlaced = false;
    bool hasPointsSent = false; //Have the points been sent?
    bool canMoveObjects = true; //True by default cause the player should be on build phase. Sets to false once action phase begins.


    //Points checker - Checks for the current object in the UI, and loads the required price for each block. Manages purchasing
    void pointChecker()
    {
        switch (uiID)
        {
            case 0: //Block in the first slot of the UI roulette requirements
                woodReq = 10;
                steelReq = 5;
                brickReq = 5;
                pointsReq = 50;
                break;
            case 1: //Block in the second slot
                woodReq = 15;
                steelReq = 5;
                brickReq = 10;
                pointsReq = 50;
                break;
            case 2: //Third slot, etc.
                woodReq = 20;
                steelReq = 10;
                brickReq = 15;
                pointsReq = 100;
                break;
            case 3:
                woodReq = 20;
                steelReq = 10;
                brickReq = 10;
                pointsReq = 150;
                break;
            default: //Slot 1 = default (not sure if I need this)
                woodReq = 10;
                steelReq = 5;
                brickReq = 5;
                pointsReq = 50;
                break;
        }

        //Check if the player has the necessary materials
        //TODO - find where the resources are being stored, and load them into this script

        //Does the player have enough wood, iron, stone and points?
        if ((wood == woodReq) && (iron == ironReq) && (stone == stoneReq) && (points == pointsReq))
        {
            //Subtract them from the reserve
            GlobalDataManager.globalDataManager.inventoryWood = wood - woodReq;
            GlobalDataManager.globalDataManager.inventorySteel = steel - steelReq;
            GlobalDataManager.globalDataManager.inventoryBrick = brick - brickReq;
            GlobalDataManager.globalDataManager.playerPts = points - pointsReq;
            //Save variables to the internal integers in PointManager.cs, so the values in here always match the one
            //in the global data manager
            wood = GlobalDataManager.globalDataManager.inventoryWood;
            steel = GlobalDataManager.globalDataManager.inventorySteel;
            brick = GlobalDataManager.globalDataManager.inventoryBrick;
            points = GlobalDataManager.globalDataManager.playerPts;
            //Place the block
            //TODO - grab function that places the block and put it here
        }
        else
        {
            //do nothing, maybe an error message? "You do not have the necessary materials."
        }


    }

    //This function controls the checker, which tells the game how well the player has done in their defense.
    //This is done by checking the Y value of the "flag" object, which is how high the flag is from touching the ground once the earthquake ends.
    void winPoints()
    {
        //Get the y coordinate of the flag
        //points = points + (10 * position.y) //(commented out because the flag object is not set up yet)
    }

    //This function will check if the block is currently being placed
    void blockPlacer()
    {
        //If there is a block being placed, manage that here. The block state on the field itself will be determined in the Game Manager

        //If the block is being moved around on the screen, make it so that no other materials can be interacted with in the menu
    }

    // Start is called before the first frame update
    void Start()
    {
        //Initiate values
        wood = 50; //Start with 50 of each material
        steel = 50;
        brick = 50;
        points = 60; //BM: start with 60 points to spend on 
        
        GlobalDataManager.globalDataManager.playerPts = points;
        GlobalDataManager.globalDataManager.inventoryWood = wood;
        GlobalDataManager.globalDataManager.inventorySteel = steel;
        GlobalDataManager.globalDataManager.inventoryBrick = brick;
        
        globalData = GlobalDataManager.globalDataManager;
        numLevels = globalData.numBlocks;
    }

    // Update is called once per frame
    void Update()
    {
        if(numLevels < globalData.numBlocks) { 
            numLevels++; 
            if (GlobalDataManager.globalDataManager.getGameState() == GlobalDataManager.GameState.buildPhase)
            {
                //BM: do a calculation for each level placed
                if(GlobalDataManager.globalDataManager.playerPts == 0)
                {
                    points = ptsPerLevel * numLevels;
                    /*wood = ptsPerLevel * numLevels;
                    steel = ptsPerLevel * numLevels;
                    brick = ptsPerLevel * numLevels;*/
                    /*Debug.Log("pts per lvl: " + ptsPerLevel);
                    Debug.Log("num lvls" + numLevels);*/
                }
                else
                {
                    points += ptsPerLevel;

                    //Debug.Log("Points: " + points);
                }
            }
            if((GlobalDataManager.globalDataManager.getGameState() == GlobalDataManager.GameState.actionPhase) && (GlobalDataManager.globalDataManager.phaseEnding))
            {
                if (GlobalDataManager.globalDataManager.playerPts == 0)
                {
                    points = ptsPerLvlSurvive * lvlsSurvived;
                }
                else
                {
                    points += ptsPerLvlSurvive * lvlsSurvived;
                    points += flagHeight * ptsPerHeight;
                }
            }
        }

        //**Pseudocode**
        //Add once game manager adds the Earthquake timer
        //When the earthquake timer is over and build phase begins, the points will be distributed here

        //if (hasPointsSent == false && earthquakeTimer < 0 && flagPosition.y > 0)
        //{{
        //winPoints();
        //Set the flag to true so that the game isn't constantly adding points to the player
        hasPointsSent = true;
        //}}

        GlobalDataManager.globalDataManager.playerPts = points;
        EventSystem.Instance.changePoints(points);
        //Debug.Log(points);
    }


    
}
