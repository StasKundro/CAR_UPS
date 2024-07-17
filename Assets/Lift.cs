using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lift : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform pointA; // Первая точка
    public Transform pointB; // Вторая точка
    public float speed = 2.0f; // Скорость движения лифта
    public float waitTime = 10.0f; // Время ожидания в каждой точке

    private IEnumerator Start()
    {
        while (true)
        {
            // Движение от точки A к точке B
            yield return StartCoroutine(MoveToPoint(pointB.position));
            // Ожидание в точке B
            yield return new WaitForSeconds(waitTime);
            // Движение от точки B к точке A
            yield return StartCoroutine(MoveToPoint(pointA.position));
            // Ожидание в точке A
            yield return new WaitForSeconds(waitTime);
        }
    }

    private IEnumerator MoveToPoint(Vector3 target)
    {
        while (Vector3.Distance(transform.position, target) > 0.01f)
        {
            // Плавное движение к целевой точке
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
            yield return null;
        }
        // Обеспечивает точное достижение цели
        transform.position = target;
    }
}
