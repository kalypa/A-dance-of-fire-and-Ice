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
    private float angle = 0f; //���̽��� ���̾� �ٶ󺸴� ����

    [SerializeField]
    private float fireRotate = 0f;
    [SerializeField]
    private float iceRotate = 0f;
    [SerializeField]
    private float rotating;
    private Transform rotateBall;
    private Transform stopBall;
    private bool isFireMove = true; //���̾ ȸ���ϰ� �ִ�
    void Update()
    {
        RotateMove();
        AngleSet();
        if(Input.GetMouseButtonDown(0))
        {
            isFireMove = !isFireMove;
            //���������ϴ� ���� rotate�� �����ϴ�
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
            //���̾ ������ ��
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
            //���̽��� ������ �� 
            rotateTrm = Ice;
            resultPos = Fire.position;
            iceRotate += Time.deltaTime;
            resultPos.y -= Mathf.Sin(iceRotate * rotateSpd) * rotateDistance;
            resultPos.x += Mathf.Cos(iceRotate * rotateSpd) * rotateDistance;
            rotateBall = Ice;
            stopBall = Fire;
            rotating = iceRotate;
        }

        //������ ���� ���� ��ġ�� �����Ų��.
        rotateTrm.position = resultPos;
    }

    void AngleSet()
    {
        Vector2 angleVec = stopBall.position - rotateBall.position;
        angleVec = angleVec.normalized;
        angle = Mathf.Atan2(angleVec.y, angleVec.x) * Mathf.Rad2Deg;
        
    }
}
