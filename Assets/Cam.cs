using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    public Transform target; // Цель, вокруг которой вращается камера
    public float distance = 5.0f; // Расстояние от цели
    public float xSpeed = 120.0f; // Скорость вращения по оси X
    public float ySpeed = 120.0f; // Скорость вращения по оси Y

    public float yMinLimit = -20f; // Минимальный угол по оси Y
    public float yMaxLimit = 80f; // Максимальный угол по оси Y

    private float x = 0.0f; // Текущее значение угла по оси X
    private float y = 0.0f; // Текущее значение угла по оси Y

    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;

        // Скрыть курсор мыши
        Cursor.lockState = CursorLockMode.Locked;
    }

    void LateUpdate()
    {
        if (target)
        {
            // Получаем ввод от мыши
            x += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
            y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;

            // Ограничиваем угол по оси Y
            y = ClampAngle(y, yMinLimit, yMaxLimit);

            // Вычисляем новую позицию и ориентацию камеры
            Quaternion rotation = Quaternion.Euler(y, x, 0);
            Vector3 position = rotation * new Vector3(0.0f, 0.0f, -distance) + target.position;

            // Применяем новую позицию и ориентацию камеры
            transform.rotation = rotation;
            transform.position = position;
        }
    }

    // Ограничение угла
    float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360F)
            angle += 360F;
        if (angle > 360F)
            angle -= 360F;
        return Mathf.Clamp(angle, min, max);
    }
}
