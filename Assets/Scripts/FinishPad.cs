using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishPad : MonoBehaviour
{
    Color padColor;
    private Renderer myRenderer;
    public Colorenum colorDropDown;
    Color colors;
    [SerializeField] GameObject continueDoor;
    Scene currentScene;
    string sceneName;
    [SerializeField] AudioSource audioThing;
    [SerializeField] AudioSource startAudio;
    BallSpawner ballSpawner;
    int ballSpawnerCount;
    //int finishedTracker;
    public enum Colorenum
     {
         black=0, 
         blue=1, 
         green=2,
         yellow=3,
         red=4,
         white=5
     };

    void Awake()
    {
        myRenderer = GetComponent<Renderer>();
        colors=ColorSwitcher(colorDropDown);
        myRenderer.material.color=colors;
        padColor=myRenderer.material.color;
        ballSpawner=FindObjectOfType<BallSpawner>();
        ballSpawnerCount=ballSpawner.GetFinishPadCount();
        //finishedTracker=0;
        currentScene=SceneManager.GetActiveScene();
        sceneName=currentScene.name;
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag=="Ball"){
            Color getBallColor=other.GetComponent<Renderer>().material.color;
            if(getBallColor==padColor){
                ballSpawner.FinishedTracker();
                if(ballSpawner.AllFinished()){
                    continueDoor.SetActive(true);
                }
                if(sceneName=="Tutorial 1"){
                    startAudio.Stop();
                    audioThing.Play();
                }
            }
        }
    }

    public Color ColorSwitcher(Colorenum colorDropDown){
        switch(colorDropDown){
            case Colorenum.black:
            return Color.black;

            case Colorenum.blue:
            return Color.blue;

            case Colorenum.green:
            return Color.green;

            case Colorenum.yellow:
            return Color.yellow;

            case Colorenum.red:
            return Color.red;

            case Colorenum.white:
            return Color.white;

            default:
            return Color.black;
        }
    }
}
