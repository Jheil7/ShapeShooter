using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAudio : MonoBehaviour
{
    public AudioPersist audioPersist;
    // Start is called before the first frame update
    void Awake()
    {

    }

    void Start(){
        audioPersist=FindObjectOfType<AudioPersist>();
        if(audioPersist!=null){
            audioPersist.gameObject.SetActive(false);
        }
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
