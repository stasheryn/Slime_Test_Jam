using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : EnemyState
{
    public float timer;
    private bool canAttack = true;

    public override void Enter()
    {
    }

    public override void Do()
    {
        if (canAttack)
        {
            Debug.Log("I attack player");
            // добавити затримку на атаку
            // коротина + в ній змінюється булка.КенАтак , і лише коли булка тру можна атакувати ...+ т ам десь вкл колайдер ворога на атаку дмдж
            StartCoroutine(AttackPlayerCd());
        }
    }

    /*public override void FixedDo()
    {
    }*/

    public override void Exit()
    {
    }

    IEnumerator AttackPlayerCd()
    {
        canAttack = false;
        timer = dataOfThisEnemy.attackDelay;
        yield return new WaitForSeconds(timer);


        canAttack = true;
    }
}