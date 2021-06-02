using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Chalice : MonoBehaviour
{
    public GameObject youwin;
    public AudioClip effect;
    public AudioSource audioSource;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            audioSource.clip = effect;
            audioSource.Play();
            StartCoroutine(Finish());
        }
    }
    public IEnumerator Finish()
    {
        youwin.SetActive(true);
       yield return new WaitForSeconds(5);
        youwin.SetActive(false);
        SceneManager.LoadScene("Game");
        
    }
}
