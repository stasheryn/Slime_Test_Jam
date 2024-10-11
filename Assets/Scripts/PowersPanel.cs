using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PowersPanel : MonoBehaviour
{
    [SerializeField] private CharacterStat playerStat;
    [SerializeField] private TextMeshProUGUI 
        _currentPointsCount,
        _powerPoits,
        _speedPoints,
        _defencePoints;

    [SerializeField] private Color 
        normal,
        powerUpped;
    [SerializeField] private int
        maxPoints,
        currentPoints,
        accesPoints,
        powerOpen,
        powerBlocked,
        speedOpen,
        speedBlocked,
        defenceOpen,
        defenceBlocked;


    // try generic  sttc void Swap<T>(ref T lhs, ref T rhs)
    public void GenericPlusPoints(ref TextMeshProUGUI texMpro, ref int blocked, ref int opened)
    {
        // OPENED -- найголовніше, темп варка
        // & - i , i
        // && - якщо лівий тру, то на правий пофіг
        if (currentPoints > 0)
        {
            opened++;
            currentPoints--;
        }
        
        // its updatePower
        GenericUpdate(ref texMpro, ref blocked, ref opened);
        //
        UpdateCurrentPoints();
    }
    
    public void GenericMinusPoints(ref TextMeshProUGUI texMpro, ref int blocked, ref int opened)
    {
        // OPENED -- найголовніше, темп варка
        // & - i , i
        // && - якщо лівий тру, то на правий пофіг
        
        if (opened > 0)
        {
            opened--;
            currentPoints++;
        }
        
        // its updatePower
        GenericUpdate(ref texMpro, ref blocked, ref opened);
        //
        UpdateCurrentPoints();
    }

    /// <summary>
    ///  Боже дай мі сил
    /// </summary>
    public void SpeedAddPoint()
    {
        GenericPlusPoints(ref _speedPoints,ref speedBlocked,ref speedOpen);
    }

    public void SpeedMinusPoint()
    {
        GenericMinusPoints(ref _speedPoints,ref speedBlocked,ref speedOpen);
    }
    
    public void DefenceAddPoint()
    {
        GenericPlusPoints(ref _defencePoints,ref defenceBlocked,ref defenceOpen);
    }

    public void DefenceMinusPoint()
    {
        GenericMinusPoints(ref _defencePoints,ref defenceBlocked,ref defenceOpen);
    }
    
    // logic for buttons add points

    public void AddPointToPower()
    {
        if (currentPoints > 0)
        {
            powerOpen++;
            currentPoints--;
        }

        UpdatePower();
        UpdateCurrentPoints();
    }

    public void MinusPointsToPower()
    {
        if (powerOpen > 0)
        {
            powerOpen--;
            currentPoints++;
        }
        UpdatePower();
        UpdateCurrentPoints();
    }

    /*
    public void SumPower()
    {
        powerBlocked += powerOpen;
        powerOpen = 0;
        //powerOpen -= powerOpen;
    } */

    public void UpdatePower()
    {
        // visual update points
        _powerPoits.text = (powerBlocked + powerOpen).ToString();
        if (powerOpen > 0)
        {
            _powerPoits.color = powerUpped;
        }
        else
        {
            _powerPoits.color = normal;
        }
    }

    public void GenericUpdate(ref TextMeshProUGUI texMpro, ref int blocked, ref int opened)
    {
        texMpro.text = (blocked + opened).ToString();
        if (opened > 0)
        {
            texMpro.color = powerUpped;
        }
        else
        {
            texMpro.color = normal;
        }
    }
    
    // generic ??

    public void UpdateCurrentPoints()
    {
        // Лише апдейт верхньої цифри, не треба в дженерік?
        _currentPointsCount.text = currentPoints.ToString();
    }


    private void Start()
    {
        // потім десь відписатись он дез етс...
        CharacterStat.onLvlup += PlayerLvlUp;
        //currentPoints = maxPoints;
        UpdateCurrentPoints();
    }
    
    // ACCEPT CHOSEN POWER UPs
    public void BlockPoints()
    {
        powerBlocked += powerOpen;
        speedBlocked += speedOpen;
        defenceBlocked += defenceOpen;

        //currentPoints = currentPoints - (powerOpen + speedOpen + defenceOpen);
        
        powerOpen = 0;
        speedOpen = 0;
        defenceOpen = 0;

        UpdatePower();
        // robe
        
        
        //generic color after accept blocking
        GenericUpdate(ref _speedPoints, ref speedBlocked, ref speedOpen);
        GenericUpdate(ref _defencePoints, ref defenceBlocked, ref defenceOpen);
        //
        UpdateCurrentPoints();
        // калбек в чарСтат щодо характеристик
        playerStat.ReceivePowerUps(powerBlocked, speedBlocked, defenceBlocked);
    }

    public void PlayerLvlUp()
    {
        currentPoints++;
        UpdateCurrentPoints();
    }
}