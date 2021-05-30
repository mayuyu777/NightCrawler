using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MyCoins : MonoBehaviour
{
    public void changeText()
    {
        Text text = GetComponent<UnityEngine.UI.Text>();
        text.text = GameObject.FindWithTag("CoinText").GetComponent<UnityEngine.UI.Text>().text;
    }
}
