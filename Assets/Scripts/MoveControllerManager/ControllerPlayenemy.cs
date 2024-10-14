using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerPlayenemy : MonoBehaviour
{
    // which RB  I control
    // мб брати з ліста/масиву + мати посилання на самого Слайма щоб для зручності
    // мб якийсь Менеджер потрібен для цього ? .enabled
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _speed = 1f;
    
    
    private void Movement()
    {
        var dir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        //transform.Translate(dir * (_speed * Time.deltaTime));
        _rb.velocity = dir * _speed;
    }

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Movement();
    }

    public void SetGravOff()
    {
        _rb.useGravity = false;
    }

    public void SetGravOn()
    {
        _rb.useGravity = true;
    }
    // public void SetChildOf()
    // {
    //     
    // }
}
