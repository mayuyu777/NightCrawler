using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    Vector2 movement;

    public int maxhealth = 150;
    public int currenthealth;
    public Healthbar healthbar;

    public Animator animator;
    public bool isDead;

    public GameOverScreen gameOverScreen;

    public GameObject[] players;
    public GameObject temp;

    void Start()
    {
        currenthealth = maxhealth;
        healthbar.SetMaxHealth(maxhealth);
        isDead = false;
        DontDestroyOnLoad(gameObject);
        players = GameObject.FindGameObjectsWithTag("Player");
        if(players.Length > 1)
        {
            temp = players[0];
            players[0] = players[1];
            Destroy(temp);
        }
    }
  
    private void Update()
    {
        if (!isDead)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
            animator.SetFloat("X", movement.x);
            animator.SetFloat("Y", movement.y);

            if (movement.x == 1 || movement.x == -1 || movement.y == 1 || movement.y == -1)
            {
                animator.SetFloat("LastMoveX", movement.x);
                animator.SetFloat("LastMoveY", movement.y);
            }
            if(currenthealth <= 0)
            {
                GameOver();
            }
        }

    }

    void GameOver()
    {
        gameOverScreen.Setup();
        isDead = true;
    }

    public void takeDamage(int damage)
    {
        currenthealth -= damage;
        if (currenthealth < 0) { currenthealth = 0; }
        healthbar.SetHealth(currenthealth);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemyfire")
        {

            int damage = collision.gameObject.GetComponent<enemyfire>().damage;
            takeDamage(damage);

        }else if(collision.gameObject.tag == "mana")
        {
            int mana  = collision.gameObject.GetComponent<manapotion>().mana;
            shooting shootscript = gameObject.GetComponent<shooting>();
            shootscript.increasemana(mana);
            Destroy(collision.gameObject);

        }else if(collision.gameObject.tag == "health")
        {

            int health = collision.gameObject.GetComponent<healthpotion>().health;
            currenthealth = ((currenthealth + health) >= maxhealth) ? maxhealth : currenthealth + health;
            healthbar.SetHealth(currenthealth);
            Destroy(collision.gameObject);
        }
    }

}
