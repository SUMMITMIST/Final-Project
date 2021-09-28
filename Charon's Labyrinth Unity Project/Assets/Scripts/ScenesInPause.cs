using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesInPause : MonoBehaviour
{
    bool escPressed = false;

    public FPSController script;

    private void Start()
    {
        script = GetComponent<FPSController>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Cancel") && escPressed == false)
        {
            escPressed = true;
            pauseGame();
            script.canMove = false;
        }
        else if (Input.GetButtonDown("Cancel") && escPressed == true)
        {
            escPressed = false;
            unpauseGame();
            script.canMove = true;
        }
    }

    public void pauseGame()
    {
        //escPressed = true;
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        SceneManager.LoadScene(5, LoadSceneMode.Additive);
    }

    public void unpauseGame()
    {
        //escPressed = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
        SceneManager.UnloadSceneAsync(5);
    }


}
