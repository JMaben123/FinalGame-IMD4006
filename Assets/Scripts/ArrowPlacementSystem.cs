using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowPlacementSystem : MonoBehaviour
{
    public static ArrowPlacementSystem arrowPlacementSystem;
    public float x = 500f;                                         //Variable for the arrow force
    public int spawnHeight = 10;                                    //Variable for spawn height
    public bool placed;

    public GameObject obj1;
    public GameObject obj2;
    public GameObject obj3;
    public GameObject obj4;
    public GameObject placer;
    bool hasJoint;
    bool collisionPlatform = false;
    float y = 10f + 10;

    int numOfBlocks = 0;
    public int var = 2;

    private void Awake()
    {
        if (arrowPlacementSystem == null)
        {
            DontDestroyOnLoad(gameObject);
            arrowPlacementSystem = this;
        }
        else if (arrowPlacementSystem != this)
        {
            Destroy(gameObject);
        }

    }
    // Update is called once per frame
    void Update()
    {
        placeBlock();

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
        if (Input.GetKeyDown(KeyCode.I))
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
            placed = true;


            GlobalDataManager.globalDataManager.numBlocks += 1;
        }
       /* if (Input.GetKeyUp(KeyCode.T))
        {
            placed = false;
        }*/

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
        }


    }



}

