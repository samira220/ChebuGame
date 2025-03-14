using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class CrocodileController : MonoBehaviour
{
    public float moveSpeed = 5f;        // Скорость движения крокодила
    public Text scoreText;              // Ссылка на объект Text для отображения счета (ОБЯЗАТЕЛЬНО ПЕРЕТАЩИТЕ!)
    public float detectionRadius = 10f;   // Радиус поиска апельсинов

    private int score = 0;               // Текущий счет
    private Transform closestOrange;      // Ближайший апельсин
    private Rigidbody2D rb;             // Rigidbody2D крокодила

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (scoreText == null)
        {
            Debug.LogError("Score Text is not assigned! Please assign it in the Inspector.");
        }
        UpdateScoreText(); // Инициализируем текст счета
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
            // Если ближайшего апельсина нет, останавливаем крокодила.
            rb.velocity = Vector2.zero;
        }
    }

    void FindClosestOrange()
    {
        GameObject[] oranges = GameObject.FindGameObjectsWithTag("Orange");
        Debug.Log("Найдено апельсинов: " + oranges.Length); 

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
            Debug.Log("Ближайший апельсин: " + closestOrange.name + ", дистанция: " + minDistance); 
        }
    }

    void MoveTowardsOrange()
    {
        Vector2 direction = (closestOrange.position - transform.position).normalized;
        rb.velocity = direction * moveSpeed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Столкновение с: " + other.gameObject.name + ", тег: " + other.gameObject.tag); // Отладка

        if (other.gameObject.CompareTag("Orange"))
        {
            // Апельсин пойман!
            Destroy(other.gameObject);
            IncreaseScore();
            closestOrange = null; // Сбрасываем, чтобы найти следующий апельсин
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
            scoreText.text = "Счет к: " + score;
        }
    }
}
