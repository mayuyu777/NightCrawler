using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBoss : MonoBehaviour
{
    public Animator animator;
    public SpriteRenderer spriterenderer;
    public float speed;

    public Transform firePoint;
    public GameObject fire;
    public float fireforce = 5f;
    public float nextshoot;
    private bool attack;

    public int health;
    public GameObject floatingpoint;
    public bool isbattlestart = false;

    public float timeShoot;
    public int i;
    public Transform[] positions;
    public bool move;

    public Healthbar healthbar;
    public GameObject demonH;
    public Transform chalice;



    void Start()
    {
        i = Random.Range(0, positions.Length);
        attack = true;
        animator.SetBool("isMoving", false);
        move = true;
        healthbar.SetHealth(health);

    }

    void Update()
    {

        if (isbattlestart)
        {
               
                movePosition();
               
              

                if (Vector3.Distance(positions[i].position, transform.position) < 1f)
                {
                    i = Random.Range(0, positions.Length);
                    StartCoroutine(pauseBoss());

                }
         

            

            if (attack)
            {
                if (Time.time > nextshoot)
                {
                    shoot();
                    nextshoot = Time.time + timeShoot;
                }
            }
        }

    }

    public IEnumerator pauseBoss()
    {
        move = false;
        animator.SetBool("isMoving", false);
        yield return new WaitForSeconds(4);
        move = true;
        

    }
    void movePosition()
    {

        if (move)
        {
            animator.SetBool("isMoving", true);
            animator.SetFloat("X", (positions[i].position.x - transform.position.x));
            animator.SetFloat("Y", (positions[i].position.y - transform.position.y));

            transform.position = Vector2.MoveTowards(transform.position, positions[i].position, speed * Time.deltaTime);

        }



    }
    
    void shoot()
    {

        GameObject bullet = Instantiate(fire, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * fireforce, ForceMode2D.Impulse);


    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "bullet")
        {

            Player player = FindObjectOfType<Player>();
            shooting shoot = player.GetComponent<shooting>();
            health -= shoot.damage;
            healthbar.SetHealth(health);

            GameObject points = Instantiate(floatingpoint, transform.position, Quaternion.identity) as GameObject;
            points.transform.GetChild(0).GetComponent<TextMesh>().text = shoot.damage.ToString();
            Destroy(points, 0.5f);

            if (health <= 0)
            {
                chalice.position = transform.position;
                Destroy(gameObject);
                demonH.SetActive(false);
            }

        }

    }


}
