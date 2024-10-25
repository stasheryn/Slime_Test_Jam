using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerPlayenemy : MonoBehaviour, IChangerColliderTag
{
    // which RB  I control
    // мб брати з ліста/масиву + мати посилання на самого Слайма щоб для зручності
    // мб якийсь Менеджер потрібен для цього ? .enabled
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _speed = 1f;
    
    // colliders to change their TAGs
    [SerializeField] private Collider body;
    [SerializeField] private Collider attack;
    
    
    public void Movement(Vector2 withoutY)
    {
        //var dir = new Vector3(Input.GetAxis("Horizontal"), _rb.velocity.y, Input.GetAxis("Vertical"));
        var dir = new Vector3(withoutY.x, _rb.velocity.y, withoutY.y);
        //transform.Translate(dir * (_speed * Time.deltaTime));
        _rb.velocity = dir * _speed;
    }

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        //Movement();
    }

    public void SetGravOff()
    {
        _rb.useGravity = false;
    }

    public void SetGravOn()
    {
        _rb.useGravity = true;
    }
    
    // coliders tag change
    public void AmEnemyNow()
    {
        // if (body != null && attack != null)
        // {
        //     body.tag = "Enemy";
        //     attack.tag = "Enemy";
        // }
        if (body != null && attack != null)
        {
            body.tag = "Enemy";
            attack.tag = "Enemy";
        }
    }

    public void AmPlayerNow()
    {
        // if (body != null && attack != null)
        // {
        //     Debug.Log("changed to player");
        //     body.tag = "Player";
        //     attack.tag = "Player";
        // }
        if (body != null && attack != null)
        {
            Debug.Log("changed to player");
            body.tag = "Player";
            attack.tag = "Player";
        }
    }
}
