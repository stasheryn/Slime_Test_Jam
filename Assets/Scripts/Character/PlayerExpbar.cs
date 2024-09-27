using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerExpbar : MonoBehaviour
{
    public Slider slider;

    public void UpdateMaxExp(int maxExpAmount)
    {
        // refactor
        slider.maxValue = maxExpAmount;
        slider.value = 0;
    }
    
    
    // рухає саме значення  слайдера
    public void AddExp(int addAmountExp)
    {
        slider.value += addAmountExp;
    }

}
