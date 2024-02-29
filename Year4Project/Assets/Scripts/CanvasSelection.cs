using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CanvasSelection : MonoBehaviour
{
    private GameManager man;
    [System.Serializable]
    public class Meta //contains all relevant information regarding retrieval of json file
    {
        public string analyzer_version;
        public string platform;
        public string detailed_status;
        public int status_code;
        public int timestamp;
        public double analysis_time;
        public string input_process;
    }
    public class Track // https://stackoverflow.com/questions/45215320/how-to-take-a-particular-field-from-json-data-in-unity
    {
        public int num_samples;
        public double duration;
        public string sample_md5;
        public int offset_seconds;
        public int window_seconds;
        public int analysis_sample_rate;
        public int analysis_channels;
        public double end_of_fade_in;
        public double starta_of_fade_out;
        public float loudness;
        public float tempo;
        public double tempo_confidence;
        public int time_signature;
        public double time_signature_confidence;
        public int key;
        public double key_confidence;
        public int mode;
        public double mode_confidence;
        public string codestring;
        public double code_version;
        public string echoprintstring;
        public double echoprint_version;
        public string synchstring;
        public double synch_version;
        public string rhythmstring;
        public double rhythm_version;
    }
    public class MusicData
    {
        public List<Meta> m;
        public List<Track> t;
    }
    public MusicData m = new MusicData();
    // Start is called before the first frame update
    void Start()
    {
        man = GameManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MusicLoader(TextAsset pathName)
    {
        m = JsonUtility.FromJson<MusicData>(pathName.text);
        Debug.Log(pathName.text);
        man.loudness = m.t[0].loudness;
        man.songBpm = m.t[0].tempo;
        man.songKey = m.t[0].key;
        man.time_signature = m.t[0].time_signature;
        SceneManager.LoadScene("GameScene");
    }
    public void AudioLoader(AudioClip a)
    {
        man.music.clip = a;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
