using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bossfire : MonoBehaviour
{
   
    public int damage = 15;
    public Animator animator;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Player player = collider.GetComponent<Player>();
            player.takeDamage(damage);
        }
    }
}
