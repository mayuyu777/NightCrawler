using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class GameOverScreen : MonoBehaviour
{

    public UnityEngine.UI.Text text;
    public void Setup()
    {
        
        text.text = GameObject.FindWithTag("CoinText").GetComponent<UnityEngine.UI.Text>().text;
        gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void Continue()
    {
        UnityEngine.UI.Text coin = GameObject.FindWithTag("CoinText").GetComponent<UnityEngine.UI.Text>();
        if(Convert.ToInt16(coin.text)>=20)
        {
            coin.text = Convert.ToString(Convert.ToInt16(coin.text) - 20);
            Player target = GameObject.FindWithTag("Player").GetComponent<Player>();
            target.ResetPlayerStat();
            target.isDead = false;
            gameObject.SetActive(false);
        }
        
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
