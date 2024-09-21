using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int experience;
    [SerializeField] private float damageValueToPlayer;
    [SerializeField] private float healthMax = 100f;
    [SerializeField] private float healthCurrent = 100f;
    [SerializeField] private MoveController playerMoveController;
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

    // mb реалізувати статік клас/метод десь на плеєрі і викликати через інші класи статік паблік метод
    public void DoDamageToPlayer()
    {
        Debug.Log(" damage done to player");
        playerMoveController.PlayerTakeDamage(damageValueToPlayer);
    }

    private void UpdateHPBar()
    {
        hpBar.SetCurrentHealth(healthCurrent);
    }

    public void AddReference(EnemyHealthbar hpBarLink)
    {
        hpBar = hpBarLink;
    }
    
}

/*
public interface IEnemyTakeDamage
{
    void TakeDamage();
}
*/
