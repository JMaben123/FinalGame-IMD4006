 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;




public class OrbitCamera : MonoBehaviour
{
    public float rotateSpeed = 300f;
    int blockAmount = 1; // replace with global block count


    // Start is called before the first frame update
    void Start()
    {

        float yVal = gameObject.GetComponent<Transform>().position.y;
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
