using UnityEngine;

public class ChebuFlip : MonoBehaviour
{
    public float flipLineX = 0f; // Координата X линии для поворота
    private bool isFacingRight = true; // Флаг, определяющий текущее направление

    void Update()
    {
        // Получаем текущую позицию объекта
        float chebuX = transform.position.x;

        // Проверяем, пересек ли объект линию
        if (isFacingRight && chebuX > flipLineX)
        {
            Flip();
        }
        else if (!isFacingRight && chebuX < flipLineX)
        {
            Flip();
        }
    }

    // Функция для поворота объекта
    private void Flip()
    {
        isFacingRight = !isFacingRight; // Меняем направление
        Vector3 scale = transform.localScale;
        scale.x *= -1; // Инвертируем масштаб по оси X
        transform.localScale = scale;
    }
}
