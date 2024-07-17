using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Teleport : MonoBehaviour
{
    // ������� Transform ��� ������������
    public Transform targetTransform;
    // �����, ����������� ��� ��������� ������
    public float holdTime = 3.0f;
    // Slider ��� ����������� ���������
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
        // ���������, ������������ �� ������� R
        if (Input.GetKey(KeyCode.R))
        {
            sl.SetActive(true);
            // ����������� ������ ���������
            holdTimer += Time.deltaTime;

            // ��������� �������� ��������
            holdProgressSlider.value = holdTimer / holdTime;

            // ���� ��������� ������ ���������� �����, ������������� ������
            if (holdTimer >= holdTime)
            {
                transform.position = targetTransform.position;
                transform.rotation = targetTransform.rotation;
                // ���������� ������ � ���� ���������
                holdTimer = 0.0f;
                isHolding = false;
                holdProgressSlider.value = 0;
            }
            else
            {
                // ������������� ���� ���������
                isHolding = true;
            }
        }
        else
        {
            sl.SetActive(false);
            // ���� ������� ��������, ���������� ������ � ���� ���������
            if (isHolding)
            {
                holdTimer = 0.0f;
                isHolding = false;
                holdProgressSlider.value = 0;
            }
        }
    }
}
