using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI : MonoBehaviour
{

    public SpriteRenderer spriterenderer;
    public float speed;

    public Transform target;
    [SerializeField] private float maxrange;
    [SerializeField] private float minrange;

    public Transform firePoint;
    public GameObject fire;
    public float fireforce = 10f;
    public float nextshoot;
    private bool attack;

    public int health = 20;
    public GameObject floatingpoint;
    public GameObject[] droppotion;
    public bool isbattlestart = false;
    public Transform home;
    public BattleSystem battleSystem;


    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;

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
         

            }

            if (attack)
            {
                if (Time.time > nextshoot)
                {
                    shoot();
                    nextshoot = Time.time + 0.3f;
                }
            }
        }

    }
    void movePosition()
    {
       

        transform.position = Vector2.MoveTowards(transform.position, home.position, speed * Time.deltaTime);



    }
    void FollowPlayer()
    {
       
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
            shooting shoot = player.GetComponent<shooting>();
            health -= shoot.damage;

            GameObject points = Instantiate(floatingpoint, transform.position, Quaternion.identity) as GameObject;
            points.transform.GetChild(0).GetComponent<TextMesh>().text = shoot.damage.ToString();
            Destroy(points, 0.5f);

            if (health <= 0)
            {
                Destroy(gameObject);
                int x = 0;
                foreach(GameObject drops in droppotion)
                {
                    
                    Instantiate(drops, transform.position + new Vector3(x,0f,0f), Quaternion.identity);
                    x+=2;
                }
                battleSystem.enemyCount--;
            }

        }

    }


}
