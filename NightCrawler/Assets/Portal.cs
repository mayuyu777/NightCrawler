using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Portal : MonoBehaviour
{

    public int level = 1;
    public GameObject levelcanvas;
    public GameObject cleared;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        
        if (collider.gameObject.tag == "Player")
        {
            GameObject level1 = GameObject.FindWithTag("Level1");

            cleared.SetActive(false);
            levelcanvas.SetActive(true);

            Transform startpoint = GameObject.FindWithTag("Startpoint").transform;
            GameObject player = GameObject.FindWithTag("Player");
            Player play = player.GetComponent<Player>();
            player.transform.position = startpoint.position;

            play.ResetPlayerStat();

            StartCoroutine(disableLevel());
        }
    }

    public IEnumerator disableLevel()
    {
        yield return new WaitForSeconds(5);
        levelcanvas.SetActive(false);
    }

}
