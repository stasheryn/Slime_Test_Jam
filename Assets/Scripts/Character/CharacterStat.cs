using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CharacterStat : MonoBehaviour
{
    [SerializeField] private float healthMax = 50f;

    public float HealthMax
    {
        get { return healthMax; }
        set { healthMax = value; }
    }

    [SerializeField] private float healthCurrent;

    public float HealthCurrent
    {
        get { return healthCurrent; }
        set { healthCurrent = value; }
    }

    [SerializeField] private float attackDamage; //{ get; set; }

    public float AttackDamage
    {
        get { return attackDamage; }
        set { attackDamage = value; }
    }

    [SerializeField] private float attackDamageAmplifier;

    [SerializeField] private float attackDamageInterval;

    public float AttackDamageInterval
    {
        get { return attackDamageInterval; }
        set { attackDamageInterval = value; }
    }
    [Header("Speed after refactor AND MVController")]
    [SerializeField] private MoveController playerController;
    [SerializeField] private float speed;
    [SerializeField] private float speedAmplifier;
    [SerializeField] private float defence;
    [SerializeField] private float defenceAmplifier;
    #region ExpImplement

    [Header("Lvl data and obj")] [SerializeField]
    private PlayerExpbar expBar;

    public delegate void PlayerLvlup();

    public static PlayerLvlup onLvlup;

    //контейнер зі значеннями до наступн рівня, ex: int[0] -> from_0 to_1 Lvl {110}
    [SerializeField] private PlayerLvlups playerLvlSys;
    [SerializeField] private int playerCurrentLvl;
    [SerializeField] private int expCurrent;
    [SerializeField] private int expToNextLvl;

    // викликатиметься у енемі після/під час смерті
    public void AddExpFromEnemyDeath(int exp)
    {
        // LvlUp + 0 Bar
        if (expCurrent + exp >= expToNextLvl)
        {
            playerCurrentLvl++;
            onLvlup();
            // мб можна без темпВар і в один рядок написати
            int tempVar = expCurrent + exp;
            expCurrent = tempVar - expToNextLvl;
            // change max amount to next lvl
            ExpToNextLevel();
            // update UI
            expBar.UpdateMaxExp(expToNextLvl, expCurrent);
        }
        else
        {
            expCurrent += exp;
            expBar.UpdateExp(expCurrent);
            //expBar.AddExp(exp);
        }
    }

    public void ExpToNextLevel()
    {
        expToNextLvl = playerLvlSys.levelUp[playerCurrentLvl];
    }

    private void XPBarStartUpdate()
    {
        playerCurrentLvl = 0;
        ExpToNextLevel();
        expBar.UpdateMaxExp(expToNextLvl, expCurrent);
    }

    #endregion

    #region PowersPanel

    public void CallToMvController()
    {
        playerController.ChangeSpeed(speed+speedAmplifier);
    }
    public void ReceivePowerUps(int powerAmp, int speedAmp, int defenceAmp)
    {
        attackDamageAmplifier = powerAmp;
        speedAmplifier = speedAmp;
        defenceAmplifier = defenceAmp;
        //
        CallToMvController();
    }

    #endregion

    #region HPBar_And_TakeDamage_Implementation

    [Header("HPBar")]
    // hp bar ref
    [SerializeField]
    private PlayerHealthbar hpBar;

    private void UpdateHPBar()
    {
        hpBar.SetCurrentHealth(healthCurrent);
    }

    public void PlayerTakeDamage(float damage)
    {
        healthCurrent -= damage;
        UpdateHPBar();
        if (healthCurrent <= 0)
        {
            GameOver.gameOver();
        }
    }

    #endregion

    private void Start()
    {
        healthCurrent = healthMax;
        // set hpBar to playerHP
        hpBar.SetMaxHealth(healthMax);
        // update UI xpBar ?
        XPBarStartUpdate();

        //attackDamageInterval = 0.3f;
    }
}