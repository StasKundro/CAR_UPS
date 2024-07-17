using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lift : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform pointA; // ������ �����
    public Transform pointB; // ������ �����
    public float speed = 2.0f; // �������� �������� �����
    public float waitTime = 10.0f; // ����� �������� � ������ �����

    private IEnumerator Start()
    {
        while (true)
        {
            // �������� �� ����� A � ����� B
            yield return StartCoroutine(MoveToPoint(pointB.position));
            // �������� � ����� B
            yield return new WaitForSeconds(waitTime);
            // �������� �� ����� B � ����� A
            yield return StartCoroutine(MoveToPoint(pointA.position));
            // �������� � ����� A
            yield return new WaitForSeconds(waitTime);
        }
    }

    private IEnumerator MoveToPoint(Vector3 target)
    {
        while (Vector3.Distance(transform.position, target) > 0.01f)
        {
            // ������� �������� � ������� �����
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
            yield return null;
        }
        // ������������ ������ ���������� ����
        transform.position = target;
    }
}
