using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manabar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxMana(int maxmana)
    {
        slider.maxValue = maxmana;
        slider.value = maxmana;

    }

    public void SetMana(int mana)
    {
        slider.value = mana;
    }
}
