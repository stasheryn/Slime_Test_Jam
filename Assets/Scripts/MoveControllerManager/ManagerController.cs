using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerController : MonoBehaviour
{
    [SerializeField] private ControllerPlayenemy characterCurrent;
    [SerializeField] private ControllerPlayenemy characterByDefault;
    [SerializeField] private List<ControllerPlayenemy> possibleCharacters;
    
    
    public static ManagerController Instance { get; private set; }

    private void Awake() 
    { 
        // If there is an instance, and it's not me, delete myself.
    
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        } 
    }

    public void ChangeBodyController()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            // List Char 0
            for (int i = 0; i < possibleCharacters.Count; i++)
            {
                if (i != 0)
                {
                    possibleCharacters[i].enabled = false;
                }
                else
                {
                    possibleCharacters[i].enabled = true;
                }
            }
            
            // enemy catching
            
            DisableAgentEnemy();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            // List Char 1
            for (int i = 0; i < possibleCharacters.Count; i++)
            {
                if (i != 1)
                {
                    possibleCharacters[i].enabled = false;
                }
                else
                {
                    possibleCharacters[i].enabled = true;
                }
            }
            
            DisableAgentEnemy();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            characterByDefault.enabled = false;
            characterCurrent.enabled = true;
        }
    }

    public void DisableAgentEnemy()
    {
        
    }

    private void Update()
    {
        ChangeBodyController();
    }

    public void AddCurrentCharacter(ControllerPlayenemy _characterCurrent)
    {
        characterCurrent = _characterCurrent;
    }
}
