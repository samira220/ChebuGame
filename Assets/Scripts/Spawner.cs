//using UnityEngine;
//using System.Collections.Generic;

//public class Spawner : MonoBehaviour
//{
//    public GameObject objectToSpawn; // Объект для появления
//    public float spawnRate = 1f;     // Частота появления
//    private float nextSpawnTime;       // Время следующего появления
//    private GameObject[] spawnPoints; // Массив точек спавна

//    void Start()
//    {
//        // Ищем все объекты с тегом SpawnPoint
//        spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");
//        if (spawnPoints.Length == 0)
//        {
//            Debug.LogError("Не найден ни один объект с тегом SpawnPoint!");
//            enabled = false; // Отключаем скрипт, если точек нет
//        }
//    }

//    void Update()
//    {
//        // Проверяем, пришло ли время для появления
//        if (Time.time >= nextSpawnTime)
//        {
//            Spawn();
//            // Устанавливаем время следующего появления
//            nextSpawnTime = Time.time + 1f / spawnRate;
//        }
//    }

//    private void Spawn()
//    {

//            if (spawnPoints.Length > 0)
//            {
//                // Выбираем случайную точку спавна
//                int randomIndex = Random.Range(0, spawnPoints.Length);
//                Vector3 spawnPosition = spawnPoints[randomIndex].transform.position;
//                GameObject newOrange = Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
//                Debug.Log("Создан апельсин: " + newOrange.name + ", Тег: " + newOrange.tag); // Добавлено!
//            }


//        //if (spawnPoints.Length > 0)
//        //{
//        //    // Выбираем случайную точку спавна
//        //    int randomIndex = Random.Range(0, spawnPoints.Length);
//        //    Vector3 spawnPosition = spawnPoints[randomIndex].transform.position;
//        //    Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
//        //}
//    }
//}
using UnityEngine;
using System.Collections.Generic;

public class Spawner : MonoBehaviour
{
    public GameObject objectToSpawn; // Объект для появления
    public float spawnRate = 1f;     // Частота появления (апельсинов в секунду)
    private float nextSpawnTime;       // Время следующего появления
    private GameObject[] spawnPoints; // Массив точек спавна

    void Start()
    {
        // Ищем все объекты с тегом SpawnPoint
        FindSpawnPoints(); // Вызываем функцию для поиска точек спавна
        nextSpawnTime = Time.time + 1f / spawnRate; // Инициализируем время следующего спавна
    }

    void Update()
    {
        // Проверяем, пришло ли время для появления
        if (Time.time >= nextSpawnTime)
        {
            Spawn();
            // Устанавливаем время следующего появления
            nextSpawnTime = Time.time + 1f / spawnRate; // Убедитесь, что это вызывается КАЖДЫЙ раз
            Debug.Log("Следующее появление: " + nextSpawnTime); // Отладка
        }
    }

    private void Spawn()
    {
        FindSpawnPoints(); // Обновляем список точек спавна перед каждым спавном

        if (spawnPoints.Length > 0)
        {
            // Выбираем случайную точку спавна
            int randomIndex = Random.Range(0, spawnPoints.Length);
            Vector3 spawnPosition = spawnPoints[randomIndex].transform.position;
            GameObject newOrange = Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);

            Debug.Log("Создан апельсин: " + newOrange.name + ", Тег: " + newOrange.tag); // Отладка
        }
        else
        {
            Debug.LogError("Нет точек спавна! Убедитесь, что объекты с тегом 'SpawnPoint' присутствуют на сцене.");
        }
    }

    // Функция для поиска и обновления списка точек спавна
    private void FindSpawnPoints()
    {
        spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");
        if (spawnPoints.Length == 0)
        {
            Debug.LogError("Не найден ни один объект с тегом SpawnPoint!");
            //Можно отключить спавнер, но лучше продолжать попытки поиска
            //enabled = false;
        }
        else
        {
            Debug.Log("Найдено точек спавна: " + spawnPoints.Length);
        }
    }
}

