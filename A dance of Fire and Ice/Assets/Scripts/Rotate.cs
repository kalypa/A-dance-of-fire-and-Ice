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

    private Transform rotateBall;
    private Transform stopBall;
    private bool isFireMove = true; //파이어가 회전하고 있다

	private void Start()
    {
        stopBall = Ice;
        rotateBall = Fire;
    }

	void Update()
    {
        RotateMove();
        if(Input.GetMouseButtonDown(0))
        {
            //움직여야하는 공의 각도를 반대 방향으로 바꾼다
            angle -= Mathf.PI;

            isFireMove = !isFireMove;

			if (isFireMove)
			{
				stopBall = Ice;
				rotateBall = Fire;
			}
			else
			{
				stopBall = Fire;
				rotateBall = Ice;
			}
		}
    }

    void RotateMove()
    {
        Vector2 resultPos = Vector2.zero;
        resultPos = stopBall.position;
        angle += Time.deltaTime * rotateSpd;
        resultPos.y -= Mathf.Sin(angle) * rotateDistance;
        resultPos.x += Mathf.Cos(angle) * rotateDistance;

        //연산이 끝난 후의 위치를 적용시킨다.
        rotateBall.position = resultPos;
    }
}
