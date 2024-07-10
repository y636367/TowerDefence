using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slider_Text : MonoBehaviour
{
    [SerializeField]
    private Text message;
    [SerializeField]
    private Slider slider;

    private int min = 0;
    private int max = 100;

    void Start()
    {
        SetFunction_UI();
    }
    private void SetFunction_UI()
    {
        ResetFunction_UI();

        slider.onValueChanged.AddListener(Function_Slider);
    }
    private void Function_Slider(float _value)
    {
        message.text=_value.ToString();
    }
    private void ResetFunction_UI()
    {
        slider.maxValue = max;
        slider.minValue = min;
        //slider.value = 50;
        slider.wholeNumbers= true;
    }
}
