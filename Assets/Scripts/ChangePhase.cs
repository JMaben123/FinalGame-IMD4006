using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePhase : MonoBehaviour
{
    public void toActionPhase()
    {
        GlobalDataManager.globalDataManager.setGameState(GlobalDataManager.GameState.actionPhase);
        GlobalDataManager.globalDataManager.startTimer();
    }
}
