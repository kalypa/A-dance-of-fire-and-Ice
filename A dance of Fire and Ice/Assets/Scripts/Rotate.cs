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

    private Transform rotateBall;
    private Transform stopBall;
    private bool isFireMove = true; //���̾ ȸ���ϰ� �ִ�

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
            //���������ϴ� ���� ������ �ݴ� �������� �ٲ۴�
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

        //������ ���� ���� ��ġ�� �����Ų��.
        rotateBall.position = resultPos;
    }
}
