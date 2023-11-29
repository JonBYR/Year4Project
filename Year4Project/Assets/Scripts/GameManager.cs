using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public AudioSource music;
    public BeatManager beat;
    public static GameManager instance;
    public float errorMargin; //this should be in seconds
    public float songBpm; //bpm of song
    public float secPerBeat; //number of seconds between each beat
    public float songPos; //position in song
    public float songPosBeats; //song position in beats
    public float elapsedTime; //seconds passed since song has started
    public float offset; //used to offset for the first beat incase there is any silence beforehand
    public float margin = 0.1f;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        instance = this; //ensures only one gamemanager is created
        secPerBeat = 60f / songBpm;
        elapsedTime = (float)AudioSettings.dspTime; //records when the music starts
        music.Play();
         //calculates the seconds between each beat
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        songPos = (float)(AudioSettings.dspTime - elapsedTime - offset); //determines how long since the song has started
        songPosBeats = songPos / secPerBeat; //determines how many beats since song has started
        if(Input.anyKeyDown)
        {
            if(secPerBeat+margin >= timer && secPerBeat-margin <= timer) //making sure that player is within beat
            {
                Debug.Log("Within Beat");
                timer = 0;
            }
            else if(secPerBeat+margin > timer) //if player misses beat completely
            {
                Debug.Log("Missed Beat");
                timer = 0;
            }
        }
    }
}
