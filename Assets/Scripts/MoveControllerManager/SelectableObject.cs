using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectableObject : MonoBehaviour
{
    // зробити статік у іншому класі поле щоб брати глобально дані
    [SerializeField] private Transform playerDistance;
    private Renderer _renderer;
    
    // [serField] private PrefabButtonHelper buttonHelper

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
        }
    }

    private void OnMouseUp()
    {
        // при нажиманні на цей обж(req obj to have this script)
        // добавити сюди префаб підказки(юі) і спавнити в ворлдКанвас + (мб зробити пул обджект 5-10шт)

        ManagerController.Instance.AddTargetCharacter(this.GetComponent<ControllerPlayenemy>());
        // колір можна брати з якогось статік класу через Instance
        _renderer.material.color = Color.yellow;
    }

    private void OnMouseExit()
    {
        _renderer.material.color = Color.white;
    }
}