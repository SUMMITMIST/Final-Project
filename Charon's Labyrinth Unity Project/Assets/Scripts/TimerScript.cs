using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TimerScript : ScenesInMenu
{
    public float timeBegin = 20;
    public bool timerIsRunning = false;
    public Text timeText;

    public GameObject imgObj;
    public GameObject playerObj;
    
    public FPSController noMove;

    public bool runOnce = false;

    void Start()
    {
        imgObj = GameObject.Find("Controls");
        playerObj = GameObject.Find("Player");
        noMove = playerObj.GetComponent<FPSController>();


        noMove.canMove = false;
        StartCoroutine(controlShow());     
    }

    void Update()
    {
        Debug.Log(timeBegin);
        if (timeBegin > 0 && timerIsRunning)
        {
            timeBegin -= Time.deltaTime;
            DisplayTime(timeBegin);
        }
        else if(timeBegin <= 0 && timerIsRunning)
        {
            Debug.Log("Time has run out!");
            timeBegin = 0;
            timerIsRunning = false;
            
            if (runOnce == false)
            {
                runOnce = true;
                DefeatScene();
            }
        }
    }
    

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
                
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    IEnumerator controlShow()
    {
        imgObj.SetActive(false);
        yield return new WaitForSeconds(1);
        imgObj.SetActive(true);
        yield return new WaitForSeconds(6);
        imgObj.SetActive(false);

        noMove.canMove = true;
        timerIsRunning = true;
    }
}
