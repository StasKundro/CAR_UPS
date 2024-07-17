using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Teleport : MonoBehaviour
{
    // Целевой Transform для телепортации
    public Transform targetTransform;
    // Время, необходимое для удержания кнопки
    public float holdTime = 3.0f;
    // Slider для отображения прогресса
    private Slider holdProgressSlider;
    private GameObject sl;

    private float holdTimer = 0.0f;
    private bool isHolding = false;

    private void Start()
    {
        sl = GameObject.FindGameObjectWithTag("Restart");
        holdProgressSlider = sl.GetComponent<Slider>();
    }

    void Update()
    {
        // Проверяем, удерживается ли клавиша R
        if (Input.GetKey(KeyCode.R))
        {
            sl.SetActive(true);
            // Увеличиваем таймер удержания
            holdTimer += Time.deltaTime;

            // Обновляем значение слайдера
            holdProgressSlider.value = holdTimer / holdTime;

            // Если удержание длится достаточно долго, телепортируем объект
            if (holdTimer >= holdTime)
            {
                transform.position = targetTransform.position;
                transform.rotation = targetTransform.rotation;
                // Сбрасываем таймер и флаг удержания
                holdTimer = 0.0f;
                isHolding = false;
                holdProgressSlider.value = 0;
            }
            else
            {
                // Устанавливаем флаг удержания
                isHolding = true;
            }
        }
        else
        {
            sl.SetActive(false);
            // Если клавиша отпущена, сбрасываем таймер и флаг удержания
            if (isHolding)
            {
                holdTimer = 0.0f;
                isHolding = false;
                holdProgressSlider.value = 0;
            }
        }
    }
}
