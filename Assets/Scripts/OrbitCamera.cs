using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;





public class OrbitCamera : MonoBehaviour
{
    public float rotateSpeed;
    float zoomAmount;
    float zVal;
    public CinemachineVirtualCamera vcam;
    CinemachineTransposer transposer;
    bool arrow;
    public Transform lookAtObject;
    public static OrbitCamera orbitCamera;

    // Start is called before the first frame update
    void Start()
    {
        //zoomAmount = 0.25f;
        transposer = vcam.GetCinemachineComponent<CinemachineTransposer>();
        //transposer = vcam.GetComponent<CinemachineTransposer>();
        transposer.m_FollowOffset = new Vector3(0f, 7f, -13f);

        //print("block count: " + zoomAmount);
        if (orbitCamera == null)
        {
            //DontDestroyOnLoad(gameObject);
            orbitCamera = this;
        }
        else if (orbitCamera != this)
        {
            Destroy(gameObject);
        }
    }


    public IEnumerator Shake()
    {
        Vector3 originalPos = transposer.m_FollowOffset;

        float yVal = Random.Range(-0.25f, 0.25f);
        print("working");
        transposer.m_FollowOffset = new Vector3(originalPos.x, transposer.m_FollowOffset.y + yVal, originalPos.z);
        if(transposer.m_FollowOffset.y >9.0f || transposer.m_FollowOffset.y < 5.0f)
        {
            transposer.m_FollowOffset.y = 7.0f;
        }
        yield return null;
    }

   


    void moveCamera()
    {
        zVal = transposer.m_FollowOffset.z;
        transposer.m_FollowOffset = new Vector3(0f, transposer.m_FollowOffset.y, zVal - zoomAmount);
                //zVal = vcam.m_Follow.position.z;
        //zVal = gameObject.GetComponent<Transform>().position.z;
        //gameObject.GetComponent<Transform>().position = new Vector3(0,0, zVal + upAmount);
        //transposer.m_FollowOffset = new Vector3(0, 0, zVal + upAmount);
        //m_FollowOffset = new Vector3(0, 0, zVal + upAmount);

        //print("added block");
        //print(zVal);
        arrow = false;
        ArrowPlacementSystem.arrowPlacementSystem.placed = false;


    }

    // Update is called once per frame
    void Update()
    {
        arrow = ArrowPlacementSystem.arrowPlacementSystem.placed;

        zoomAmount = GlobalDataManager.globalDataManager.numBlocks;
        //print("arrow: " + arrow);

        float rotateDir = 0f;
        if (Input.GetKey(KeyCode.LeftBracket))
        {
            rotateDir = 0.5f;
        }
        if (Input.GetKey(KeyCode.RightBracket))
        {
            rotateDir = -0.5f;
        }

        if (arrow == true)
        {
            if (ArrowPlacementSystem.arrowPlacementSystem.zoomOut == true)
            {
                moveCamera();
            }
            
        }

        lookAtObject.transform.eulerAngles += new Vector3(0, rotateDir * rotateSpeed * Time.deltaTime, 0);
    }

}
