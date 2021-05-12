using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;


public class Weapon : MonoBehaviour
{
    public GameObject weapon;
    SpriteRenderer weaponrender;


    // Start is called before the first frame update

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Weapons")
        {
            weaponrender = weapon.GetComponent<SpriteRenderer>();
            SpriteRenderer newweaponrender = collision.gameObject.GetComponent<SpriteRenderer>();
            weaponrender.sprite = newweaponrender.sprite;
            Destroy(collision.gameObject);
        }
    }


}
