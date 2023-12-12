using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{

    public float initialSpeed = 5.0f; // ��������� �������� ��������
    public float spinTime = 2.0f; // �����, � ������� �������� ������� ����� ����������� �� ���������
    public float endPositionY; // Y-����������, ��� ���������� ������� ������ ����������� �����
    public float resetPositionY; // Y-����������, ���� ������ ������������ ��� ������ ������ �����
    private bool isSpinning; // ���� ��� ��������, ��������� �� �������
    private bool firstSpin = true;
    public SlotMachineController controller;
    

    //void Start()
    //{
    //    // ��������� �������� ��� ������
    //    StartSpinning();
    //}

    public void StartSpinning()
    {
        if (!isSpinning && firstSpin)
        {

            StartCoroutine(SpinReel());
            firstSpin = false;
        }
        else if (!firstSpin)
        {

            // �������� ����� � ������������ ���������
            controller.ResetReels();
            StartCoroutine(SpinReel());
            // ����� ������������� ��� ������� ��������
        }
        else
        { 
            StopAllCoroutines();
           
            // ��������, ����������� �������������� ������ ��� ������ ��������� ��������
            isSpinning = false;
            
        }
    }

    private IEnumerator SpinReel()
    {
        isSpinning = true;
        float currentSpeed = initialSpeed;
        float timeSpinning = 0.0f;

        // ������� ���������� �������� �� initialSpeed �� 0 �� ����� spinTime
        while (timeSpinning < spinTime)
        {
            // ���������� �������� �� ��������
            currentSpeed = Mathf.Lerp(initialSpeed, 0, timeSpinning / spinTime);
            transform.Translate(Vector3.down * currentSpeed * Time.deltaTime, Space.World);
            timeSpinning += Time.deltaTime;

            //// ��������, ������ �� ������� ������ �������
            //if (transform.position.y < endPositionY)
            //{
            //    // ����������� �������� ������� �����
            //    Vector3 newPosition = transform.position;
            //    newPosition.y = resetPositionY;
            //    transform.position = newPosition;
            //}

            yield return null;
        }

        // ����� ����������, ���������� �������
        isSpinning = false;
    }

    
}
