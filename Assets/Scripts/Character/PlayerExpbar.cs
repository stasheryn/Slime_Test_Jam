using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerExpbar : MonoBehaviour
{
    public Slider slider;

    public void UpdateMaxExp(int expAmountToNextLevel, int currentExp)
    {
        slider.maxValue = expAmountToNextLevel;
        slider.value = currentExp;
    }
    
    
    // рухає саме значення  слайдера
    public void UpdateExp(int amountExp)
    {
        // якщо будуть глічі з UI баром, переробити через додавання
        slider.value = amountExp;
    }

}
