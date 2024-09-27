using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int experience = 50;
    [SerializeField] private float damageValueToPlayer;
    [SerializeField] private float healthMax = 100f;
    [SerializeField] private float healthCurrent = 100f;
    //[SerializeField] private MoveController playerMoveController;
    [SerializeField] private CharacterStat playerStat;
    [SerializeField] private EnemyHealthbar hpBar;

    private void Start()
    {
        hpBar.SetMaxHealth(healthMax);
    }

    private void OnTriggerEnter(Collider other)
    {
        // мб чек на тег колайдера(tag:playerDamage)
        var damage = other.GetComponentInParent<CharacterStat>();
        healthCurrent -= damage.AttackDamage;
        UpdateHPBar();
        // мб чек на 0хп, щоб зручно видалити ГОбджект
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
