using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] GameObject ball;
    [SerializeField] Transform spawner;
    bool canInteract;
    bool ballExists;
    GameObject ballInstance;
    [SerializeField] int finishPadCount=1;
    int finishedTracker=0;

    // Start is called before the first frame update
    void Start()
    {
        canInteract=false;
        ballExists=false;
    }

    // Update is called once per frame
    void Update()
    {
        if (canInteract && Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag=="Player"){
            canInteract=true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.tag=="Player"){
            canInteract=false;
        }
    }

    void Interact(){
            if(ball!=null){
                Debug.Log("spawn ball");
                Destroy(ballInstance);
                ballExists=false;
            }
            if(!ballExists){
                ballInstance=Instantiate(ball, spawner.position, spawner.rotation);
                finishedTracker=0;
                ballExists=true;
            }
    }

    public int GetFinishPadCount(){
        return finishPadCount;
    }
    public void FinishedTracker(){
        finishedTracker++;
    }

    public bool AllFinished(){
        if(finishPadCount==finishedTracker){
            return true;
        }
        else
            return false;
    }


}
