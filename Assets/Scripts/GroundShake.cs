using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundShake : MonoBehaviour
{
    Rigidbody rb;
    bool shaking;
    public float time;
    public float bounding;
    float frequency;
    float amplitude;
    int activeLevel;
    GlobalDataManager globalDataManager;
    public int blockCount;// needs to be implemented with joint system - each connection increases block count



    //NOTE: USE MODIFIER TO ADD UP MASS OF ALL OBJECTS ON THE FLOOR AND ADD AS A MULTIPLIER LIKE THE AMPLITUDE.

    public enum Levels
    {
        L0,
        L1,
        L2,
        L3,
        L4,
        L5,
        L6,
        L7,
        L8,
        L9,
        L10,
        Impossible,
        ActuallyImpossible
    }
    public Levels lvl;

    // Start is called before the first frame update
    void Start()
    {
        //shaking = GlobalDataManager.globalDataManager.getQuake();
        activeLevel = 0;
        shaking = true;
        //blockCount = 1;

        rb = GetComponent<Rigidbody> ();
        rb.constraints = RigidbodyConstraints.FreezePosition;
        /*
         switch(lvl)
        {
            case Levels.L0:
                StartCoroutine(EarthquakeGenerator(0.5f, 5f));
                bounding = 1f;
                break;
            case Levels.L1:
                StartCoroutine(EarthquakeGenerator(0.5f, 5.5f));
                bounding = 1f;
                break;
            case Levels.L2:
                StartCoroutine(EarthquakeGenerator(0.5f, 6f));
                bounding = 1.5f;
                break;
            case Levels.L3:
                StartCoroutine(EarthquakeGenerator(0.5f, 6.5f));
                bounding = 1.5f;
                break;
            case Levels.L4:
                StartCoroutine(EarthquakeGenerator(0.5f, 7f));
                bounding = 2f;
                break;
            case Levels.L5:
                StartCoroutine(EarthquakeGenerator(0.25f, 7.5f));
                bounding = 2f;
                break;
            case Levels.L6:
                StartCoroutine(EarthquakeGenerator(0.25f, 8f));
                bounding = 2.5f;
                break;
            case Levels.L7:
                StartCoroutine(EarthquakeGenerator(0.25f, 8.5f));
                bounding = 2.5f;
                break;
            case Levels.L8:
                StartCoroutine(EarthquakeGenerator(0.25f, 9f));
                bounding = 3f;
                break;
            case Levels.L9:
                StartCoroutine(EarthquakeGenerator(0.25f, 9.5f));
                bounding = 3f;
                break;
            case Levels.L10:
                StartCoroutine(EarthquakeGenerator(0.25f, 10f));
                bounding = 3.5f;
                break;
            case Levels.Impossible:
                StartCoroutine(EarthquakeGenerator(0.1f, 20f));
                //bounding = 5f;
                break;
            case Levels.ActuallyImpossible:
                StartCoroutine(EarthquakeGenerator(0.1f, 200f));
                bounding = 5f;
                break;
            default:
                StartCoroutine(EarthquakeGenerator(0.5f, 5f));
                bounding = 0.5f;
                break;
        }*/
 

        switch (lvl)
        {
            case Levels.L0:
                StartCoroutine(EarthquakeGenerator(0.5f, 1f));
                bounding = 1f;
                break;
            case Levels.L1:
                StartCoroutine(EarthquakeGenerator(0.5f, 1f));
                bounding = 1f;
                break;
            case Levels.L2:
                StartCoroutine(EarthquakeGenerator(0.5f, 2f));
                bounding = 1.5f;
                break;
            case Levels.L3:
                StartCoroutine(EarthquakeGenerator(0.5f, 3f));
                bounding = 1.5f;
                break;
            case Levels.L4:
                StartCoroutine(EarthquakeGenerator(0.5f, 4f));
                bounding = 2f;
                break;
            case Levels.L5:
                StartCoroutine(EarthquakeGenerator(0.25f, 5f));
                bounding = 2f;
                break;
            case Levels.L6:
                StartCoroutine(EarthquakeGenerator(0.25f, 6f));
                bounding = 2.5f;
                break;
            case Levels.L7:
                StartCoroutine(EarthquakeGenerator(0.25f, 7f));
                bounding = 2.5f;
                break;
            case Levels.L8:
                StartCoroutine(EarthquakeGenerator(0.25f, 8f));
                bounding = 3f;
                break;
            case Levels.L9:
                StartCoroutine(EarthquakeGenerator(0.25f, 9f));
                bounding = 3f;
                break;
            case Levels.L10:
                StartCoroutine(EarthquakeGenerator(0.25f, 10f));
                bounding = 3.5f;
                break;
            case Levels.Impossible:
                StartCoroutine(EarthquakeGenerator(0.1f, 20f));
                //bounding = 5f;
                break;
            case Levels.ActuallyImpossible:
                StartCoroutine(EarthquakeGenerator(0.1f, 200f));
                bounding = 5f;
                break;
            default:
                StartCoroutine(EarthquakeGenerator(0.5f, 5f));
                bounding = 0.5f;
                break;
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //shaking = GlobalDataManager.globalDataManager.getQuake();
        //Debug.Log("Quake is " + shaking);

        //activeLevel = GlobalDataManager.globalDataManager.currLevel;

        lvl = (Levels)activeLevel;
        //Debug.Log(lvl);

        if (shaking == true)
        {
            rb.isKinematic = false;
        }
        else
        {
            rb.isKinematic = true;
            StopCoroutine(EarthquakeGenerator(frequency, amplitude));
            rb.transform.position = Vector3.Lerp(rb.transform.position, new Vector3(0, 0.25f, 0), time*Time.deltaTime);
        }
        //rb.AddForce(transform.right * 2);
    }



    IEnumerator EarthquakeGenerator(float frequency, float amplitude)
    {
        while(true)
        {
            float[] amplitudeArray = { 0f,0.5f, 1,0.5f, 0f,-0.5f, -1,-0.5f };
            //float[] amplitudeArray = { 0f, 0.05f, 0.1f, 0.05f, 0f, -0.05f, -0.1f, -0.05f };
            //int sign = Random.Range(-1, 1);


            for (int i = 0; i < amplitudeArray.Length; i++)
            {
                int val = Random.Range(0, amplitudeArray.Length);
                float force = amplitudeArray[val] * amplitude * blockCount;
                //float force = amplitudeArray[i] * amplitude * sign;
                //float force = (Random.Range(0, amplitudeArray.Length)) * amplitude;
                //rb.AddForce(force, 0, force, ForceMode.VelocityChange);
                rb.AddTorque(force, 0, force, ForceMode.VelocityChange);
                //rb.AddTorque(force, 0, force, ForceMode.Acceleration);
                yield return new WaitForSeconds(frequency);
                print("force Applied: " + force);
                if (i == amplitudeArray.Length)
                {
                    i = 0;
                }

                /*if (rb.transform.position.x < -bounding || rb.transform.position.x > bounding || rb.transform.position.z < -bounding || rb.transform.position.z > bounding)
                {
                   
                    rb.transform.position = Vector3.Lerp(rb.transform.position, new Vector3(0, 0.25f, 0), time);
                    print("limit");
                    yield return new WaitForSeconds(1f);
                }*/

            }

        }


    }   
}
