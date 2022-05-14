using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class cameraScript : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private CharacterScript cS;
    [SerializeField] private Vector3 offset;
    private float lerpValue = 1;

    void LateUpdate()
    {
        if (cS.isFinish == false)
        {
            Vector3 desPos = target.position + offset;
            transform.position = Vector3.Lerp(transform.position, desPos, lerpValue);
        }

        if (cS.isFinish == true)
        {
            if (cS.isPaint == true)
            {
                transform.DOMove(new Vector3(0, 3, 125), 3);
                transform.DORotateQuaternion(Quaternion.Euler(-6, 0, 0), 3);
            }

        }

    }
}
