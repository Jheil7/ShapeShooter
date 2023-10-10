using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState=CursorLockMode.None;
        Cursor.visible=true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadGame(){
        Time.timeScale=1.0f;
        SceneManager.LoadScene("Level 0");
    }

    public void Tutorial0(){
        SceneManager.LoadScene("Tutorial 0");
    }
    public void Tutorial1(){
        SceneManager.LoadScene("Tutorial 1");
    }

    public void LoadMainMenu(){
        SceneManager.LoadScene("Main Menu");
    }

    // public void LoadGameOver(){
    //     StartCoroutine(WaitAndLoad("Game Over", sceneLoadDelay));
    // }

    public void QuitGame(){
        Debug.Log("Quitting Game");
        Application.Quit();
    }

}
