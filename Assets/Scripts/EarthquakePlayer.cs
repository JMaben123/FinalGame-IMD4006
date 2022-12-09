using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthquakePlayer : MonoBehaviour
{
    //Define audio player and audio files
    public AudioSource _NoLoop; //audio player without loop
    public AudioClip equake1; //earthquake
    public AudioClip equake2;
    public AudioClip equake3;
    //Define random int
    int randomEQfx = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //When the button is pressed, initiate a random earthquake sound effect
        randomEQfx = Random.Range(0, 2);
        switch (randomEQfx)
        {
            case 0:
                _NoLoop.clip = equake1;

                _NoLoop.Play();
                break;
            case 1:
                _NoLoop.clip = equake2;

                _NoLoop.Play();
                break;
            case 2:
                _NoLoop.clip = equake3;

                _NoLoop.Play();
                break;
            default:
                _NoLoop.clip = equake1;

                _NoLoop.Play();
                break;
        }
    }
}
