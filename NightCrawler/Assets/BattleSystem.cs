using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    [SerializeField] private Transform[] enemies;
    [SerializeField] private ColliderScript colliderScript;
    public EnemyAI[] enemytype;
    private bool start;
    public int enemyCount;
    public GameObject battleTrigger;
    public int random;


    void Awake()
    {
        start = false;
     
    }

    void Start()
    {
        colliderScript.OnPlayerEnterTrigger += ColliderScript_OnPlayerEnterTrigger;
        enemyCount = enemies.Length;
    }
    
    void Update()
    {
        if (enemyCount <= 0)
        {
            battleTrigger.GetComponent<ColliderScript>().areaCleared();
        }
    }

  
    private void ColliderScript_OnPlayerEnterTrigger(object sender,System.EventArgs e)
    {
        if (!start)
        {
           
            StartBattle();
            colliderScript.OnPlayerEnterTrigger -= ColliderScript_OnPlayerEnterTrigger;
        }
 
    }
    private void StartBattle()
    {

        foreach(Transform enemy in enemies)
        {
            random = Random.Range(0, enemytype.Length);
            EnemyAI enemobject = Instantiate(enemytype[random], enemy.position, Quaternion.identity) as EnemyAI;
            enemobject.home = enemy;
            enemobject.isbattlestart = true;
            enemobject.battleSystem = GetComponent<BattleSystem>();
        }
        start = true;
    }
}
