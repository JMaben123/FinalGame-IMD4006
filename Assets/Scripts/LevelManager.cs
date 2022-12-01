using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    GlobalDataManager globalData;

    // Start is called before the first frame update
    void Start()
    {
        EventSystem.Instance.OnPhaseChange += ChangePhase;
        globalData = GlobalDataManager.globalDataManager;
    }

    // Update is called once per frame
    void Update()
    {
        //levelText.text = "Level: " + (GlobalDataManager.globalDataManager.currLevel + 1);
        //phaseText.text = "Phase: Start";
    }

    public void ChangePhase(LevelPhase phase)
    {
        if (phase == LevelPhase.build)
        {
            globalData.setGameState(GlobalDataManager.GameState.actionPhase);
            //globalData.currPhase = GlobalDataManager.GameState.actionPhase;
            globalData.phaseTimer = 0;
            //phaseText.text = "Phase: Action";
            GlobalDataManager.globalDataManager.quakeActive = true;
        }
        else
        {
            globalData.setGameState(GlobalDataManager.GameState.buildPhase);
            //globalData.currPhase = GlobalDataManager.GameState.buildPhase;
            //globalData.phaseTimer = 0;
            //phaseText.text = "Phase: Build";
            globalData.currLevel++;
            GlobalDataManager.globalDataManager.quakeActive = false;

        }
    }

    private void OnDestroy()
    {
        EventSystem.Instance.OnPhaseChange -= ChangePhase;
    }
}
