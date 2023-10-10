using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueDoor : MonoBehaviour
{
    Scene currentScene;
    public int sceneTracker;
    // Start is called before the first frame update
    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag=="Player"){
            currentScene=SceneManager.GetActiveScene();
            sceneTracker=currentScene.buildIndex;
            SceneManager.LoadScene(sceneTracker+1);
            if(sceneTracker==SceneManager.sceneCountInBuildSettings-2){
                SceneManager.LoadScene("Main Menu");
            }
        }
    }
}
