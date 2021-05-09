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

    void Start()
    {
        currenthealth = maxhealth;
        healthbar.SetMaxHealth(maxhealth);
    }
  
    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        animator.SetFloat("X", movement.x);
        animator.SetFloat("Y", movement.y);

        if( movement.x == 1 || movement.x == -1 || movement.y == 1 || movement.y == -1)
        {
            animator.SetFloat("LastMoveX", movement.x);
            animator.SetFloat("LastMoveY", movement.y);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            takeDamage(7);
        }

    }

    void takeDamage(int damage)
    {
        currenthealth -= damage;
        if (currenthealth < 0) { currenthealth = 0; }
        healthbar.SetHealth(currenthealth);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

}
