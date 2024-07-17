using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    // Ось вращения
    public Vector3 rotationAxis = Vector3.up;
    // Скорость вращения
    public float rotationSpeed = 10.0f;

    void Update()
    {
        // Вращение объекта вокруг указанной оси с указанной скоростью
        transform.Rotate(rotationAxis * rotationSpeed * Time.deltaTime);
    }
}
