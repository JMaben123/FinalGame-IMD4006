using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowPlacementSystem : MonoBehaviour
{
    struct Block
    {
        //string objName;
        public GameObject model;
        public int woodCost;
        public int brickCost;
        public int steelCost;
        public int coinCost;

        public Block(GameObject GO, int wc, int bc, int sc, int cc)
        {
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

    //Block[] availableBlocks;

    Block activeBlock;

    public GameObject lightBaseGO;
    public GameObject medBaseGO;
    public GameObject heavyBaseGO;

    public GameObject lightMidGO;
    public GameObject medMidGO;
    public GameObject heavyMidGO;

    public GameObject lightTopGO;
    public GameObject medTopGO;
    public GameObject heavyTopGO;


    public float x = 500f;                                         //Variable for the arrow force
    public int spawnHeight = 10;                                    //Variable for spawn height

    //public GameObject obj1;
    //public GameObject obj2;
    //public GameObject obj3;
    //public GameObject obj4;
    public GameObject placer;
    bool hasJoint;
    bool collisionPlatform = false;
    float y = 10f + 10;

    int numOfBlocks = 0;
    public int var = 2;

    // Start is called before the first frame update
    void Start()
    {
        lightBase = new Block(lightBaseGO, 5, 10, 3, 50);
        medBase = new Block(medBaseGO, 10, 15, 8, 75);
        heavyBase = new Block(heavyBaseGO, 20, 25, 18, 100);

        lightMid = new Block(lightMidGO, 5, 10, 3, 50);
        medMid = new Block(medMidGO, 10, 15, 8, 75);
        heavyMid = new Block(heavyMidGO, 20, 25, 18, 100);

        lightTop = new Block(lightTopGO, 5, 10, 3, 50);
        medTop = new Block(medTopGO, 10, 15, 8, 75);
        heavyTop = new Block(heavyTopGO, 20, 25, 18, 100);

        activeBlock = lightBase;
    }

    // Update is called once per frame
    void Update()
    {
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

            GlobalDataManager.globalDataManager.numBlocks += 1;
        }

        /*if (Input.GetKeyDown(KeyCode.I))
        {
            Instantiate(obj1, new Vector3(placer.transform.position.x, placer.transform.position.y, placer.transform.position.z), Quaternion.identity);
            GlobalDataManager.globalDataManager.numBlocks += 1;
            Debug.Log(GlobalDataManager.globalDataManager.numBlocks);
            //EventSystem.Instance.blockPlaced();
            //Debug.Log("P pressed");
            moveUp();


            GlobalDataManager.globalDataManager.numBlocks += 1;
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            Instantiate(obj2, new Vector3(placer.transform.position.x, placer.transform.position.y, placer.transform.position.z), Quaternion.identity);
            GlobalDataManager.globalDataManager.numBlocks += 1;
            Debug.Log(GlobalDataManager.globalDataManager.numBlocks);
            //EventSystem.Instance.blockPlaced();
            //Debug.Log("P pressed");
            moveUp();


            GlobalDataManager.globalDataManager.numBlocks += 1;
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            Instantiate(obj3, new Vector3(placer.transform.position.x, placer.transform.position.y, placer.transform.position.z), Quaternion.identity);
            GlobalDataManager.globalDataManager.numBlocks += 1;
            Debug.Log(GlobalDataManager.globalDataManager.numBlocks);
            //EventSystem.Instance.blockPlaced();
            //Debug.Log("P pressed");
            moveUp();


            GlobalDataManager.globalDataManager.numBlocks += 1;
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            Instantiate(obj4, new Vector3(placer.transform.position.x, placer.transform.position.y, placer.transform.position.z), Quaternion.identity);
            GlobalDataManager.globalDataManager.numBlocks += 1;
            Debug.Log(GlobalDataManager.globalDataManager.numBlocks);
            //EventSystem.Instance.blockPlaced();
            //Debug.Log("P pressed");
            moveUp();


            GlobalDataManager.globalDataManager.numBlocks += 1;
        }*/


    }

    void setActiveBlock()
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


    bool canBuy(Block buyBlock)
    {
        //inventory compare to cost
        if ((GlobalDataManager.globalDataManager.inventoryWood >= buyBlock.woodCost) && (GlobalDataManager.globalDataManager.inventoryBrick >= buyBlock.brickCost) && (GlobalDataManager.globalDataManager.inventorySteel >= buyBlock.steelCost) && (GlobalDataManager.globalDataManager.playerPts >= buyBlock.coinCost))
        {
            return true;
        }
        else
        {
            return false;
            Debug.Log("NOT ENOUGH RESOURCES");
        }
    }

}

