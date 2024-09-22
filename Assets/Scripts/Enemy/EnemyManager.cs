using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private float circleDistanceFromPlayer;
    [SerializeField] private float circleDistanceFromPlayerMax;
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Vector3 _playerCoordinates;
    [SerializeField] private Transform player;
    [SerializeField] private EnemyHealthbar _hpBar;

    // parent for hold in CanvaWorldCoord object
    [SerializeField] private Transform parentWhereInstate;
    [SerializeField] private Transform parentHP;


    void Start()
    {
    }

    void Update()
    {
    }
    // ПЕРЕРОБИТИ!
    private Vector3 anotherCircleSpawn()
    {
        // проблема інстаюється енемі, і вже має бути інстаювання його хп бара,, як??
        Vector3 posToSpawn = new Vector3(2, 2, 0);
        // angle = RandInt(orFloat) * 
        float rand = Random.value;
        float x = Mathf.Cos(0.5f) * circleDistanceFromPlayer;
        float z = Mathf.Sin(0.5f) * circleDistanceFromPlayer;
        // transform треба брати у гравця
        Vector3 pos = transform.position + new Vector3(x, 0, z);
        return pos;
    }
    
    private Vector3 SpawnCircle()
    {
        // дивна реалізація, не впевнений що воно справді спавнить по кругу, краще спробувати замінити на метод з cos+sin
        float x, z;
        // X or Z axis
        bool sideToSpawn = Random.value > 0.5f;

        if (sideToSpawn)
        {
            x = Random.Range(circleDistanceFromPlayerMax, circleDistanceFromPlayerMax);
            z = Random.value > 0.5f
                ? Random.Range(-circleDistanceFromPlayerMax, -circleDistanceFromPlayer)
                : Random.Range(circleDistanceFromPlayer, circleDistanceFromPlayerMax);
        }
        else
        {
            x = Random.value > 0.5f
                ? Random.Range(-circleDistanceFromPlayerMax, -circleDistanceFromPlayer)
                : Random.Range(circleDistanceFromPlayer, circleDistanceFromPlayerMax);
            z = Random.Range(circleDistanceFromPlayerMax, circleDistanceFromPlayerMax);
        }
        // не факт що там круг, прямокутник?
        Vector3 randCirclePos = player.position + new Vector3(x, 0, z);
        return randCirclePos;
    }

    public void SpawnEnemy()
    {
        // переробити один з них
        var posToSpawn = SpawnCircle();

        // спитати якщо-що за спавн в ієрархії інспектора
        var enemyDoll = Instantiate(_enemy, posToSpawn, Quaternion.identity, parentWhereInstate);

        // створити метод який асайнить префаб у скрипт, викликати цей метод тут після інстаншуювання першого
        //Instantiate(_hpBar)
        //_enemy.hpBar=_hpBar;

        // виправити парента
        var enemyDollHP = Instantiate(_hpBar, posToSpawn, Quaternion.identity, parentHP);
        enemyDoll.AddReference(enemyDollHP);
        enemyDollHP.AddReferenceTrans(enemyDoll.transform);
        // test
    }
}