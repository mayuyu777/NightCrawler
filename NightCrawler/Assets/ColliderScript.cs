using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderScript : MonoBehaviour
{
    public event EventHandler OnPlayerEnterTrigger;
     public GameObject[] gates;
    public Animator animator;
    public bool active = false;
    public bool playerexit = false;
    public bool cleared = false;


    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (!active )
        {
            if (collider.gameObject.tag == "Player")
            {
                Debug.Log("Player is in the area");
                 OnPlayerEnterTrigger?.Invoke(this, EventArgs.Empty);

                foreach (GameObject gate in gates)
                {
                    animator = gate.GetComponent<Animator>();
                    animator.SetBool("gateOpen", true);
                }

               
            }
            active = true;
        }
        
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (!playerexit)
        {
            foreach (GameObject gate in gates)
            {
                animator = gate.GetComponent<Animator>();
                animator.enabled = true;
                animator.SetBool("gateOpen", false);

            }
            playerexit = true;
        }
        
    }

    public void areaCleared()
    {
        if (!cleared)
        {
            foreach (GameObject gate in gates)
            {
                animator = gate.GetComponent<Animator>();
                animator.SetBool("gateOpen", true);
                Destroy(gate, 0.5f);

            }
            cleared = true;
        }
        
    }

}
