using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placement : MonoBehaviour
{

    public GameObject obj1;
    public GameObject obj2;
    public GameObject obj3;
    public GameObject obj4;
    public GameObject platform;
    bool hasJoint;
    bool collisionPlatform = false;
    float y = 10f + 10;                          //the start height of a spawned objects
    public int hitCounter;
    void OnCollisionEnter(Collision collision)
    {
        //platform = GameObject.Find("platform");

        if (collision.gameObject.GetComponent<Rigidbody>() != null && !hasJoint)
        {
            //gameObject.AddComponent<FixedJoint>().breakForce = 2000;
            gameObject.AddComponent<FixedJoint>();
            gameObject.GetComponent<FixedJoint>().connectedBody = collision.rigidbody;
            hasJoint = true;

        }
        //I have learned patience and mastered my inner rage 
    }

    // Start is called before the first frame update
    void Start()
    {
        hitCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        placeBlock();

    }

    public void placeBlock()
    {
        //BM: move block placement commands here?
        if (Input.GetKeyDown(KeyCode.T))
        {
            //
            Instantiate(obj1, new Vector3(platform.transform.position.x, platform.transform.position.y + y, platform.transform.position.z), Quaternion.identity);
            GlobalDataManager.globalDataManager.numBlocks += 1;
            Debug.Log(GlobalDataManager.globalDataManager.numBlocks);
            //EventSystem.Instance.blockPlaced();
            //Debug.Log("T pressed");
            hitCounter += 1;
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            Instantiate(obj2, new Vector3(platform.transform.position.x, platform.transform.position.y + y, platform.transform.position.z), Quaternion.identity);
            //Debug.Log("Y pressed");
            GlobalDataManager.globalDataManager.numBlocks += 1;
            hitCounter += 1;
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            Instantiate(obj3, new Vector3(platform.transform.position.x, platform.transform.position.y + y, platform.transform.position.z), Quaternion.identity);
            //Debug.Log("U pressed");
            GlobalDataManager.globalDataManager.numBlocks += 1;
            hitCounter += 1;
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            Instantiate(obj4, new Vector3(platform.transform.position.x, platform.transform.position.y + y, platform.transform.position.z), Quaternion.identity);
            //Debug.Log("I pressed");
            GlobalDataManager.globalDataManager.numBlocks += 1;
            hitCounter += 1;
        }

        
    }

}
