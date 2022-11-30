using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActiveBlockListener : MonoBehaviour
{
    public Image activeBlock;
    public Sprite[] sprites;
    
    // Start is called before the first frame update
    void Start()
    {
        EventSystem.Instance.OnDropBlockChange += OnDropBlockChange;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        EventSystem.Instance.OnDropBlockChange -= OnDropBlockChange;
    }

    public void OnDropBlockChange(int newBlock)
    {
        GlobalDataManager.globalDataManager.activeBlock = (GlobalDataManager.AvailableBlocks)newBlock;
        switch (newBlock)
        {
            case 0:
                activeBlock.sprite = sprites[0];
                break;
            case 1:
                activeBlock.sprite = sprites[1];
                break;
            case 2:
                activeBlock.sprite = sprites[2];
                break;
            case 3:
                activeBlock.sprite = sprites[3];
                break;
            case 4:
                activeBlock.sprite = sprites[4];
                break;
            case 5:
                activeBlock.sprite = sprites[5];
                break;
            case 6:
                activeBlock.sprite = sprites[6];
                break;
            case 7:
                activeBlock.sprite = sprites[7];
                break;
            case 8:
                activeBlock.sprite = sprites[8];
                break;
            case 9:
                activeBlock.sprite = sprites[9];
                break;
            default:
                activeBlock.sprite = sprites[0];
                break;
        }
    }
}
