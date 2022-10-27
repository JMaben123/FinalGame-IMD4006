using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiltController : MonoBehaviour
{
    //Define variables for the tilt
    public float rotateValZ = 0f;
    private float tiltTimer = 0f;

    //This function controls the timer (through Update), and only activates when the player inputs
    void buttonTimer()
    {
        tiltTimer += Time.deltaTime;
        Debug.Log("The rotator has been held down for " + tiltTimer + " seconds");

        if (Input.GetKeyDown(KeyCode.A))
        {
            //Rotate z negative
            rotateValZ = (tiltTimer * -1) * 2;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            //Rotate z positive
            rotateValZ = (tiltTimer * 2);
        }

        //If the rotator reaches an extreme at either end
        else if (rotateValZ >= 45)
        {
            rotateValZ = 45;
        }

        else if (rotateValZ <= -45)
        {
            rotateValZ = -45;
        }

        //If either or button is released
        else if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            if (rotateValZ > 0)
            {
                //Rotate z back to 0
                rotateValZ = (tiltTimer * 2);
            }

            if (rotateValZ < 0)
            {
                //Rotate z back to 0
                rotateValZ = (tiltTimer * -2);
            }

            //When the values get close to 0, snap it to point
            else if ((-1 < rotateValZ) && (rotateValZ < 1))
            {
                rotateValZ = 0;
            }
        }
    }

    //This function controls the tilting (through Update), and constantly checks for player input.
    void geoTilter()
    {
        //Get the geometry object's rotation, and update that value with the value from rotateValX or rotateValZ
        transform.Rotate(0, 0, rotateValZ);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Activate functions
        buttonTimer();
        geoTilter();
    }
}
