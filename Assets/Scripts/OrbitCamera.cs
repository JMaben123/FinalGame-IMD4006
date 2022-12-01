 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class OrbitCamera : MonoBehaviour
{
    public float rotateSpeed = 300f;
    GlobalDataManager gd;
    int blockAmount;
    bool blockPlaced = false;
    float upAmount;
    float yVal;


    // Start is called before the first frame update
    void Start()
    {
        gd = GlobalDataManager.globalDataManager;
        upAmount = 1.5f;
        yVal = gameObject.GetComponent<Transform>().position.y;
        blockAmount = gd.numBlocks;
        
    }


    void moveCamera()
    {
        if(blockAmount > 5)
        {
            gameObject.GetComponent<Transform>().position = new Vector3(0, yVal + (blockAmount*upAmount), 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float rotateDir = 0f;
        if(Input.GetKey(KeyCode.LeftBracket))
        {
            rotateDir = 0.5f;
            transform.Translate(Vector3.left * Time.deltaTime*rotateSpeed);
        }
        if (Input.GetKey(KeyCode.RightBracket))
        {
            rotateDir = -0.5f;
            transform.Translate(Vector3.right* rotateSpeed * Time.deltaTime);
        }

        moveCamera();

        gameObject.transform.LookAt(GameObject.Find("CameraPivot").transform);

        //transform.position += new Vector3(rotateDir * rotateSpeed * Time.deltaTime, 0);
        
    }
}
