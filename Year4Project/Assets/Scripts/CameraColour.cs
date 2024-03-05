using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraColour : MonoBehaviour
{
    private GameManager man;
    private Camera cam;
    public Dictionary<int, Color32> keyColourMap = new Dictionary<int, Color32> {
        {0, new Color32(0,0,255, 255) }, //blue
        {1, new Color32(13,152,186, 255) }, //blue green
        {2, new Color32(0,255,0, 255)}, //green
        {3, new Color32(186,184,108, 255)}, //olive green
        {4, new Color32(255,255,0, 255) }, //yellow
        {5, new Color32(255,174,66, 255) }, //yellow orange
        {6, new Color32(255,165,0, 255) }, //orange
        {7, new Color32(255,0,0, 255) }, //red
        {8, new Color32(215,0,64, 255) }, //carmine
        {9, new Color32(143,0,255, 255) }, //violet
        {10, new Color32(138,43,226, 255) }, //blue violet
        {11, new Color32(75,0,130, 255) } //indigo blue
    }; //Unity Colours are accepted as float values, so Color32 is required source https://discussions.unity.com/t/why-when-i-change-the-color-of-text-from-script-it-becomes-white/128250
    // Start is called before the first frame update
    void Start()
    {
        man = GameManager.Instance;
        cam = Camera.main;
        cam.backgroundColor = keyColourMap[man.songKey];
        Debug.Log(cam.backgroundColor);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
