using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    // ��� ��������
    public Vector3 rotationAxis = Vector3.up;
    // �������� ��������
    public float rotationSpeed = 10.0f;

    void Update()
    {
        // �������� ������� ������ ��������� ��� � ��������� ���������
        transform.Rotate(rotationAxis * rotationSpeed * Time.deltaTime);
    }
}
