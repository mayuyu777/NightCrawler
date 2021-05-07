using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

    public class PlayerWeaponAim : MonoBehaviour
    {
        private Transform aimTransform;
        private Animator aimAnimator;

        private void Awake()
        {
            aimTransform = transform.Find("Aim");
             aimAnimator = aimTransform.GetComponent<Animator>();
        }

        private void Update()
        {
            Aiming();
        }

        private void Aiming()
        {
            Vector3 mousePosition = UtilsClass.GetMouseWorldPosition();

            Vector3 aimDirection = (mousePosition - transform.position).normalized;
            float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
            aimTransform.eulerAngles = new Vector3(0, 0, angle);
        }

        private void WeaponAttack()
        {
            if (Input.GetMouseButtonDown(0))
            {
               
            }
        }


    }
