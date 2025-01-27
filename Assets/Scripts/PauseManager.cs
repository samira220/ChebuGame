using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameObject Pause; // Ссылка на UI Image
    private bool isPaused = false;  // Флаг для отслеживания состояния паузы

    void Start()
    {
        // Проверяем, присвоена ли картинка
        if (Pause == null)
        {
            Debug.LogError("Не присвоена UI-картинка в PauseManager!");
            enabled = false; // Отключаем скрипт, если картинка не присвоена
        }
        else
        {
            Pause.SetActive(false); // Делаем картинку неактивной в начале
        }
    }

    void Update()
    {
        // Проверяем нажатие клавиши Escape
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToglePause(); // Переключаем состояние паузы
        }
    }

    private void ToglePause()
    {
        isPaused = !isPaused; // Инвертируем состояние паузы
        Pause.SetActive(isPaused); // Активируем или деактивируем картинку
        Time.timeScale = isPaused ? 0f : 1f; // Замораживаем или возобновляем время
    }
}


