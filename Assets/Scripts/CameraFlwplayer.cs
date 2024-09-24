using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFlwplayer : MonoBehaviour
{
    [SerializeField] private Vector3 _playerOffset;//мб забрати серіалайз
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private float smothTime;
    private Vector3 currentVelocity = Vector3.zero;

    private void Awake()
    {
        _playerOffset = transform.position - _playerTransform.position;
    }

    private void LateUpdate()
    {
        Vector3 targetPosition = _playerTransform.position + _playerOffset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref currentVelocity, smothTime);
    }
}