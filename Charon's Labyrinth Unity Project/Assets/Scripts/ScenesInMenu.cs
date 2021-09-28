using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesInMenu : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;


    public void Play() 
    {
        StartCoroutine(LoadLevel());

        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
    public void Settings() 
    {
        StartCoroutine(LoadLevel());

        SceneManager.LoadScene(2, LoadSceneMode.Single);
    }
    public void ToMenu()
    {
        StartCoroutine(LoadLevel());

        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
    public void GameQuit() 
    {
        StartCoroutine(LoadLevel());

        Application.Quit();
    }
    public void DefeatScene()
    {
        StartCoroutine(LoadLevel());
        
        SceneManager.LoadScene(3, LoadSceneMode.Single);
        
        
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    public void VictoryScene()
    {
        StartCoroutine(LoadLevel());

        SceneManager.LoadScene(4, LoadSceneMode.Single);

        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    public void preGame()
    {
        StartCoroutine(LoadLevel());
        Cursor.visible = false;
        SceneManager.LoadScene(6, LoadSceneMode.Single);
    }

    public IEnumerator LoadLevel()
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
    }
}
