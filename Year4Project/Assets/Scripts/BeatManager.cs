using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatManager : MonoBehaviour
{
    public GameManager man; //use this website https://audioalter.com/bpm-detector to try and find the BPM of songs,
    public float margin = 0.1f;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.anyKeyDown)
        {
            //Debug.Log("Pressed");
        }
    }
}
