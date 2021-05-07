using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : MonoBehaviour
{
    public GameObject hiteffect;

    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject effect = Instantiate(hiteffect, transform.position, Quaternion.identity);
        Destroy(effect, 0.5f);
        Destroy(gameObject);
    }
}
