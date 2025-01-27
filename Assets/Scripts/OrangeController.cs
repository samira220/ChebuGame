using UnityEngine;

public class OrangeController : MonoBehaviour
{
    void Update()
    {
        // Проверяем апельсин за границей экрана
        if (GameManager.Instance.IsOrangeOutsideScreen(transform))
        {
            GameManager.Instance.TakeDamage();
            Destroy(gameObject); // Уничтожаем апельсин
        }
    }
}
