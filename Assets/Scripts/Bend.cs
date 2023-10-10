using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bend : MonoBehaviour
{
    [SerializeField] Transform offsetPos;
    BallMovement ballMovement;
    float ballSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag=="Ball"){
            other.transform.position=offsetPos.position;
            Rigidbody ballRb=other.GetComponent<Rigidbody>();
            ballMovement=other.GetComponent<BallMovement>();
            ballSpeed=ballMovement.GetBallSpeed();
            ballRb.velocity=new Vector3(0,0,0);
            if(this.tag=="Turn Left"){
                ballRb.velocity=new Vector3(0,0,-ballMovement.FinalBallSpeed()*Time.fixedDeltaTime);
            }
            if(this.tag=="PosX"){
                ballRb.velocity=new Vector3(ballMovement.FinalBallSpeed()*Time.fixedDeltaTime,0,0);
            }
            
        }
    }
}
