using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manapotion : MonoBehaviour
{
    public int mana = 8;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            shooting shootscript = collider.gameObject.GetComponent<shooting>();
            if (shootscript.currentmana != shootscript.maxmana)
            {
                shootscript.increasemana(mana);
                Destroy(gameObject);
            }
        }
     }
}
