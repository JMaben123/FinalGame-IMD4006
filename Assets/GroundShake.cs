using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundShake : MonoBehaviour
{
    public int magnitude;

    public Rigidbody rb;
    public bool shaking;
    public float time;
    public float bounding;

    // Start is called before the first frame update
    void Start()
    {
        time = 10;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(shaking == true)
        {
            shake(magnitude);
            rb.isKinematic = false;
        }
        else
        {
            rb.isKinematic = true;
            rb.transform.position = Vector3.Lerp(rb.transform.position, new Vector3(0, 0.25f, 0), time*Time.deltaTime);
        }
        //rb.AddForce(transform.right * 2);
    }


    void shake(int magnitude)
    {
        float amount = Random.Range(-10f, 10f);
        amount = amount * magnitude;
        //rb.AddForce(0,amount,0);
        rb.AddForce(amount, amount, amount);
        //rb.transform.position = new Vector3(amount, 0.0f, amount) *Time.deltaTime;
        //rb.transform.Rotate(amount, amount, 0); 
        if(rb.transform.position.x < -bounding || rb.transform.position.x > bounding || rb.transform.position.z < -bounding || rb.transform.position.z > bounding)
        {
            rb.transform.position = Vector3.Lerp(rb.transform.position, new Vector3(0,0.25f,0), time * Time.deltaTime);
        }
            

        //intensity value controlled by sin curve
    }
}
