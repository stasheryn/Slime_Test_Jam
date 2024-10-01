using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int experience = 50;
    [SerializeField] private float damageValueToPlayer;
    public float attackDelay;
    [SerializeField] private float healthMax = 100f;

    [SerializeField] private float healthCurrent = 100f;

    //[SerializeField] private MoveController playerMoveController;
    [SerializeField] private CharacterStat playerStat;

    [SerializeField] private EnemyHealthbar hpBar;

    // navMesh agent 
    private NavMeshAgent agent;

    // state
    public AttackState enemyAttackState;

    public ChaseState enemyChaseState;

    // abstr state?
    private EnemyState enemyState;


    private void Start()
    {
        hpBar.SetMaxHealth(healthMax);
        // setup for States?
        agent = gameObject.GetComponentInParent<NavMeshAgent>();
        enemyAttackState.SetupNavagent(agent, playerStat, this);
        enemyChaseState.SetupNavagent(agent, playerStat, this);

        enemyState = enemyChaseState;
    }

    private void Update()
    {
        if (agent.isStopped)
        {
            Debug.Log("State is complete . Going to choose new state");
            SelectState();
        }

        enemyState.Do();
    }

    // select enemy state method
    private void SelectState()
    {
        if ((playerStat.transform.position - transform.position).magnitude >= agent.stoppingDistance + 0.4f)
        {
            enemyState = enemyChaseState;
        }
        else
        {
            enemyState = enemyAttackState;
        }
    }

    /*private void OnTriggerEnter(Collider other)
    {
        // мб чек на тег колайдера(tag:playerDamage)
        var damage = other.GetComponentInParent<CharacterStat>();
        healthCurrent -= damage.AttackDamage;
        UpdateHPBar();
        // мб чек на 0хп, щоб зручно видалити ГОбджект
    }*/

    public void TakeDamage(CharacterStat player)
    {
        healthCurrent -= player.AttackDamage;
        UpdateHPBar();
    }


    private void UpdateHPBar()
    {
        hpBar.SetCurrentHealth(healthCurrent);
    }


    public void DoDamageToPlayer()
    {
        Debug.Log(" damage done to player");
        playerStat.PlayerTakeDamage(damageValueToPlayer);
    }

    public void GiveExpToPlayer()
    {
        playerStat.AddExpFromEnemyDeath(experience);
    }


    public void AddHpbarReference(EnemyHealthbar hpBarLink)
    {
        hpBar = hpBarLink;
    }

    public void AddCharacterReference(CharacterStat playerChar)
    {
        playerStat = playerChar;
    }
}

/*
public interface IEnemyTakeDamage
{
    void TakeDamage();
}
*/