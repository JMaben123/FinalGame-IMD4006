using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is the material and currency/point manager script.

//This script controls how many materials the player currently owns, how many points the player has received from a successful defense,
//and 

public class PointManager : MonoBehaviour
{

    //Define variables for all different building block types
    //**Temporary value names, as the actual block types are not finalized**
    /*int blockA = 0;
    int blockB = 0;
    int blockC = 0;
    int blockD = 0;*/

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

    //Define points value
    int points = 60;
    GlobalDataManager globalData;

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
        points = 60; //BM: start with 60 points to spend on 
        
        GlobalDataManager.globalDataManager.playerPts = points;
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