using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class traps : MonoBehaviour
{
    public Transform[] transforms;
    public Bossfire trap;
    public float nextspawn;
    public bool isStartBattle = false;

    void Update()
    {
       
            if (Time.time > nextspawn)
            {
                instantiateTraps();
                nextspawn = Time.time + 10f;
            }

        
    }

    public void instantiateTraps()
    {
        foreach(Transform trans in transforms)
        {
            Instantiate(trap, trans.position, Quaternion.identity);
        }
    }
}
