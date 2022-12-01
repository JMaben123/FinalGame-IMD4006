using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public struct PlayerInventory
{
    public int woodCount;
    public int steelCount;
    public int brickCount;
}

public enum ResourceTypes
{
    wood,
    steel,
    brick
}

public enum LevelPhase
{
    build,
    action
}


public class EventSystem : MonoBehaviour
{
    public static EventSystem Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    public event Action<ResourceTypes, int, PlayerInventory> OnResourceGained;
    public void resourceGained(ResourceTypes type, int numAdded, PlayerInventory playerInventory)
    {
        if(OnResourceGained != null)
        {
            OnResourceGained(type, numAdded, playerInventory);
        }
    }

    public event Action<LevelPhase> OnPhaseChange;

    public void changePhase(LevelPhase levelPhase)
    {
        if(OnPhaseChange != null)
        {
            OnPhaseChange(levelPhase);
        }
    }

    public event Action<int> OnPointsChange;

    public void changePoints(int pts)
    {
        if(OnPointsChange != null)
        {
            OnPointsChange(pts);
        }
    }

    public event Action OnBlockPlaced;

    public void blockPlaced()
    {
        if(OnBlockPlaced != null)
        {
            OnBlockPlaced();          
        }
    }


    public event Action OnGamePause;
    
    public void PauseGame()
    {
        if (OnGamePause != null)
        {
            OnGamePause();
        }
    }

    public event Action<int> OnDropBlockChange;

    public void ChangeDropBlock(int newBlock)
    {
        if(OnDropBlockChange != null)
        {
            OnDropBlockChange(newBlock);
        }
    }

}
