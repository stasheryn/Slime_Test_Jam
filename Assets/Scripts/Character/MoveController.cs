using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveController : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private CharacterStat charStat;
    [SerializeField] private bool canAttack = true;
    // хз нащо взагалі мати таку змінну?
    [SerializeField] private Collider _colliderToAttack;
    
    public void ChangeSpeed(float newSpeed)
    {
        _speed = newSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().TakeDamage(charStat);
        }
    }

    void Update()
    {
        // UNCOMMENT LATER
        //Movement();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space is presed");
            Attack();
        }
    }

    #region MovementAndAttackImplementation

    private void Movement()
    {
        // десь в мувмент де Y позиція = 0 є баг
        var dir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        // transform.Translate(dir * (_speed * Time.deltaTime));
        _rb.velocity = dir * _speed;
    }

    private void Attack()
    {
        // мб лишній чек
        if (canAttack)
        {
            StartCoroutine(AttackTime(charStat.AttackDamageInterval));
            // action attack
        }
    }

    private IEnumerator AttackTime(float timeToWait)
    {
        //
        canAttack = false;
        
        
        // візуально показує колайдер
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
        
        yield return new WaitForSeconds(0.2f);
        gameObject.transform.GetChild(0).gameObject.SetActive(false);

        
        yield return new WaitForSeconds(timeToWait);
        canAttack = true;
    }

    #endregion

    public void offControll()
    {
        enabled = false;
    }

    private void Start()
    {
        GameOver.gameOver += offControll;
    }
}