using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestrictedMovement : MonoBehaviour
{
    public float minX = -5f;
    public float maxX = 5f;
    public float minY = -3f;
    public float maxY = 3f;

    private Rigidbody2D _rb;
     
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        if (_rb == null)
        {
            Debug.LogError("Rigidbody2D not found on this object!");
        }

    }

    void Update()
    {
        if (_rb == null)
        {
            return;
        }
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector2 moveDirection = new Vector2(horizontalInput, verticalInput).normalized;

        // Ограничиваем координаты объекта
        float clampedX = Mathf.Clamp(_rb.position.x, minX, maxX);
        float clampedY = Mathf.Clamp(_rb.position.y, minY, maxY);

        _rb.position = new Vector2(clampedX, clampedY);
    }
}

