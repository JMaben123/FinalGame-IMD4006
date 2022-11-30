 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;




public class OrbitCamera : MonoBehaviour
{
    public float rotateSpeed = 300f;
    int blockAmount = 1; // replace with global block count
    bool blockPlaced = false;
    float upAmount;
    float yVal;


    // Start is called before the first frame update
    void Start()
    {
        upAmount = 1.5f;
        yVal = gameObject.GetComponent<Transform>().position.y;
    }


    void moveCamera()
    {
        if(blockPlaced == true)
        {
            gameObject.GetComponent<Transform>().position = new Vector3(0, yVal + upAmount, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float rotateDir = 0f;
        if(Input.GetKey(KeyCode.LeftBracket))
        {
            rotateDir = 0.5f;
        }
        if (Input.GetKey(KeyCode.RightBracket))
        {
            rotateDir = -0.5f;
        }
       


        transform.eulerAngles += new Vector3(0, rotateDir * rotateSpeed * Time.deltaTime, 0);
    }
}
