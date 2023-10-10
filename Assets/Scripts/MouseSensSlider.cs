using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseSensSlider : MonoBehaviour
{
    public Slider slider;
    public float sliderValue;
    public Text sensText;
    // Start is called before the first frame update
    void Start()
    {
        slider=FindObjectOfType<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        sliderValue=slider.value;
        SetSens();
        SetSensText();
    }

    void SetSens(){
        PlayerPrefs.SetFloat("Sensitivity", sliderValue);
    }

    void SetSensText(){
        sensText.text=sliderValue.ToString();
    }
}
