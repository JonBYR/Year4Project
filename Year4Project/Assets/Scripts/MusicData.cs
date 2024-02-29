using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicData : MonoBehaviour
{
    public class Music
    {
        public float tempo;
        public float loudness;
        public int key;
        public int time_signature;
    }
    static Music m;
    private TextAsset jsonFile;
    public static void setVariables(float t, float l, int k, int s)
    {
        m.tempo = t;
        m.loudness = l;
        m.key = k;
        m.time_signature = s;
    }
    public static float getTempo()
    {
        return m.tempo;
    }
    public static float getLoudness()
    {
        return m.loudness;
    }
    public static int getKey()
    {
        return m.key;
    }
    public static int getTimeSignature()
    {
        return m.time_signature;
    }
}
