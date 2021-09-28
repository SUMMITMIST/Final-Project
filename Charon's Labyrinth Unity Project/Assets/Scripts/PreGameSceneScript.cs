using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreGameSceneScript : MonoBehaviour
{
    GameObject buttonPlay;
    private void Awake()
    {
        buttonPlay = GameObject.Find("Play_Button");
        buttonPlay.SetActive(false);
    }

    private void Start()
    {
        StartCoroutine(waitForButtonPlay());
    }

    IEnumerator waitForButtonPlay()
    {
        yield return new WaitForSeconds(8);
        buttonPlay.SetActive(true);
        Cursor.visible = true;
    }
}
