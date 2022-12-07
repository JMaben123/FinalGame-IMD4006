using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joints : MonoBehaviour
{
    float x = 1600f;        //disconnect amount (how hard it can bend)

    bool hasJoint;
    

    private void Start()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        //platform = GameObject.Find("platform");

        if (collision.gameObject.GetComponent<Rigidbody>() != null && !hasJoint)
        {
            //gameObject.AddComponent<FixedJoint>().breakForce = 2000;    //How much force is needed to break the joint 
            //gameObject.AddComponent<FixedJoint>().breakTorque = 2000;   //How much stress is needed to break the joint
            gameObject.AddComponent<FixedJoint>().breakTorque = x;
            gameObject.GetComponent<FixedJoint>().connectedBody = collision.rigidbody;
            hasJoint = true;
            
            

        }

    }
}
