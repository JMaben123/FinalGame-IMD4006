using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundShake : MonoBehaviour
{
    public int magnitude;

    public Rigidbody rb;
    public bool shaking;
    public float time;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(shaking == true)
        {
            shake(magnitude);
        }
        else
        {
            rb.transform.position = Vector3.Lerp(rb.transform.position, Vector3.zero, time*Time.deltaTime);
        }
        //rb.AddForce(transform.right * 2);
    }


    void shake(int magnitude)
    {
        float amount = Random.Range(-0.5f, 0.5f) * magnitude;
        rb.AddForce(amount, 0, amount);
        //rb.transform.position = new Vector3(amount, 0.0f, amount) *Time.deltaTime;
        Vector3.Lerp(rb.transform.position, Vector3.zero, Time.deltaTime);

        //intensity value controlled by sin curve
    }
}
