using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    Rigidbody sphereRb;
    [SerializeField] float ballSpeed;
    float finalSpeed;
    SpeedUp speedUp;
    float speedMod;
    int speedModCount;
    // Start is called before the first frame update
    void Start()
    {
        speedMod=1f;
        speedModCount=0;
        sphereRb=GetComponent<Rigidbody>();
        sphereRb.linearVelocity=new Vector3(-SetBallSpeed(speedMod)*Time.fixedDeltaTime,0,0);        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float GetBallSpeed(){
        return ballSpeed;
    }

    public float SetBallSpeed(float speedMod){
        return speedMod*ballSpeed;
    }

    public float FinalBallSpeed(){
        if(speedModCount==0){
            return SetBallSpeed(speedMod);
        }
        else
            return SetBallSpeed(speedMod*speedModCount);
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag=="Speed Up"){
            speedModCount++;
            speedUp=other.GetComponent<SpeedUp>();
            speedMod=speedUp.GetSpeedMod();
            sphereRb.linearVelocity=new Vector3(-FinalBallSpeed()*Time.fixedDeltaTime,0,0);
        }
        if(other.tag=="Speed Up X"){
            speedModCount++;
            speedUp=other.GetComponent<SpeedUp>();
            speedMod=speedUp.GetSpeedMod();
            sphereRb.linearVelocity=new Vector3(FinalBallSpeed()*Time.fixedDeltaTime,0,0);
        }
    }
}
