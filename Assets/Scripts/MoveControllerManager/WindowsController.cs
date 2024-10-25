using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowsController : MonoBehaviour
{
    [SerializeField]private ControllerPlayenemy characterForControl;
    
    // Start is called before the first frame update
    void Start()
    {
        //characterForControl = ManagerController.Instance.GiveRefForControll();
    }

    // Update is called once per frame
    void Update()
    {
        if (characterForControl != null)
        {
            Moving();
        }
    }

    private void Moving()
    {
        //Vector2 inputKeyboard = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        characterForControl.Movement(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));
    }

    public void GetPersonToControl(ControllerPlayenemy player)
    {
        characterForControl = player;
    }
}
