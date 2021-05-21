using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bossfire : MonoBehaviour
{
    Transform playertransform;
    Player playerscript;
    public int damage = 15;
    public bool inside = true;
    public float speed = 10f;

    void Start()
    {
        playertransform = FindObjectOfType<Player>().transform;
        playerscript = FindObjectOfType<Player>().GetComponent<Player>();
    }

    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, playertransform.position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            while (inside)
            {
                StartCoroutine(damagePlayer());
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        inside = false;
    }

    private IEnumerator damagePlayer()
    {
        playerscript.takeDamage(damage);
        yield return new WaitForSeconds(3);
    }

    private IEnumerator lifespan()
    {
        yield return new WaitForSeconds(10);
        Destroy(gameObject);
    }

}
