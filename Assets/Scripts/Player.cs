using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public KeyCode tiltLeft = KeyCode.A;
    public KeyCode tileRight = KeyCode.D;
    public KeyCode placeBlock = KeyCode.M;
    public KeyCode pause = KeyCode.Escape;

    private bool UIUpdated = false;

    int playerPts;
    // Start is called before the first frame update
    void Start()
    {
        playerPts = GlobalDataManager.globalDataManager.playerPts;
    }

    // Update is called once per frame
    void Update()
    {
        if (!UIUpdated)
        {
            AddPoints(0);
            UIUpdated = true;
        }
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
