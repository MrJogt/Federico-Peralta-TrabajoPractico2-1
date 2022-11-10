using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{

    public Slider volumeSlider;
    public Toggle muted;
    

    // Start is called before the first frame update
    void Start()
    {
        
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
        MuteTogglerChecker();
    }



    public void VolumeValue()
    {
        
        PlayerPrefs.SetFloat("volume", volumeSlider.value);
        Debug.Log(PlayerPrefs.GetFloat("volume"));
        
    }

    public void Mute()
    {
        if(muted.isOn == true)
        {
            
            PlayerPrefs.SetFloat("volume", volumeSlider.value);
            Debug.Log("El volumen guardado cuando muteaste es " + PlayerPrefs.GetFloat("volume"));
            volumeSlider.value = 0;


        }
        else
        {
            volumeSlider.value = PlayerPrefs.GetFloat("volume");
            Debug.Log("El volumen anterior " + PlayerPrefs.GetFloat("volume") + " fue cargado con exito");

        }
    }


    public void DefaultSettings()
    {
        PlayerPrefs.SetFloat("volumeDefault", 1);
        PlayerPrefs.SetInt("mutedDefault", 0);
        volumeSlider.value = PlayerPrefs.GetFloat("volumeDefault", volumeSlider.value);
        muted.isOn = PlayerPrefs.GetInt("mutedDefault") == 0 ? false : true;
    }

    public void MuteTogglerChecker()
    {
        PlayerPrefs.SetInt("isMuted", muted.isOn ? 1 : 0);
    }
    
}
