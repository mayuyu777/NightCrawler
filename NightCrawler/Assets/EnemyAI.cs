using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyAI : MonoBehaviour
{
    public Animator animator;
    public SpriteRenderer spriterenderer;
    public float speed;
    private float waitTime;
    public float startwaitTime;
    public Transform[] moveSpots;
    private int randomSpot;

    public Transform target;
    [SerializeField] private float maxrange;
    [SerializeField] private float minrange;

    public Transform firePoint;
    public GameObject fire;
    public float fireforce = 20f;
    public float nextshoot;
    private bool attack;

    public int health = 20;
    public GameObject floatingpoint;
    public GameObject droppotion;

    void Start()
    {
        target = FindObjectOfType<Player>().transform;
        waitTime = startwaitTime;
        moveSpots[0].position = transform.position + new Vector3(2f,0f, 0f);
        moveSpots[1].position = transform.position + new Vector3(-2f, 0f, 0f);
        randomSpot = Random.Range(0, moveSpots.Length);

     
        print(moveSpots[0].position);
        print(moveSpots[1].position);
        print(transform.position);
    }

    void Update()
    {

        if (Vector3.Distance(target.position, transform.position) <= maxrange && Vector3.Distance(target.position, transform.position) >= minrange)
        {
            FollowPlayer();
            attack = true;
            

        }
        else if(Vector3.Distance(target.position, transform.position) >= maxrange)
        {
            movePosition();
            attack = false;
        }

        if (attack)
        {
            if (Time.time > nextshoot)
            {
                shoot();
                nextshoot = Time.time + 1f;
            }
        }
        
    }
    void movePosition()
    {
        animator.SetBool("isMoving", true);
        animator.SetFloat("X", (moveSpots[randomSpot].position.x - transform.position.x));
        animator.SetFloat("Y", (moveSpots[randomSpot].position.y - transform.position.y));

        transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f)
        {
            if (waitTime <= 0)
            {

                randomSpot = Random.Range(0, moveSpots.Length);
                waitTime = startwaitTime;
            }
            else
            {
                animator.SetBool("isMoving", false);
                waitTime -= Time.deltaTime;
            }
        }
    }
    void FollowPlayer()
    {
        animator.SetBool("isMoving", true);
        animator.SetFloat("X", (target.position.x - transform.position.x));
        animator.SetFloat("Y", (target.position.y - transform.position.y));
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);

        

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
            shooting shoot= player.GetComponent<shooting>();
            health -= shoot.damage;

            GameObject points = Instantiate(floatingpoint, transform.position, Quaternion.identity) as GameObject;
            points.transform.GetChild(0).GetComponent<TextMesh>().text = shoot.damage.ToString();
            Destroy(points, 0.5f);

            if (health <= 0)
            {
                Destroy(gameObject);
                Instantiate(droppotion, transform.position, Quaternion.identity);
            }

        }
     
    }



}
