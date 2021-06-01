using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fume : MonoBehaviour
{
    public int damage = 3;
    public float nextdamage;
    public bool playerinside;

    void Start()
    {
        playerinside = false;
        StartCoroutine(DestroyFume());
    }

    void Update()
    {
        if (playerinside)
        {
            if (Time.time > nextdamage)
            {
                damagePlayer();
                nextdamage = Time.time + 3f;
            }
        }
        
    }

    public IEnumerator DestroyFume()
    {
        yield return new WaitForSeconds(6);
        Destroy(gameObject);
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
