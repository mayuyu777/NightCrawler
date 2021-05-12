using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject fire;
    public int maxmana = 150;
    public int currentmana;
    public Manabar manabar;
    public int usage = 2;

    public float fireforce = 20f;
    // Update is called once per frame

    void Start()
    {
        currentmana = maxmana;
        manabar.SetMaxMana(maxmana);
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (useMana(usage)){ shoot(); }
        }
    }

    void shoot()
    {
        GameObject bullet = Instantiate(fire, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * fireforce, ForceMode2D.Impulse);
    }

    bool useMana(int usage)
    {
        bool flag = true;
        currentmana -= usage;
        if (currentmana < 0) { currentmana = 0; flag = false; }
        manabar.SetMana(currentmana);
        return flag;
    }
}
