using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : EnemyState
{
    public override void Enter()
    {
    }

    public override void Do()
    {
        Debug.Log("Chasing player");
        agent.SetDestination(player.transform.position);
        if ((player.transform.position - transform.position).magnitude >= agent.stoppingDistance + 0.4f)
        {
            agent.isStopped = false;
        }
        else agent.isStopped = true;
    }

    /*public override void FixedDo()
    {
    }*/

    public override void Exit()
    {
    }
}