using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void ExitGame()
    {
        Application.Quit();
        print("Game closed!");
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }
}
