using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioScript : MonoBehaviour
{

    public AudioSource music;

    // Start is called before the first frame update
    void Start()
    {
        music.volume = PlayerPrefs.GetFloat("volume");
        MuteCheck();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void MuteCheck()
    {
        music.mute = PlayerPrefs.GetInt("isMuted") == 1 ? true : false;
    }

}
