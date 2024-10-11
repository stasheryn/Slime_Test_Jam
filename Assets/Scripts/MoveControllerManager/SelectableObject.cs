using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectableObject : MonoBehaviour
{
    // зробити статік у іншому класі поле щоб брати глобально дані
    [SerializeField] private Transform playerDistance;
    private Renderer _renderer;
    private void Start()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void OnMouseEnter()
    {
        if (Vector3.Distance(transform.position, playerDistance.position) > 1f)
        {
            _renderer.material.color = Color.gray;
        }
        else
        {
            _renderer.material.color = Color.blue;
            // onClick {CONSUME} =>  List<>.Add
        }
    }

    private void OnMouseUp()
    {
        
        ManagerController.Instance.AddCurrentCharacter(this.GetComponent<ControllerPlayenemy>());
    }

    private void OnMouseExit()
    {
        _renderer.material.color = Color.white;
        
        // if (sometext)
        // {
        //     _renderer.material.color = Color.green;
        // }
    }
}
