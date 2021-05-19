using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateScript : MonoBehaviour
{
    // Start is called before the first frame update

   public void pauseAnimation()
    {
        Animator animator = GetComponent<Animator>();
        animator.enabled = false;
    }
}
