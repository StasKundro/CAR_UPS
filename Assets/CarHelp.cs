using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarHelp : MonoBehaviour
{
    public Rigidbody carRigidbody; // Ссылка на Rigidbody автомобиля
    public float wobbleForce = 1000f; // Сила раскачивания
    public float wobbleDuration = 0.2f; // Длительность раскачивания
    public float cooldownTime = 2.0f; // Время задержки между нажатиями

    private float wobbleTimer = 0f;
    private float lastWobbleTime = -Mathf.Infinity; // Время последнего раскачивания

    private void Update()
    {
        if (Time.time - lastWobbleTime >= cooldownTime)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                // Начать раскачивание влево
                StartCoroutine(Wobble(-transform.right));
                lastWobbleTime = Time.time;
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                // Начать раскачивание вправо
                StartCoroutine(Wobble(transform.right));
                lastWobbleTime = Time.time;
            }
        }
    }

    private IEnumerator Wobble(Vector3 direction)
    {
        wobbleTimer = wobbleDuration;
        while (wobbleTimer > 0)
        {
            carRigidbody.AddForce(direction * wobbleForce * Time.deltaTime, ForceMode.Acceleration);
            wobbleTimer -= Time.deltaTime;
            yield return null;
        }
    }
}
