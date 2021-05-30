using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthpotion : MonoBehaviour
{
    public int health = 8;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Player player = collider.gameObject.GetComponent<Player>();

            if (player.currenthealth != player.maxhealth)
            {
                player.currenthealth = ((player.currenthealth + health) >= player.maxhealth) ? player.maxhealth : player.currenthealth + health;
                player.healthbar.SetHealth(player.currenthealth);
                Destroy(gameObject);
            }
        }
    }
}
