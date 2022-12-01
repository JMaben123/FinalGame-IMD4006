using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EventSystem.Instance.OnResourceGained += OnResourceGained;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnResourceGained(ResourceTypes type, int numAdded, PlayerInventory playerInventory)
    {
        switch (type)
        {
            case ResourceTypes.brick:
                playerInventory.brickCount += numAdded;
                break;
            case ResourceTypes.steel:
                playerInventory.steelCount += numAdded;
                break;
            case ResourceTypes.wood:
                playerInventory.woodCount += numAdded;
                break;
            default:
                break;
        }
    }

    private void OnDestroy()
    {
        EventSystem.Instance.OnResourceGained -= OnResourceGained;
    }
}
