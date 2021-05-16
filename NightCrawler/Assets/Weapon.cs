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
            weaponrender.sprite = collision.gameObject.GetComponent<SpriteRenderer>().sprite;
            fire.fire = collision.gameObject.GetComponent<WeaponDetail>().fire;
            fire.usage = collision.gameObject.GetComponent<WeaponDetail>().usage;
            Destroy(collision.gameObject);
        }
    }


}
