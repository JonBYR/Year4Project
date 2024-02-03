using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //taken from this githib repo https://github.com/JJMaslen/WalkWithRhythm
    public AudioSource music;
    public static GameManager instance;
    public float songBpm; //bpm of song (this will be changed to be equal to values from a json file)
    public int songKey;
    public int margin;
    public int timer;
    public bool onBeat = false; //used to determine if a player can move as it is within the bpm
    public double bpmConversion(double bpm)
    {
        double fixedUpdateBpm = 60 / bpm; //fixed Update is 50 frames rather than 60 frames per second, so bpm must be converted to match the timing for fixedUpdate
        return fixedUpdateBpm;
    }
    private void Awake()
    {
        music.Play();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    void FixedUpdate()
    {
        timer++;
        int beat = (int)(bpmConversion(songBpm) * 50); //converts beat to bpm

        int count = timer % beat; //check current time between beats

        if (count >= beat - margin) //if between beats (or slightly before)
        {
            if (onBeat == false)
            {
                onBeat = true;
            }
            onBeat = true;
        }
        else if (count <= margin) //accounts for lateness
        {
            onBeat = true;
        }
        else
        {
            onBeat = false;
        }
    }
}
