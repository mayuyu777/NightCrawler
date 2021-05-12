using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;


public class Weapon : MonoBehaviour
{
    public GameObject weapon;
    SpriteRenderer weaponrender;
    public shooting fire;


    // Start is called before the first frame update

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Weapons")
        {
            weaponrender = weapon.GetComponent<SpriteRenderer>();
            SpriteRenderer newweaponrender = collision.gameObject.GetComponent<SpriteRenderer>();
            GameObject newfire = collision.gameObject.GetComponent<WeaponDetail>().fire;
            weaponrender.sprite = newweaponrender.sprite;
            fire.fire = newfire;
            Destroy(collision.gameObject);
        }
    }


}
