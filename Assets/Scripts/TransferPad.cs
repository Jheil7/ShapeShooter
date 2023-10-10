using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransferPad : MonoBehaviour
{
    [SerializeField] Transform offsetPos;
    BallMovement ballMovement;
    float ballSpeed;
    Color padColor;
    private Renderer myRenderer;
    public Colorenum colorDropDown;
    Color colors;
    
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
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag=="Ball"){
            Color getBallColor=other.GetComponent<Renderer>().material.color;
            if(getBallColor==padColor){
                other.transform.position=offsetPos.position;
                Rigidbody ballRb=other.GetComponent<Rigidbody>();
                ballMovement=other.GetComponent<BallMovement>();
                ballSpeed=ballMovement.GetBallSpeed();
                ballRb.velocity=new Vector3(0,0,0);
                if(this.tag=="PosX"){
                    ballRb.velocity=new Vector3(ballMovement.FinalBallSpeed()*Time.fixedDeltaTime,0,0);
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
