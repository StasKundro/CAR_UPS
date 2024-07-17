using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    public Transform target; // ����, ������ ������� ��������� ������
    public float distance = 5.0f; // ���������� �� ����
    public float xSpeed = 120.0f; // �������� �������� �� ��� X
    public float ySpeed = 120.0f; // �������� �������� �� ��� Y

    public float yMinLimit = -20f; // ����������� ���� �� ��� Y
    public float yMaxLimit = 80f; // ������������ ���� �� ��� Y

    private float x = 0.0f; // ������� �������� ���� �� ��� X
    private float y = 0.0f; // ������� �������� ���� �� ��� Y

    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;

        // ������ ������ ����
        Cursor.lockState = CursorLockMode.Locked;
    }

    void LateUpdate()
    {
        if (target)
        {
            // �������� ���� �� ����
            x += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
            y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;

            // ������������ ���� �� ��� Y
            y = ClampAngle(y, yMinLimit, yMaxLimit);

            // ��������� ����� ������� � ���������� ������
            Quaternion rotation = Quaternion.Euler(y, x, 0);
            Vector3 position = rotation * new Vector3(0.0f, 0.0f, -distance) + target.position;

            // ��������� ����� ������� � ���������� ������
            transform.rotation = rotation;
            transform.position = position;
        }
    }

    // ����������� ����
    float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360F)
            angle += 360F;
        if (angle > 360F)
            angle -= 360F;
        return Mathf.Clamp(angle, min, max);
    }
}
