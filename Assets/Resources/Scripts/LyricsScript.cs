using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LyricsScript : MonoBehaviour
{
    public List<int> lyricsInTime;
    public List<int> lyricsEndTime;
    public DateTime init;
    public TimeSpan initNow = new TimeSpan(0);
    public string[] lyrics;
    public Text lyricsText;
    public Text timeNow;
    // Start is called before the first frame update
    void Start()
    {
        lyrics = System.IO.File.ReadAllLines(@"Assets\Resources\Lyrics\LyricsHowToBurnOnNight.txt");
        init = DateTime.Now + initNow;
        lyricsInTime = new List<int>();
        lyricsEndTime = new List<int>();
        LyricsController();


    }

    // Update is called once per frame
    void Update()
    {
        if (lyrics.Length == lyricsEndTime.Count && lyrics.Length == lyricsInTime.Count)
        {
            LyricsChecker();
        }
        timeNow.text = initNow.ToString();
    }


    public void LyricsController()
    {
        foreach (string linea in lyrics)
        {
            
            int startMin = Convert.ToInt16(linea.Substring(0, 2));
            int startSeg = Convert.ToInt16(linea.Substring(3, 2));
            int endMin = Convert.ToInt16(linea.Substring(6, 2));
            int endSeg = Convert.ToInt16(linea.Substring(9, 2));
            lyricsInTime.Add(startMin * 60 + startSeg);
            lyricsEndTime.Add(endMin * 60 + endSeg);

        }

    }

    public void LyricsChecker()
    {
         initNow =  DateTime.Now - init ;
        for (int i = 0; i < lyrics.Length; i++)
        {
            int startTime = lyricsInTime[i];
            int endTime = lyricsEndTime[i];
            string lyricsNow = lyrics[i];          
            if (initNow.TotalSeconds > startTime && initNow.TotalSeconds < endTime)
            {
                lyricsText.text = lyricsNow.Substring(13);
                Debug.Log(lyricsText.text);
                return;
            }

        }
        lyricsText.text = "";
    }

}
