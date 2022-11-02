using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementListener : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EventSystem.Instance.OnBlockPlaced += BlockPlaced;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void BlockPlaced()
    {
        GlobalDataManager.globalDataManager.numBlocks += 1;
    }

    private void OnDestroy()
    {
        EventSystem.Instance.OnBlockPlaced -= BlockPlaced;
    }
}
