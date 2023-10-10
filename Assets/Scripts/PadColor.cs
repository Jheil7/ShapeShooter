using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadColor : MonoBehaviour
{
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
    
    private void Awake() {
        myRenderer = GetComponent<Renderer>();
        colors=ColorSwitcher(colorDropDown);
        myRenderer.material.color=colors;
        padColor=myRenderer.material.color;
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
