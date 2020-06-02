using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaBar : MonoBehaviour
{
    
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void SetMaxStamina(int stam)
    {
        slider.maxValue = stam;
        slider.value = stam;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetStamina(int stam)
    {
        slider.value = stam;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
