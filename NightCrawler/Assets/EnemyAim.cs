using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class EnemyAim : MonoBehaviour
{
    private Transform aimTransform;
    private Animator aimAnimator;
    public Transform target;

    void Start()
    {
         target = FindObjectOfType<Player>().transform;
    }
    private void Awake()
    {
        aimTransform = transform.Find("EnemyAim");
        aimAnimator = aimTransform.GetComponent<Animator>();
    }

    private void Update()
    {
        Aiming();
    }

    private void Aiming()
    {
        Vector3 aimDirection = (target.position - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        aimTransform.eulerAngles = new Vector3(0, 0, angle);
    }

}
