using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class CrocodileController : MonoBehaviour
{
    public float moveSpeed = 5f;        // �������� �������� ���������
    public Text scoreText;              // ������ �� ������ Text ��� ����������� ����� (����������� ����������!)
    public float detectionRadius = 10f;   // ������ ������ ����������

    private int score = 0;               // ������� ����
    private Transform closestOrange;      // ��������� ��������
    private Rigidbody2D rb;             // Rigidbody2D ���������

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (scoreText == null)
        {
            Debug.LogError("Score Text is not assigned! Please assign it in the Inspector.");
        }
        UpdateScoreText(); // �������������� ����� �����
    }

    void Update()
    {
        FindClosestOrange();

        if (closestOrange != null)
        {
            MoveTowardsOrange();
        }
        else
        {
            // ���� ���������� ��������� ���, ������������� ���������.
            rb.velocity = Vector2.zero;
        }
    }

    void FindClosestOrange()
    {
        GameObject[] oranges = GameObject.FindGameObjectsWithTag("Orange");
        Debug.Log("������� ����������: " + oranges.Length); 

        if (oranges.Length == 0)
        {
            closestOrange = null;
            return;
        }

        closestOrange = null;
        float minDistance = Mathf.Infinity;
        Vector3 currentPosition = transform.position;

        foreach (GameObject orange in oranges)
        {
            float distance = Vector3.Distance(orange.transform.position, currentPosition);
            if (distance < minDistance && distance <= detectionRadius)
            {
                closestOrange = orange.transform;
                minDistance = distance;
            }
        }

        if (closestOrange != null)
        {
            Debug.Log("��������� ��������: " + closestOrange.name + ", ���������: " + minDistance); 
        }
    }

    void MoveTowardsOrange()
    {
        Vector2 direction = (closestOrange.position - transform.position).normalized;
        rb.velocity = direction * moveSpeed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("������������ �: " + other.gameObject.name + ", ���: " + other.gameObject.tag); // �������

        if (other.gameObject.CompareTag("Orange"))
        {
            // �������� ������!
            Destroy(other.gameObject);
            IncreaseScore();
            closestOrange = null; // ����������, ����� ����� ��������� ��������
        }
    }

    void IncreaseScore()
    {
        score++;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "���� �: " + score;
        }
    }
}
