using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Text text = GameObject.FindWithTag("CoinText").GetComponent<UnityEngine.UI.Text>();
            text.text = Convert.ToString( Convert.ToInt16(text.text) + 1);
             Destroy(gameObject);

        }
    }
}
