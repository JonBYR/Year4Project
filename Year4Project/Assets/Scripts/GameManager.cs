using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //taken from this githib repo https://github.com/JJMaslen/WalkWithRhythm
    public AudioSource music;
    public static GameManager Instance { get; private set; }
    public float songBpm; //bpm of song (this will be changed to be equal to values from a json file)
    public int songKey;
    public int time_signature; //will be used for enemy spawning
    public float loudness; //this will be changed later to be based on loudness
    public int margin;
    public int timer;
    public double dTimer;
    public double dMargin;
    public bool onBeat = false; //used to determine if a player can move as it is within the bpm
    public Dictionary<int, bool> enemyObjects = new Dictionary<int, bool>();
    bool beatDone = false;
    public double bpmConversion(double bpm)
    {
        double fixedUpdateBpm = 60 / bpm; //fixed Update is 50 frames rather than 60 frames per second, so bpm must be converted to match the timing for fixedUpdate
        return fixedUpdateBpm;
    }
    private void Awake()
    {
        if (Instance != null && Instance != this) //how to instantiate instances in unity
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        music.Play();
    }
    // Start is called before the first frame update
    public void RegisterEnemy(int enemyID)
    {
        enemyObjects.Add(enemyID, true); //add new value in dictionary with unique enemy id and set to true
    }
    public void setEnemyMove(int enemyID)
    {
        enemyObjects[enemyID] = false;
    }
    public bool returnEnemyMove(int enemyID)
    {
        return enemyObjects[enemyID];
    }
    void Update() 
    {
        dTimer += Time.deltaTime;
        double bpm = bpmConversion(songBpm);
        if(dTimer >= bpm - dMargin || dTimer < 0.0+dMargin) 
        {
            onBeat = true;
            if(beatDone == false) beatDone = true;
        }
        else 
        {
            if(beatDone == true)
            {
                beatDone = false;
                foreach(int id in enemyObjects.Keys.ToList()) //once beat is completed let enemies move again
                {
                    enemyObjects[id] = true;
                }
            }
            onBeat = false;
        }
        if(dTimer == bpm) dTimer = 0;
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
                if(beatDone == false) beatDone = true;
            }
            onBeat = true;
        }
        else if (count <= margin) //accounts for lateness
        {
            onBeat = true;
        }
        else
        {
            if(beatDone == true)
            {
                beatDone = false;
                foreach(int id in enemyObjects.Keys.ToList()) //once beat is completed let enemies move again
                {
                    enemyObjects[id] = true;
                }
            }
            onBeat = false;
        }
    }
}
