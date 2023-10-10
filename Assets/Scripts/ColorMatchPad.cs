using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorMatchPad : MonoBehaviour
{
    [SerializeField] GameObject transferFromPad;
    Renderer transferRenderer;
    Renderer thisRenderer;
    // Start is called before the first frame update
    void Start()
    {
        transferRenderer=transferFromPad.GetComponent<Renderer>();
        thisRenderer=GetComponent<Renderer>();
        thisRenderer.material.color=transferRenderer.material.color;     
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
