using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Tutorial : MonoBehaviour
{
    public int hitCounter;
    [SerializeField] TextMeshProUGUI objectiveFont;
    [SerializeField] GameObject continueDoor;
    // Start is called before the first frame update
    void Start()
    {
        hitCounter=0;
    }

    // Update is called once per frame
    void Update()
    {
        if(hitCounter>=10){
            objectiveFont.color=Color.green;
            continueDoor.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag=="Grow Bullet"|| other.tag=="Shrink Bullet"){
            hitCounter++;
        }
    }


}
