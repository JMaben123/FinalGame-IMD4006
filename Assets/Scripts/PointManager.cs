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
    int blockA = 0;
    int blockB = 0;
    int blockC = 0;
    int blockD = 0;
    //Define switches
    bool isBlockPlaced = false;
    bool hasPointsSent = false; //Have the points been sent?
    bool canMoveObjects = true; //True by default cause the player should be on build phase. Sets to false once action phase begins.

    //Define points value
    public int points = 0;

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
        //BM: Points link to event system
        EventSystem.Instance.OnPointsChange += OnPointsChange;
    }

    // Update is called once per frame
    void Update()
    {
        //**Pseudocode**
        //Add once game manager adds the Earthquake timer
        //When the earthquake timer is over and build phase begins, the points will be distributed here

        //if (hasPointsSent == false && earthquakeTimer < 0 && flagPosition.y > 0)
        //{{
            //winPoints();
            //Set the flag to true so that the game isn't constantly adding points to the player
            hasPointsSent = true;
        //}}

        
    }

    private void OnPointsChange(int pts)
    {

    }

    private void OnDestroy()
    {
        EventSystem.Instance.OnPointsChange -= OnPointsChange;
    }
}
