using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthbar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxHealth(float healthMax)
    {
        slider.maxValue = healthMax;
        slider.value = healthMax;
    }
    
    
    // рухає саме значення  слайдера
    public void SetCurrentHealth(float healthCurrent)
    {
        slider.value = healthCurrent;
    }
    
    
}
