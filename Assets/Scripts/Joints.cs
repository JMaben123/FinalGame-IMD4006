using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joints : MonoBehaviour
{

    public float x = 500f;        //disconnect amount (how hard it can bend)


    //Define audio player and audio files
    //public AudioSource _AudioPlayer; //audio player
    public AudioSource _NoLoop; //audio player without loop
    public AudioClip blockdrop1; //block drop
    public AudioClip blockdrop2; 
    public AudioClip blockdrop3; 
    public AudioClip equake; //earthquake
    int randomSFX;

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
            //Play a random sound once block is dropped
            randomSFX = Random.Range(0, 4);
            switch (randomSFX) {
                case 1:
                    _NoLoop.clip = blockdrop1;

                    _NoLoop.Play();
                    break;
                case 2:
                    _NoLoop.clip = blockdrop2;

                    _NoLoop.Play();
                    break;
                case 3:
                    _NoLoop.clip = blockdrop1;

                    _NoLoop.Play();
                    break;
                default:
                    _NoLoop.clip = blockdrop1;

                    _NoLoop.Play();
                    break;
            }
            

        }

    }

    private void OnJointBreak(float breakForce)
    {
        
        if (gameObject.GetComponent<Joint>().connectedBody == GameObject.Find("Floor").GetComponent<Rigidbody>())
        {
            Debug.Log("YOU FAILED LLLLL OMEGALUL: " + breakForce);
            //GlobalDataManager.globalDataManager.setGameOver(true);
            EventSystem.Instance.GameOver();
            Debug.Log(GlobalDataManager.globalDataManager.getGameOver());
        }
    }
}
