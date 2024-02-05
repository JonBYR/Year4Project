using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class BalanceController : MonoBehaviour
{
    public GameManager man;
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
    public VolumeProfile vol;
    UnityEngine.Rendering.Universal.WhiteBalance bal;
    UnityEngine.Rendering.Universal.Bloom bloom;
    UnityEngine.Rendering.Universal.ChannelMixer mixer;
    // Start is called before the first frame update
    void Start()
    {
        if(vol.TryGet<Bloom>(out bloom))
        {
            Color bloomColours = keyColourMap[man.songKey];
            bloom.tint.Override(bloomColours);
        }
        if(vol.TryGet<ChannelMixer>(out mixer))
        {
            Color mixerColours = keyColourMap[man.songKey];
            mixer.redOutRedIn.Override(mixerColours.r * (200.0f / 255.0f)); //gets red channel of channel mixer and scales it between 0-200
            mixer.greenOutGreenIn.Override(mixerColours.g * (200.0f / 255.0f)); //gets green channel of channel mixer
            mixer.blueOutBlueIn.Override(mixerColours.b * (200.0f / 255.0f)); //gets blue channel of channel mixer
            //mixer.redOutRedIn.Override(200.0f - (mixerColours.r * (200.0f / 255.0f))); //gets red channel of channel mixer and scales it between 0-200
            //mixer.greenOutGreenIn.Override(200.0f - (mixerColours.g * (200.0f / 255.0f))); //gets green channel of channel mixer
            //mixer.blueOutBlueIn.Override(200.0f - (mixerColours.b * (200.0f / 255.0f))); //gets blue channel of channel mixer
            Debug.Log(mixerColours.r);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
