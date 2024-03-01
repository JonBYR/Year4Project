using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class ParticleColourChange : MonoBehaviour
{
    private GameManager man;
    public Dictionary<int, Color> keyColourMap = new Dictionary<int, Color> {
        {0, new Color(0,0,255) }, //blue
        {1, new Color(13,152,186) }, //blue green
        {2, new Color(0,255,0)}, //green
        {3, new Color(128,128,0)}, //olive green
        {4, new Color(255,255,0) }, //yellow
        {5, new Color(255,174,66) }, //yellow orange
        {6, new Color(255,165,0) }, //orange
        {7, new Color(255,0,0) }, //red
        {8, new Color(215,0,64) }, //carmine
        {9, new Color(143,0,255) }, //violet
        {10, new Color(138,43,226) }, //blue violet
        {11, new Color(75,0,130) } //indigo blue
    };
    public ParticleSystem system;
    // Start is called before the first frame update
    void Start()
    {
        man = GameManager.Instance;
        Color particleColours = keyColourMap[man.songKey];
        ParticleSystem.MainModule ma = system.main;
        ma.startColor = particleColours;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
