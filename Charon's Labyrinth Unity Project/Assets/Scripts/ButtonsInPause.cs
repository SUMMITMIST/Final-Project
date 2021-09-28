using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsInPause : MonoBehaviour
{
    bool volsetActive = false;
    
    public GameObject volumeSet;

    private void Awake()
    {
        volumeSet = GameObject.Find("VolumeSettings");
        volumeSet.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetButtonDown("Cancel") && volsetActive)
        {
            pauseSettingsBack();
        }
    }

    public void pauseToSettings()
    {
        //Слева настройки звука
        volsetActive = true;
        volumeSet.SetActive(true);
        //Слева настройки звука
    }
    public void pauseSettingsBack()
    {
        volsetActive = false;
        volumeSet.SetActive(false);
    }

    public void ToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

}
