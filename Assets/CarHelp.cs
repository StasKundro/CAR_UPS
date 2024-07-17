using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarHelp : MonoBehaviour
{
    public Rigidbody carRigidbody; // ������ �� Rigidbody ����������
    public float wobbleForce = 1000f; // ���� ������������
    public float wobbleDuration = 0.2f; // ������������ ������������
    public float cooldownTime = 2.0f; // ����� �������� ����� ���������

    private float wobbleTimer = 0f;
    private float lastWobbleTime = -Mathf.Infinity; // ����� ���������� ������������

    private void Update()
    {
        if (Time.time - lastWobbleTime >= cooldownTime)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                // ������ ������������ �����
                StartCoroutine(Wobble(-transform.right));
                lastWobbleTime = Time.time;
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                // ������ ������������ ������
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
