using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CanvasSelection : MonoBehaviour
{
    private GameManager man;
    [System.Serializable]
    public class MusicData
    {
        public float tempo;
        public float loudness;
        public int key;
        public int time_signature;
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
        JsonUtility.FromJson<MusicData>(pathName.text);
        Debug.Log(pathName.text);
        man.loudness = m.loudness;
        man.songBpm = m.tempo;
        man.songKey = m.key;
        man.time_signature = m.time_signature;
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
