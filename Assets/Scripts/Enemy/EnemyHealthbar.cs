using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthbar : MonoBehaviour
{
    public Slider slider;
    [SerializeField] private Camera _camera;
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 offSetForTarget;
    //[SerializeField] private Vector3 summ;
    [SerializeField] private bool haveTarget;

    private void Update()
    {
        BarUpdatePosRot();
    }
    public void AddReferenceCamera()
    {
        _camera = Camera.main;
    }
    
    public void AddReferenceTrans(Transform targetOfHPBar)
    {
        AddReferenceCamera();
        _target = targetOfHPBar;
        haveTarget = true;
        //summ = _target.position + offSetForTarget;
    }
    private void BarUpdatePosRot()
    {
        // пересування полоски + поворот до гравця
        if (haveTarget)
        {
            transform.rotation = _camera.transform.rotation;
            transform.position = _target.position + offSetForTarget;
            //transform.position = summ;
        }
        
    }

    public void SetMaxHealth(float healthMax)
    {
        slider.maxValue = healthMax;
        slider.value = healthMax;
    }
    
    
    // рухає саме значення  слайдера
    public void SetCurrentHealth(float healthCurrent)
    {
        slider.value = healthCurrent;
    }
}
