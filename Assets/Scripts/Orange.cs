using UnityEngine;

public class Orange : MonoBehaviour
{
    // ƒругие переменные и код дл€ апельсина (движение, физика и т.д.)

    void FixedUpdate()
    {
        if (GameManager.Instance.IsOrangeOutsideScreen(transform))
        {
            GameManager.Instance.TakeDamage();
            Destroy(gameObject); // ”ничтожаем апельсин после потери жизни
        }
    }
}
