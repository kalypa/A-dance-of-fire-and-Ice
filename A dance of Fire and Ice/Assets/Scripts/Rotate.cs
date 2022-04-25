using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField]
    private Transform Ice;
    [SerializeField]
    private Transform Fire;
    [SerializeField]
    private float rotateDistance = 1.5f;
    [SerializeField]
    private float rotateSpd = 1.5f;

    [SerializeField]
    private float angle = 0f; //아이스가 파이어 바라보는 각도

    [SerializeField]
    private float fireRotate = 0f;
    [SerializeField]
    private float iceRotate = 0f;
    [SerializeField]
    private float rotating;
    private Transform rotateBall;
    private Transform stopBall;
    private bool isFireMove = true; //파이어가 회전하고 있다
    void Update()
    {
        RotateMove();
        AngleSet();
        if(Input.GetMouseButtonDown(0))
        {
            isFireMove = !isFireMove;
            //움직여야하는 공의 rotate를 변경하다
            Vector2 ballAngle = stopBall.position - rotateBall.position;
            ballAngle = ballAngle.normalized;
        }
    }

    void RotateMove()
    {
        Vector2 resultPos = Vector2.zero;
        Transform rotateTrm = null;
        if (isFireMove)
        {
            //파이어가 움직일 때
            rotateTrm = Fire;
            resultPos = Ice.position;
            fireRotate += Time.deltaTime;
            resultPos.y -= Mathf.Sin(fireRotate * rotateSpd) * rotateDistance;
            resultPos.x += Mathf.Cos(fireRotate * rotateSpd) * rotateDistance;
            rotateBall = Fire;
            stopBall = Ice;
            rotating = fireRotate;
        }
        else
        {
            //아이스가 움직일 때 
            rotateTrm = Ice;
            resultPos = Fire.position;
            iceRotate += Time.deltaTime;
            resultPos.y -= Mathf.Sin(iceRotate * rotateSpd) * rotateDistance;
            resultPos.x += Mathf.Cos(iceRotate * rotateSpd) * rotateDistance;
            rotateBall = Ice;
            stopBall = Fire;
            rotating = iceRotate;
        }

        //연산이 끝난 후의 위치를 적용시킨다.
        rotateTrm.position = resultPos;
    }

    void AngleSet()
    {
        Vector2 angleVec = stopBall.position - rotateBall.position;
        angleVec = angleVec.normalized;
        angle = Mathf.Atan2(angleVec.y, angleVec.x) * Mathf.Rad2Deg;
        
    }
}
