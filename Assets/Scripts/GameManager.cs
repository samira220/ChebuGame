using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; } // Синглтон для доступа к GameManager

    public int maxLives = 3;     // Максимальное количество жизней
    private int currentLives;    // Текущее количество жизней
    public GameObject vignette;  // Ссылка на объект vignette
    public GameObject hearts;    // Ссылка на объект Hearts
    public List<GameObject> heartSprites; // Список спрайтов сердец
    public float bottomScreenY = -5f; // Нижняя граница экрана
    private bool isGameOver = false; // Флаг для отслеживания Game Over
    public GameObject gameOverTextObject;  // Ссылка на текст Game Over

    void Awake()
    {
        // Синглтон
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        currentLives = maxLives;
if (vignette == null)
{
Debug.LogWarning("Ссылка на объект vignette не установлена.");
}
else
{
vignette.SetActive(false); // Скрываем vignette в начале игры
}

if (hearts == null)
{
Debug.LogWarning("Ссылка на объект hearts не установлена.");
}
else
{
UpdateHeartsDisplay(); // Первоначальное отображение
}
if (gameOverTextObject != null)
{
gameOverTextObject.SetActive(false); // Скрываем текст в начале игры
}
    }

    public void TakeDamage()
{
    if (isGameOver) return; // Не уменьшаем жизни если игра уже закончена.

    currentLives--;
    Debug.Log("Жизней осталось: " + currentLives);

    if (currentLives == 1 && vignette != null)
    {
        vignette.SetActive(true);
    }
    UpdateHeartsDisplay();

    if (currentLives <= 0)
    {
        Debug.Log("Game Over");
        GameOver();
    }
}

    public bool IsOrangeOutsideScreen(Transform orangeTransform)
{
return orangeTransform.position.y < bottomScreenY;
}

private void UpdateHeartsDisplay()
{
if (hearts == null || heartSprites == null)
{
return;
}
// Обновляем видимость сердец в соответствии с currentLives
for (int i = 0; i < heartSprites.Count; i++)
{
heartSprites[i].SetActive(i < currentLives); // Активируем только нужное количество сердец
}
}

private void GameOver()
{
    isGameOver = true; // Ставим флаг
    Time.timeScale = 0; // Останавливаем время

    Time.timeScale = 1; // Возобновляем время
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    if (gameOverTextObject != null)
{
    gameOverTextObject.SetActive(true);// Показываем текст
}

        //Больше не нужен StartCoroutine(HideGameOverAndRestart());  
    }

    //  Метод для перезапуска
    public void RestartGame()
{
    Time.timeScale = 1; // Возобновляем время
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
}
}



