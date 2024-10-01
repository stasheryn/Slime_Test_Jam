using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class EnemyState : MonoBehaviour
{
    // в обєкті який буде юзати треба обявити його дітей(абстр класу)(які будуть юзатись)
    public bool isComplete { get; protected set; }
    // най буде поки зверху

    
    
    protected CharacterStat player;

    // мб ріджід_боді 3д
    protected Rigidbody2D rb;

    // чи потрібен аніматор?
    protected Animator animator;
    protected NavMeshAgent agent;
    protected Enemy dataOfThisEnemy;

    public virtual void Enter()
    {
    }

    public virtual void Do()
    {
    }

    public virtual void FixedDo()
    {
    }

    public virtual void Exit()
    {
    }

    public void Setup(Animator _animator, Rigidbody2D _rb, CharacterStat _player)
    {
        // добавити всі необхідні штуки сюди через параметри методів + ці штуки/посилання повинні бути на обєкті
        // також може бути сам обєкт this
        animator = _animator;
        rb = _rb;
        player = _player;
    }

    public void SetupNavagent(NavMeshAgent _agent, CharacterStat _player, Enemy _dataOfThisEnemy)
    {
        agent = _agent;
        player = _player;
        dataOfThisEnemy = _dataOfThisEnemy;
    }
}