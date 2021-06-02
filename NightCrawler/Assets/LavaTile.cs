using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaTile : MonoBehaviour
{
    public int damage = 15;
    public float nextdamage;
    public bool playerinside;

    void Start()
    {
        playerinside = false;
   
    }

    void Update()
    {
        if (playerinside)
        {
            if (Time.time > nextdamage)
            {
                damagePlayer();
                nextdamage = Time.time + 1f;
            }
        }

    }

  
    public void damagePlayer()
    {
        Player player = GameObject.FindWithTag("Player").GetComponent<Player>();
        player.takeDamage(damage);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            playerinside = true;

        }
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            playerinside = false;

        }
    }
}
