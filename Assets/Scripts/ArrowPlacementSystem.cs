using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowPlacementSystem : MonoBehaviour
{
    struct Block
    {
        public string objName;
        public GameObject model;
        public int woodCost;
        public int brickCost;
        public int steelCost;
        public int coinCost;

        public Block(string name, GameObject GO, int wc, int bc, int sc, int cc)
        {
            objName = name;
            model = GO;
            woodCost = wc;
            brickCost = bc;
            steelCost = sc;
            coinCost = cc;
        }
    }

    Block lightBase;
    Block medBase;
    Block heavyBase;

    Block lightMid;
    Block medMid;
    Block heavyMid;

    Block lightTop;
    Block medTop;
    Block heavyTop;

    Block activeBlock;

    Block[] availBlocks;

    int currentBlockIndex;

    public GameObject lightBaseGO;
    public GameObject medBaseGO;
    public GameObject heavyBaseGO;

    public GameObject lightMidGO;
    public GameObject medMidGO;
    public GameObject heavyMidGO;

    public GameObject lightTopGO;
    public GameObject medTopGO;
    public GameObject heavyTopGO;

    //public GameObject costCard;

    public float x = 500f;                                         //Variable for the arrow force
    public int spawnHeight = 10;                                    //Variable for spawn height

    public GameObject placer;
    bool hasJoint;
    bool collisionPlatform = false;
    float y = 10f + 10;

    int numOfBlocks = 0;
    public int var = 2;

    // Start is called before the first frame update
    void Start()
    {
        lightBase = new Block("BASE_LIGHT", lightBaseGO, 5, 10, 3, 50);
        medBase = new Block("BASE_NORMAL", medBaseGO, 10, 15, 8, 75);
        heavyBase = new Block("BASE_HEAVY", heavyBaseGO, 20, 25, 18, 100);

        lightMid = new Block("MID_LIGHT", lightMidGO, 5, 10, 3, 50);
        medMid = new Block("MID_NORMAL", medMidGO, 10, 15, 8, 75);
        heavyMid = new Block("MID_HEAVY", heavyMidGO, 20, 25, 18, 100);

        lightTop = new Block("TOP_LIGHT", lightTopGO, 5, 10, 3, 50);
        medTop = new Block("TOP_NORMAL", medTopGO, 10, 15, 8, 75);
        heavyTop = new Block("TOP_HEAVY", heavyTopGO, 20, 25, 18, 100);

        availBlocks = new Block[] {lightBase, medBase, heavyBase, lightMid, medMid, heavyMid, lightTop, medTop, heavyTop};

        currentBlockIndex = 0;
        activeBlock = availBlocks[currentBlockIndex];
    }

    // Update is called once per frame
    void Update()
    {
        changeActiveBlock();

        setActiveCost();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            placeBlock();
        }

        if (Input.GetKeyDown(KeyCode.W))                                //Arrow Movement System
        {
            gameObject.GetComponent<Rigidbody>().AddForce(0, 0, x);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            gameObject.GetComponent<Rigidbody>().AddForce(0, 0, -x);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            gameObject.GetComponent<Rigidbody>().AddForce(0, 0, -x);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            gameObject.GetComponent<Rigidbody>().AddForce(0, 0, x);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            gameObject.GetComponent<Rigidbody>().AddForce(-x, 0, 0);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            gameObject.GetComponent<Rigidbody>().AddForce(x, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            gameObject.GetComponent<Rigidbody>().AddForce(x, 0, 0);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            gameObject.GetComponent<Rigidbody>().AddForce(-x, 0, 0);
        }

    }

    public void moveUp()
    {

        gameObject.GetComponent<Transform>().position = new Vector3(transform.position.x, transform.position.y + var, transform.position.z);

    }

    public void placeBlock()                                            //Arrow Placement System
    {
        if (canBuy(activeBlock))
        {
            Instantiate(activeBlock.model, new Vector3(placer.transform.position.x, placer.transform.position.y, placer.transform.position.z), Quaternion.identity);
            GlobalDataManager.globalDataManager.numBlocks += 1;
            Debug.Log(GlobalDataManager.globalDataManager.numBlocks);
            Debug.Log(GlobalDataManager.globalDataManager.inventoryWood);
            //EventSystem.Instance.blockPlaced();
            //Debug.Log("T pressed");
            moveUp();

            applyCost(activeBlock.objName);
        }
    }

    void setActiveCost()
    {
        GlobalDataManager.globalDataManager.activeWoodCost = activeBlock.woodCost;
        GlobalDataManager.globalDataManager.activeBrickCost = activeBlock.brickCost;
        GlobalDataManager.globalDataManager.activeSteelCost = activeBlock.steelCost;
        GlobalDataManager.globalDataManager.activeCoinCost = activeBlock.coinCost;
    }

    void changeActiveBlock()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if(currentBlockIndex+1 == availBlocks.Length)
            {
                currentBlockIndex = 0;
            }
            else
            {
                currentBlockIndex++;
            }            
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (currentBlockIndex == 0)
            {
                currentBlockIndex = availBlocks.Length - 1;
            }
            else
            {
                currentBlockIndex--;
            }            
        }
        activeBlock = availBlocks[currentBlockIndex];
        GlobalDataManager.globalDataManager.setCurrentBlock(activeBlock.objName);
        //Debug.Log(activeBlock.objName);
    }

    public void setActiveBlock()
    {
        string currBlock = GlobalDataManager.globalDataManager.getCurrentBlock();

        switch (currBlock)
        {
            case "BASE_LIGHT":
                activeBlock = lightBase;
                break;
            case "BASE_NORMAL":
                activeBlock = medBase;
                break;
            case "BASE_HEAVY":
                activeBlock = heavyBase;
                break;
            case "MID_LIGHT":
                activeBlock = lightMid;
                break;
            case "MID_NORMAL":
                activeBlock = medMid;
                break;
            case "MID_HEAVY":
                activeBlock = heavyMid;
                break;
            case "TOP_LIGHT":
                activeBlock = lightTop;
                break;
            case "TOP_NORMAL":
                activeBlock = medTop;
                break;
            case "TOP_HEAVY":
                activeBlock = heavyTop;
                break;
            default:
                Debug.Log("BAD CHANGE: " + activeBlock.ToString());
                break;
        }
    }

    public int[] getBlockCosts()
    {
        int[] blockCosts = { activeBlock.woodCost, activeBlock.brickCost, activeBlock.steelCost, activeBlock.coinCost };
        return blockCosts;
    }

    void applyCost(string blockType)
    {
        //shouldn't need to account for negative values as this will only be called when the player has >= the number of required resources
        switch (blockType)
        {
            case "BASE_LIGHT":
                GlobalDataManager.globalDataManager.inventoryWood -= lightBase.woodCost;
                GlobalDataManager.globalDataManager.inventoryBrick -= lightBase.brickCost;
                GlobalDataManager.globalDataManager.inventorySteel -= lightBase.steelCost;
                GlobalDataManager.globalDataManager.playerPts -= lightBase.coinCost;
                break;
            case "BASE_NORMAL":
                GlobalDataManager.globalDataManager.inventoryWood -= medBase.woodCost;
                GlobalDataManager.globalDataManager.inventoryBrick -= medBase.brickCost;
                GlobalDataManager.globalDataManager.inventorySteel -= medBase.steelCost;
                GlobalDataManager.globalDataManager.playerPts -= medBase.coinCost;
                break;
            case "BASE_HEAVY":
                GlobalDataManager.globalDataManager.inventoryWood -= heavyBase.woodCost;
                GlobalDataManager.globalDataManager.inventoryBrick -= heavyBase.brickCost;
                GlobalDataManager.globalDataManager.inventorySteel -= heavyBase.steelCost;
                GlobalDataManager.globalDataManager.playerPts -= heavyBase.coinCost;
                break;
            case "MID_LIGHT":
                GlobalDataManager.globalDataManager.inventoryWood -= lightMid.woodCost;
                GlobalDataManager.globalDataManager.inventoryBrick -= lightMid.brickCost;
                GlobalDataManager.globalDataManager.inventorySteel -= lightMid.steelCost;
                GlobalDataManager.globalDataManager.playerPts -= lightMid.coinCost;
                break;
            case "MID_NORMAL":
                GlobalDataManager.globalDataManager.inventoryWood -= medMid.woodCost;
                GlobalDataManager.globalDataManager.inventoryBrick -= medMid.brickCost;
                GlobalDataManager.globalDataManager.inventorySteel -= medMid.steelCost;
                GlobalDataManager.globalDataManager.playerPts -= medMid.coinCost;
                break;
            case "MID_HEAVY":
                GlobalDataManager.globalDataManager.inventoryWood -= heavyMid.woodCost;
                GlobalDataManager.globalDataManager.inventoryBrick -= heavyMid.brickCost;
                GlobalDataManager.globalDataManager.inventorySteel -= heavyMid.steelCost;
                GlobalDataManager.globalDataManager.playerPts -= heavyMid.coinCost;
                break;
            case "TOP_LIGHT":
                GlobalDataManager.globalDataManager.inventoryWood -= lightTop.woodCost;
                GlobalDataManager.globalDataManager.inventoryBrick -= lightTop.brickCost;
                GlobalDataManager.globalDataManager.inventorySteel -= lightTop.steelCost;
                GlobalDataManager.globalDataManager.playerPts -= lightTop.coinCost;
                break;
            case "TOP_NORMAL":
                GlobalDataManager.globalDataManager.inventoryWood -= medTop.woodCost;
                GlobalDataManager.globalDataManager.inventoryBrick -= medTop.brickCost;
                GlobalDataManager.globalDataManager.inventorySteel -= medTop.steelCost;
                GlobalDataManager.globalDataManager.playerPts -= medTop.coinCost;
                break;
            case "TOP_HEAVY":
                GlobalDataManager.globalDataManager.inventoryWood -= heavyTop.woodCost;
                GlobalDataManager.globalDataManager.inventoryBrick -= heavyTop.brickCost;
                GlobalDataManager.globalDataManager.inventorySteel -= heavyTop.steelCost;
                GlobalDataManager.globalDataManager.playerPts -= heavyTop.coinCost;
                break;
            default:
                Debug.Log("BAD CHANGE: " + activeBlock.ToString());
                break;
        }
    }

    bool canBuy(Block buyBlock)
    {
        //inventory compare to cost
        if ((GlobalDataManager.globalDataManager.inventoryWood >= buyBlock.woodCost) && (GlobalDataManager.globalDataManager.inventoryBrick >= buyBlock.brickCost) && (GlobalDataManager.globalDataManager.inventorySteel >= buyBlock.steelCost) && (GlobalDataManager.globalDataManager.playerPts >= buyBlock.coinCost))
        {
            //costCard.GetComponent<Image>().color = new Color(255,255,255);
            return true;
        }
        else
        {
            //costCard.GetComponent<Image>().color = new Color(204, 107, 107);
            return false;
            //Debug.Log("NOT ENOUGH RESOURCES");
        }
    }

}

