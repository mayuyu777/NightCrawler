using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public GameObject text;
    void Start()
    {
        StartCoroutine(disableLevel());
    }
    
    public IEnumerator disableLevel()
    {
        yield return new WaitForSeconds(5);
        text.SetActive(false);
    }
}
