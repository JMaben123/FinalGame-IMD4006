using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    GlobalDataManager globalData;
    // Start is called before the first frame update
    void Start()
    {
        EventSystem.Instance.OnPhaseChange += ChangePhase;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ChangePhase(LevelPhase phase)
    {
        if(phase == LevelPhase.build)
        {
            globalData.setGameState(GlobalDataManager.GameState.actionPhase);
            //globalData.currPhase = GlobalDataManager.GameState.actionPhase;
            globalData.phaseTimer = 0;
        }
        else
        {
           globalData.currPhase = GlobalDataManager.GameState.buildPhase;
            globalData.phaseTimer = 0;
        }
    }

    private void OnDestroy()
    {
        EventSystem.Instance.OnPhaseChange -= ChangePhase;
    }
}
