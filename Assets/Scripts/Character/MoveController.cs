using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveController : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private CharacterStat charStat;
    [SerializeField]private bool canAttack = true;

    // Update is called once per frame
    void Update()
    {
        Movement();
        if (Input.GetKeyDown(KeyCode.Space) )
        {
            Debug.Log("Space is presed");
            Attack();
        }
    }

    private void Movement()
    {
        var dir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        //transform.Translate(dir * (_speed * Time.deltaTime));
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
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
        
        canAttack = false;
        yield return new WaitForSeconds(timeToWait);
        canAttack = true;
    }
}
