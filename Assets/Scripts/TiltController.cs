using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiltController : MonoBehaviour
{
    //Define variables for the tilt
    public float rotateValX = 0.0f;
    public float rotateValZ = 0.0f;
    private float tiltTimer = 0.0f;
    public float speedController = 1.5f; //This value controls the speed in buttonTimer()
    //Define rigidbody
    Rigidbody rbRotate;

    bool canRotate;

    //This function controls the timer (through Update), and only activates when the player inputs
    void buttonTimer()
    {
        tiltTimer += Time.deltaTime * speedController; //This line takes the speedController variable
        Debug.Log("The rotator has been held down for " + tiltTimer + " seconds"); 
    }

    //Controls the rotations
    void rotatorInput()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            //Activate timer
            buttonTimer();
            //Rotate x positive (tilt upwards)
            rotateValX = tiltTimer * 1.05f;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            //Activate timer
            buttonTimer();
            //Rotate z positive (tilt left)
            rotateValZ = tiltTimer * 1.05f;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            //Activate timer
            buttonTimer();
            //Rotate x negative (tilt downwards)
            rotateValX = -tiltTimer * 1.05f;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            //Activate timer
            buttonTimer();
            //Rotate z negative (tilt right)
            rotateValZ = -tiltTimer * 1.05f;
        }

        //If the rotator reaches an extreme at either end
        //else if (rotateValZ >= 1)
        //{
        //    rotateValZ = 1;
        //    //Stop timer
        //    tiltTimer = 0;
        //}

        //else if (rotateValZ <= -1)
        //{
        //    rotateValZ = -1;
        //    //Stop timer
        //    tiltTimer = 0;
        //}

        //If either or button is released
        //else if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        //{
        //    if (rotateValZ > 0)
        //    {
        //        //Rotate z back to 0
        //        rotateValZ = (tiltTimer * 0.05f);
        //    }

        //    if (rotateValZ < 0)
        //    {
        //        //Rotate z back to 0
        //        rotateValZ = (tiltTimer * -0.05f);
        //    }

        //    //When the values get close to 0, snap it to point
        //    else if ((-1 < rotateValZ) && (rotateValZ < 1))
        //    {
        //        rotateValZ = 0;
        //    }
        //}
    }

    //This function controls the tilting (through Update), and constantly checks for player input.
    void geoTilter()
    {
        //transform.Rotate(0, 0, rotateValZ);
        //gameObject.GetComponent<Rigidbody>(); 

        rbRotate = GetComponent<Rigidbody>(); //Gives the Rigidbody of the object the script it's attached to, and turns it into an object

        //Get the geometry object's rotation, and update that value with the value from rotateValX or rotateValZ
        rbRotate.AddTorque(rotateValX, 0, rotateValZ, ForceMode.VelocityChange);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        canRotate = GlobalDataManager.globalDataManager.quakeActive;

        if (canRotate)
        {
            //Activate functions
            rotatorInput();
            geoTilter();
        }

    }
}
