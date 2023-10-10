using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioPersist : MonoBehaviour
{
    private AudioSource audioSource;
    public static AudioPersist instance;
    private Scene scene;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            DontDestroyOnLoad(instance);
            SceneManager.sceneLoaded+=OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        if (SceneManager.GetActiveScene().buildIndex == 0){
            audioSource.Stop();
        }

        else if(SceneManager.GetActiveScene().buildIndex == 3){
            audioSource.Play();
        }
    }


}
