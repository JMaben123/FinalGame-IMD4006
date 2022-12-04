  using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;




public class OrbitCamera : MonoBehaviour
{
    public float rotateSpeed;
    int blockAmount = 1; // replace with global block count
    bool blockPlaced = false;
    public float zoomAmount;
    float zVal;
    public CinemachineVirtualCamera vcam;
    CinemachineTransposer transposer;



    // Start is called before the first frame update
    void Start()
    {
        //zoomAmount = 0.25f;
        transposer = vcam.AddCinemachineComponent<CinemachineTransposer>();
        transposer.m_FollowOffset = new Vector3(0f, 7f, -13f);
    }


    void moveCamera()
    {
        zVal = transposer.m_FollowOffset.z;
        //zVal = vcam.m_Follow.position.z;
        //zVal = gameObject.GetComponent<Transform>().position.z;
        //gameObject.GetComponent<Transform>().position = new Vector3(0,0, zVal + upAmount);
        //transposer.m_FollowOffset = new Vector3(0, 0, zVal + upAmount);
        //m_FollowOffset = new Vector3(0, 0, zVal + upAmount);

        transposer.m_FollowOffset = new Vector3(0f, transposer.m_FollowOffset.y, zVal - zoomAmount);

        print("added block");
        print(zVal);


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

        
        if(Input.GetKeyDown(KeyCode.T))
        {
            moveCamera();
        }

        transform.eulerAngles += new Vector3(0, rotateDir * rotateSpeed * Time.deltaTime, 0);
    }
}
