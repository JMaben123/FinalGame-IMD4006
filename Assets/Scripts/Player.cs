using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public struct PlayerInventory
    {
        public int woodCount;
        public int steelCount;
        public int brickCount;
    }

    PlayerInventory inventory;

    public KeyCode tiltLeft = KeyCode.Q;
    public KeyCode tiltRight = KeyCode.E;
    public KeyCode OrbitLeft = KeyCode.LeftArrow;
    public KeyCode OrbitRight = KeyCode.RightArrow;
    public KeyCode placeBlock = KeyCode.Space;

    public KeyCode pause = KeyCode.Escape;

    private bool UIUpdated = false;

    int playerPts;
    // Start is called before the first frame update
    void Start()
    {
        playerPts = GlobalDataManager.globalDataManager.playerPts;
        inventory.woodCount = inventory.steelCount = inventory.brickCount = GlobalDataManager.globalDataManager.startResourceVal;
    }

    // Update is called once per frame
    void Update()
    {
        
        //AddPoints(0);
        if (Input.GetKeyDown(pause))
        {
            EventSystem.Instance.PauseGame();
        }
    }

    public void AddPoints(int pts)
    {
        //add pts and display on UI
        playerPts += pts;
        EventSystem.Instance.changePoints(playerPts);
    }
}
