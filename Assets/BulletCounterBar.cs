using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletCounterBar : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider slider;

    public void setMaxBullet(int bullet)
    {
        slider.maxValue = bullet;
        slider.value = bullet;
    }
    public void setBullet(int bullet)
    {
        slider.value = bullet;
    }
}
