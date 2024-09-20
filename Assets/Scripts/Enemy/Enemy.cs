using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float healthEnemy = 100f;
    private void OnTriggerEnter(Collider other)
    {
        var damage = other.GetComponentInParent<CharacterStat>();
        healthEnemy -= damage.AttackDamage;
    }
}

/*
public interface IEnemyTakeDamage
{
    void TakeDamage();
}
*/
