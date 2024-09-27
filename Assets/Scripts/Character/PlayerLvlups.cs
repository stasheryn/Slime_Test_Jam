using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Scriptable objects/Create PlayerLvlups", fileName = "PlayerLvlups SO")]
public class PlayerLvlups : ScriptableObject
{
    #region MyRegion

    //some cool comments

    #endregion

    // ne robe with diction :(
    [Header("Diction for Lvls")] 
    public Dictionary<int , int > lvl = new Dictionary<int , int >();
    // ne wydno((( try Odin[serializer]
    [Header("Diction for Lvls")] 
    [SerializeField] public int[] levelUp;
    
    //public int lvlUp, lvlUpAmount;
    
    [Header("Only GamePlay")]
    public bool stackable = true;
}
