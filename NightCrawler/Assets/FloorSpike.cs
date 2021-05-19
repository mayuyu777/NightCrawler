using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorSpike : MonoBehaviour
{
    public void pauseAnim()
    {
        GetComponent<Animator>().enabled = false;
    }
}
