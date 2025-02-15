//using UnityEngine;
//using UnityEngine.UI;

//public class Basket : MonoBehaviour
//{
//    public int score = 0;
//    public Text scoreText;
//    public string scorePrefix = "Score: ";

//    void Start()
//    {
//        UpdateScoreText();
//    }

//    void UpdateScoreText()
//    {
//        if (scoreText != null)
//        {
//            scoreText.text = scorePrefix + score.ToString();
//        }
//        else
//        {
//            Debug.LogWarning("TextMeshPro объект не назначен в Basket скрипте!");
//        }
//    }
//}
using UnityEngine;
using UnityEngine.UI; // Обязательно!

public class Basket : MonoBehaviour
{
    public int score = 0;
    public Text scoreText; // Ссылка на объект Text (Legacy)
    public string scorePrefix = "Счет: ";

    public string orangeName = "clipart298879";  // Имя апельсина (или часть имени)

    void Start()
    {
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = scorePrefix + score.ToString();
        }
        else
        {
            Debug.LogWarning("Объект Text не назначен в Basket скрипте!");
        }
    }
    //2D
    void OnTriggerEnter2D(Collider2D other)
    {
        // Проверка по имени объекта
        if (other.gameObject.name.StartsWith(orangeName))
        {
            score++;
            UpdateScoreText();
            Destroy(other.gameObject); // Уничтожаем апельсин
            return; // Чтобы не проверять другие условия
        }

        // Проверка наличия компонента (например, скрипта OrangeController)
        OrangeController orangeController = other.GetComponent<OrangeController>();
        if (orangeController != null)
        {
            score++;
            UpdateScoreText();
            Destroy(other.gameObject); // Уничтожаем апельсин
        }

    }
}


