using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyAI : MonoBehaviour
{
    public Animator animator;
    public SpriteRenderer spriterenderer;
    public float speed;

    public Transform target;
    [SerializeField] private float maxrange;
    [SerializeField] private float minrange;

    public Transform firePoint;
    public GameObject fire;
    public float fireforce = 5f;
    public float nextshoot;
    private bool attack;

    public int health = 20;
    public GameObject floatingpoint;
    public GameObject[] droppotion;
    public bool isbattlestart = false;
    public Transform home;
    public BattleSystem battleSystem;
    public int shoottimes;

    public float timeShoot;

    public AudioClip shooteffect;
    public AudioSource audioSource;



    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        if (target == null)
        {
            print("player is null ai");
        }
        else
        {
            print(target.position);
        }
    }

    void Update()
    {
       
        if (isbattlestart)
        {
            if (Vector3.Distance(target.position, transform.position) <= maxrange && Vector3.Distance(target.position, transform.position) >= minrange)
            {
                FollowPlayer();
                attack = true;


            }
            else if (Vector3.Distance(target.position, transform.position) >= maxrange)
            {
                movePosition();
                attack = false;
                if (Vector3.Distance(home.position, transform.position) <= 1.5f)
                {
                    animator.SetBool("isMoving", false);
                }

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
    void movePosition()
    {
        animator.SetBool("isMoving", true);
        animator.SetFloat("X", (home.position.x - transform.position.x));
        animator.SetFloat("Y", (home.position.y - transform.position.y));

        transform.position = Vector2.MoveTowards(transform.position, home.position, speed * Time.deltaTime);
       


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
        audioSource.clip = shooteffect;
        audioSource.Play();


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
                int index = Random.Range(0,droppotion.Length);
                Instantiate(droppotion[index], transform.position, Quaternion.identity);
                battleSystem.enemyCount--;
            }

        }
     
    }



}
