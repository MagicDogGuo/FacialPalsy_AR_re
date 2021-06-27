using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    public GameObject EnemyPrefab;                                 //The column game object.
    public float EnemyMin = -50f;                                   //Minimum y value of the column position.
    public float EnemyMax = 50f;                                  //Maximum y value of the column position.

    public float DestoryDisMin = 0;
    public float DestoryDisMax = 100;

    Vector2 initialObjectPoolPosition;

    GameObject m_enemy;

    float enemyOriDestorySpaceX = -300;
    float enemyDestorySpaceX = 0;


    void Start()
    {
        initialObjectPoolPosition = new Vector2(100, 150);
    }


    //This spawns columns as long as the game is not over.
    void Update()
    {
        if ( m_enemy == null)//!MainGameManager.Instance.BirdisDead &&
        {
            float spawnYPosition = Random.Range(EnemyMin, EnemyMax);

            Vector2 spawEnemyPos = initialObjectPoolPosition + new Vector2(initialObjectPoolPosition.x, spawnYPosition);

            m_enemy = Instantiate(EnemyPrefab, spawEnemyPos,Quaternion.identity);
            m_enemy.transform.parent = this.transform;
            //隨機刪除距離
            float destoryXPosition = Random.Range(DestoryDisMin, DestoryDisMax);
            enemyDestorySpaceX = enemyOriDestorySpaceX - destoryXPosition;

            //Debug.Log("destoryXPosition"+ destoryXPosition+"  "+enemyDestorySpaceX);

        }

        if (m_enemy.transform.position.x <= enemyDestorySpaceX)
        {
            Destroy(m_enemy);
        }
    }
}
