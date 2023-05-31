using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timeBar : MonoBehaviour
{
    public Slider slider;

    public void setMaxTIME(int time)
    {
        slider.maxValue = time;
        slider.value = time;
    }
    public void setTime(int time)
    {
        slider.value = time;
    }
}
