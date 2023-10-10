using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialDoor : MonoBehaviour
{
    Scene currentScene;
    public string sceneName;
    // Start is called before the first frame update
    void Start()
    {
        currentScene=SceneManager.GetActiveScene();
        sceneName=currentScene.name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag=="Player"){
            if(sceneName=="Tutorial 0"){
                SceneManager.LoadScene("Tutorial 1");
            }
            if(sceneName=="Tutorial 1"){
                SceneManager.LoadScene("Main Menu");
            }
        }
    }
}
