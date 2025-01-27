using UnityEngine;
using System.Collections.Generic;

public class Spawner : MonoBehaviour
{
    public GameObject objectToSpawn; // Объект для появления
    public float spawnRate = 1f;     // Частота появления
    private float nextSpawnTime;       // Время следующего появления
    private GameObject[] spawnPoints; // Массив точек спавна

    void Start()
    {
        // Ищем все объекты с тегом SpawnPoint
        spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");
        if (spawnPoints.Length == 0)
        {
            Debug.LogError("Не найден ни один объект с тегом SpawnPoint!");
            enabled = false; // Отключаем скрипт, если точек нет
        }
    }

    void Update()
    {
        // Проверяем, пришло ли время для появления
        if (Time.time >= nextSpawnTime)
        {
            Spawn();
            // Устанавливаем время следующего появления
            nextSpawnTime = Time.time + 1f / spawnRate;
        }
    }

    private void Spawn()
    {
        if (spawnPoints.Length > 0)
        {
            // Выбираем случайную точку спавна
            int randomIndex = Random.Range(0, spawnPoints.Length);
            Vector3 spawnPosition = spawnPoints[randomIndex].transform.position;
            Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
        }
    }
}
