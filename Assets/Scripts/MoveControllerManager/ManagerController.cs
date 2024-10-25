using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ManagerController : MonoBehaviour
{
    // вкл / викл скрипти на Обєктах
    
    [SerializeField] private ControllerPlayenemy characterByDefault;
    [SerializeField] private ControllerPlayenemy characterTarget;
    // 25.10.2024 мб добавити треба 3й
    [SerializeField] private ControllerPlayenemy characterForControl;
    [SerializeField] private bool controlDefault = true;
    //
    [SerializeField] private WindowsController controller;
    // 25.10.2024 мб добавити треба 3й
    private bool isSlimeControllSmbdy;
    private bool isCanGoGround;
    private bool isCdOnTakeControll;
    private bool isActiveHostageEmnemy;
    private PositionFollow playerFollowScript;

    // public ControllerPlayenemy GiveRefForControll()
    // {
    //     return characterForControl;
    // }
    
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
        // 25.10.2024
        characterForControl = characterByDefault;
        controller.GetPersonToControl(characterForControl);
    }
    private void Update()
    {
        ChangeBodyController();
    }
    public void ChangeBodyController()
    {
        // можна в окремий метод натискання клавіш винести?
        // можна винести в окремий паблік метод який буде викликати ІнпутКлас (андроїд / ПК)
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (!isSlimeControllSmbdy && !isCdOnTakeControll)
            {
                // баг з керуванням
                isActiveHostageEmnemy = true;
                MoveSlimeToEnemyBody();
                // addExtraHPBar;
            }
            else
            {
                TryGetGround();
                // removeExtraHPBar;
            }
        }
    }

    private void SwitchControll()
    {
        // characterByDefault.enabled = !characterByDefault.enabled;
        // characterTarget.enabled = !characterTarget.enabled;
        // 25.10.2024
        if (controlDefault)
        {
            characterForControl = characterTarget;
            // зміна тегів для отримання дмдж
            characterTarget.AmPlayerNow();
            characterByDefault.AmEnemyNow();
        }
        else
        {
            characterForControl = characterByDefault;
            characterTarget.AmEnemyNow();
            characterByDefault.AmPlayerNow();
        }
        controller.GetPersonToControl(characterForControl);
        controlDefault = !controlDefault;
    }
    

    public void AddTargetCharacter(ControllerPlayenemy _characterTarget)
    {
        // метод вище можна видалити + запхати сюди іфку яка працює з початку, на ворогу ніт, після злізання працює
        
        if (!isActiveHostageEmnemy)
        {
            characterTarget = _characterTarget;
        }
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
            // 25.10.2024
            characterByDefault.AmPlayerNow();
            characterTarget.AmEnemyNow();
            //
            isActiveHostageEmnemy = false;
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
            // 24.10
            isActiveHostageEmnemy = false;
        }
    }
    public void FollowAferTween()
    {
        playerFollowScript.enabled = true;
        // 
        playerFollowScript.SetFollowObject(characterTarget, true);
        characterByDefault.SetGravOff();
        isCanGoGround = true;
        
        // 25.10.2024
        // видалити потім /змінити ці теги знизу
        characterByDefault.AmEnemyNow();
        characterTarget.AmPlayerNow();
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

    public void RemoveExtraHPBar()
    {
        
        // add CallBack to HPBar.cs ? на зміну слайдера+розміру+вкл\викл дод хп
    }
    public void AddExtraHPBar()
    {
        
        // add CallBack to HPBar.cs ? на зміну слайдера+розміру+вкл\викл дод хп
    }
    
}