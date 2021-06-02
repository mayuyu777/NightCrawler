using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Cinemachine.CinemachineVirtualCamera final;
    public Cinemachine.CinemachineVirtualCamera main;
    public void ExitGame()
    {
        Application.Quit();
        print("Game closed!");
    }
    public void StartGame()
    {
        //SceneManager.LoadScene("Game");
        final.Priority = 1;
        main.Priority = 2;
        gameObject.SetActive(false);
    }
}
