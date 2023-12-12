using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{

    public float speed = 5.0f; // �������� �������� ��������
    public float endPositionY; // Y-����������, ��� ���������� ������� ������� ������������ �����
    public float resetPositionY; // Y-����������, ���� ������� ������������ ��� ������ ������ �����

    void Update()
    {
        // ����������� �������� ����
        transform.Translate(Vector3.down * speed * Time.deltaTime, Space.World);

        // ��������, ������ �� ������� ������ �������
        if (transform.position.y < endPositionY)
        {
            // ����������� �������� ������� ����� ��� ����������� ��������
            Vector3 newPosition = transform.position;
            newPosition.y = resetPositionY;
            transform.position = newPosition;
        }
    }
}
