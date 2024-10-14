using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionFollow : MonoBehaviour
{
    // мб краще буде сет енейблед false ?
    [SerializeField] private bool isNeedToFollow;
    [SerializeField] private ControllerPlayenemy objToFollow;
    [SerializeField] private Vector3 offSetVector;

    public void SetFollowObject(ControllerPlayenemy objToFollowNew, bool active)
    {
        objToFollow = objToFollowNew;
        isNeedToFollow = active;
    }

    private void UpdatePosition()
    {
        if (isNeedToFollow)
        {
            transform.position = objToFollow.transform.position + offSetVector;
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePosition();
    }
}