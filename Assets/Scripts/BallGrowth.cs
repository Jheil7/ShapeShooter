using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGrowth : MonoBehaviour
{
Vector3[] ballSizes;
int ballArrayTrack;
[SerializeField] int startingSize;
Color[] ballColors;
Renderer ballRenderer;

    // Start is called before the first frame update
    void Start()
    {
        ballSizes=new Vector3[6];
        ballSizes[0]= new Vector3(1f,1f,1f);
        ballSizes[1]= new Vector3(1.5f,1.5f,1.5f);
        ballSizes[2]= new Vector3(2f,2f,2f);
        ballSizes[3]= new Vector3(2.5f,2.5f,2.5f);
        ballSizes[4]= new Vector3(3f,3f,3f);
        ballSizes[5]= new Vector3(3.5f,3.5f,3.5f);
        gameObject.transform.localScale=ballSizes[startingSize];
        ballArrayTrack=startingSize;
        ballRenderer=gameObject.GetComponent<Renderer>();
        ballColors=new Color[6];
        ballColors[0]=Color.black;
        ballColors[1]=Color.blue;
        ballColors[2]=Color.green;
        ballColors[3]=Color.yellow;
        ballColors[4]=Color.red;
        ballColors[5]=Color.white;
        ballRenderer.material.SetColor("_Color",ballColors[startingSize]);


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ColorSetter(ballArrayTrack);
    }

    void OnTriggerEnter(Collider other) {
        if(other.tag=="Grow Bullet"){
            if(ballArrayTrack<ballSizes.Length-1){
                ballArrayTrack++;
                Destroy(other.gameObject);
            }
        }
        if(other.tag=="Shrink Bullet"){
            if(ballArrayTrack>0){
                ballArrayTrack--;
                Destroy(other.gameObject);
            } 
        }
            Mathf.Clamp(ballArrayTrack,0,ballSizes.Length);
            gameObject.transform.localScale=ballSizes[ballArrayTrack];
    }
    void ColorSetter(int ballArrayTrack){
        ballRenderer.material.SetColor("_Color",ballColors[ballArrayTrack]);
    }
}
