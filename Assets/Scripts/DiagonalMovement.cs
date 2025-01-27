using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiagonalMovement : MonoBehaviour
{
    public float moveSpeed; // Скорость движения

    private Rigidbody2D rb; // Ссылка на Rigidbody2D
    void Start()
    {
        // Получаем ссылку на Rigidbody2D
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D не найден на объекте!");
            enabled = false;
        }
    }

    void FixedUpdate()
    {
        // Получаем ввод с клавиатуры
        float horizontalInput = 0f;
        float verticalInput = 0f;

        if (Input.GetKey(KeyCode.Q))
        {
            horizontalInput = -1f;
            verticalInput = 1f;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            horizontalInput = -1f;
            verticalInput = -1f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            horizontalInput = 1f;
            verticalInput = -1f;
        }
        else if (Input.GetKey(KeyCode.E))
        {
            horizontalInput = 1f;
            verticalInput = 1f;
        }

        // Создаем вектор движения
        Vector2 moveDirection = new Vector2(horizontalInput, verticalInput).normalized;

        // Двигаем объект
        if (rb != null)
            rb.velocity = moveDirection * moveSpeed;

        
    }

}
