using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Portal : MonoBehaviour
{

    public GameObject levelcanvas;
    public GameObject cleared;
    public Transform startpoint;
    public bool isfinal = false;

    public Cinemachine.CinemachineVirtualCamera final;
    public FinalBoss boss;
    public GameObject DemonHealthbar;


    private void OnTriggerEnter2D(Collider2D collider)
    {
        
        if (collider.gameObject.tag == "Player")
        {
           

            cleared.SetActive(false);
            levelcanvas.SetActive(true);

            GameObject player = GameObject.FindWithTag("Player");
            Player play = player.GetComponent<Player>();
            player.transform.position = startpoint.position;

            // play.ResetPlayerStat();
            if (isfinal)
            {
                final.Priority = 3;

                StartCoroutine(waitBoss());
                
            }

            StartCoroutine(disableLevel());
        }
    }

    public IEnumerator waitBoss()
    {
        DemonHealthbar.SetActive(true);
        yield return new WaitForSeconds(5);
        boss.isbattlestart = true;
    }


    public IEnumerator disableLevel()
    {
        yield return new WaitForSeconds(5);
        levelcanvas.SetActive(false);
    }

}
