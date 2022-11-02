using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    GlobalDataManager globalData;
    public TextMeshProUGUI phaseText;
    public TextMeshProUGUI levelText;

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
            phaseText.text = "Phase: Action";
        }
        else
        {
            globalData.setGameState(GlobalDataManager.GameState.buildPhase);
            //globalData.currPhase = GlobalDataManager.GameState.buildPhase;
            globalData.phaseTimer = 0;
            phaseText.text = "Phase: Build";


        }
    }

    private void OnDestroy()
    {
        EventSystem.Instance.OnPhaseChange -= ChangePhase;
    }
}
