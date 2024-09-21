using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float damageValueToPlayer;
    [SerializeField] private float healthEnemy = 100f;
    [SerializeField] private MoveController playerMoveController;
    private void OnTriggerEnter(Collider other)
    {
        var damage = other.GetComponentInParent<CharacterStat>();
        healthEnemy -= damage.AttackDamage;
    }

    // mb реалізувати статік клас/метод десь на плеєрі і викликати через інші класи статік паблік метод
    public void DoDamageToPlayer()
    {
        Debug.Log(" damage done to player");
        playerMoveController.PlayerTakeDamage(damageValueToPlayer);
    }
}

/*
public interface IEnemyTakeDamage
{
    void TakeDamage();
}
*/
