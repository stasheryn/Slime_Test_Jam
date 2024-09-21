using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private float circleDistanceFromPlayer;
    [SerializeField] private float circleDistanceFromPlayerMax;
    [SerializeField] private Enemy _enemy;

    [SerializeField] private EnemyHealthbar _hpBar;

    // parent for hold in CanvaWorldCoord object
    [SerializeField] private Transform parentWhereInstate;


    void Start()
    {
    }

    void Update()
    {
    }

    public void SpawnEnemy()
    {
        // проблема інстаюється енемі, і вже має бути інстаювання його хп бара,, як??
        Vector3 posToSpawn = new Vector3(2, 2, 0);
        // angle = RandInt(orFloat) * 
        float rand = Random.value;
        float x = Mathf.Cos(0.5f) * circleDistanceFromPlayer;
        float z = Mathf.Sin(0.5f) * circleDistanceFromPlayer;
        // transform треба брати у гравця
        Vector3 pos = transform.position + new Vector3(x, 0, z);

        // спитати якщо-що за спавн в ієрархії інспектора
        var enemyDoll = Instantiate(_enemy, pos, Quaternion.identity, parentWhereInstate);
        
        // створити метод який асайнить префаб у скрипт, викликати цей метод тут після інстаншуювання першого
        //Instantiate(_hpBar)
        //_enemy.hpBar=_hpBar;
        
        // виправити парента
        var enemyDollHP = Instantiate(_hpBar, pos, Quaternion.identity, parentWhereInstate);
        enemyDoll.AddReference(enemyDollHP);
        // test
    }
}