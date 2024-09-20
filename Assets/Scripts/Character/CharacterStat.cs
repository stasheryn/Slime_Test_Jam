using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStat : MonoBehaviour
{
    [SerializeField] private float healthMax = 50f;
    [SerializeField] private float healthCurrent;
    [SerializeField] private float attackDamage; //{ get; set; }
    public float AttackDamage
    {
        get { return attackDamage; }
        set { attackDamage = value; }
    }

    [SerializeField] private float attackDamageInterval;
    public float AttackDamageInterval
    {
        get { return attackDamageInterval; }
        set { attackDamageInterval = value; }
    }

    private void Start()
    {
        healthCurrent = healthMax;
        // update ui if need

        //attackDamageInterval = 0.3f;
    }

    public void CharacterTakeDamage(float damageValue)
    {
        healthCurrent -= damageValue;
    }
}