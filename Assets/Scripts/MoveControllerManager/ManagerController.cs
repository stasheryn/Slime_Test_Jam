using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ManagerController : MonoBehaviour
{
    // вкл / викл скрипти на Обєктах
    [SerializeField] private ControllerPlayenemy characterCurrent;
    [SerializeField] private ControllerPlayenemy characterByDefault;
    [SerializeField] private ControllerPlayenemy characterTarget;
    private bool isSlimeControllSmbdy;
    private bool isCanGoGround;
    private bool isCdOnTakeControll;
    private PositionFollow playerFollowScript;
    
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

    private void Start()
    {
        playerFollowScript = characterByDefault.GetComponent<PositionFollow>();
    }
    private void Update()
    {
        ChangeBodyController();
    }
    public void ChangeBodyController()
    {
        // if (Input.GetKeyDown(KeyCode.E))
        // {
        //     // List Char 0
        //     for (int i = 0; i < possibleCharacters.Count; i++)
        //     {
        //         if (i != 0)
        //         {
        //             possibleCharacters[i].enabled = false;
        //         }
        //         else
        //         {
        //             possibleCharacters[i].enabled = true;
        //         }
        //     }
        // }
        //
        // if (Input.GetKeyDown(KeyCode.Q))
        // {
        //     // List Char 1
        //     for (int i = 0; i < possibleCharacters.Count; i++)
        //     {
        //         if (i != 1)
        //         {
        //             possibleCharacters[i].enabled = false;
        //         }
        //         else
        //         {
        //             possibleCharacters[i].enabled = true;
        //         }
        //     }
        // }
        
        // можна в окремий метод натискання клавіш винести?
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (!isSlimeControllSmbdy && !isCdOnTakeControll)
            {
                MoveSlimeToEnemyBody();
            }
            else
            {
                TryGetGround();
            }
        }
    }

    private void SwitchControll()
    {
        characterByDefault.enabled = !characterByDefault.enabled;
        characterCurrent.enabled = !characterCurrent.enabled;
    }

    public void AddCurrentCharacter(ControllerPlayenemy _characterCurrent)
    {
        characterCurrent = _characterCurrent;
    }

    public void AddTargetCharacter(ControllerPlayenemy _characterTarget)
    {
        characterTarget = _characterTarget;
    }

    public void TryGetGround()
    {
        if (isCanGoGround)
        {
            // cd na залізання на енемі
            StartCoroutine(IsCdOnTakeControllCor());
            
            // злізання? якось потім замінити цей магічний новий Вектор3
            characterByDefault.transform.DOMove(characterTarget.transform.position + new Vector3(2, 0, 2), 1f);
            // лишнє офання скрипта? чи ок? потім чекнути де його треба вкл щоб нічого не поламалось \\ п.с.все ок
            playerFollowScript.SetFollowObject(characterTarget, false);
            playerFollowScript.enabled = false;
            characterByDefault.SetGravOn();
            
            isCanGoGround = false;
            //
            isSlimeControllSmbdy = false;
            SwitchControll();
        }
    }

    public void MoveSlimeToEnemyBody()
    {
        if (characterTarget != null)
        {
            isSlimeControllSmbdy = true;

            //characterByDefault
            characterByDefault.transform.DOMove(characterTarget.transform.position, 1f)
                .OnComplete(() => FollowAferTween());
            // поки виконується твінер слайм не може злісти з ворога... наче
            SwitchControll();
        }
        else
        {
            Debug.Log(" U dont have enemy to hostage it");
        }
    }
    public void FollowAferTween()
    {
        playerFollowScript.enabled = true;
        // 
        playerFollowScript.SetFollowObject(characterTarget, true);
        characterByDefault.SetGravOff();
        isCanGoGround = true;
    }

    private IEnumerator IsCdOnTakeControllCor()
    {
        // coroutine
        isCdOnTakeControll = true;
        yield return new WaitForSeconds(3f);
        //isSlimeControllSmbdy = false;
        // bloody shit Upper)
        
        // coroutine
        isCdOnTakeControll = false;
    }
}