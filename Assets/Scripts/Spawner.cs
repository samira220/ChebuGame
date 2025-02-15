//using UnityEngine;
//using System.Collections.Generic;

//public class Spawner : MonoBehaviour
//{
//    public GameObject objectToSpawn; // ������ ��� ���������
//    public float spawnRate = 1f;     // ������� ���������
//    private float nextSpawnTime;       // ����� ���������� ���������
//    private GameObject[] spawnPoints; // ������ ����� ������

//    void Start()
//    {
//        // ���� ��� ������� � ����� SpawnPoint
//        spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");
//        if (spawnPoints.Length == 0)
//        {
//            Debug.LogError("�� ������ �� ���� ������ � ����� SpawnPoint!");
//            enabled = false; // ��������� ������, ���� ����� ���
//        }
//    }

//    void Update()
//    {
//        // ���������, ������ �� ����� ��� ���������
//        if (Time.time >= nextSpawnTime)
//        {
//            Spawn();
//            // ������������� ����� ���������� ���������
//            nextSpawnTime = Time.time + 1f / spawnRate;
//        }
//    }

//    private void Spawn()
//    {

//            if (spawnPoints.Length > 0)
//            {
//                // �������� ��������� ����� ������
//                int randomIndex = Random.Range(0, spawnPoints.Length);
//                Vector3 spawnPosition = spawnPoints[randomIndex].transform.position;
//                GameObject newOrange = Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
//                Debug.Log("������ ��������: " + newOrange.name + ", ���: " + newOrange.tag); // ���������!
//            }


//        //if (spawnPoints.Length > 0)
//        //{
//        //    // �������� ��������� ����� ������
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
    public GameObject objectToSpawn; // ������ ��� ���������
    public float spawnRate = 1f;     // ������� ��������� (���������� � �������)
    private float nextSpawnTime;       // ����� ���������� ���������
    private GameObject[] spawnPoints; // ������ ����� ������

    void Start()
    {
        // ���� ��� ������� � ����� SpawnPoint
        FindSpawnPoints(); // �������� ������� ��� ������ ����� ������
        nextSpawnTime = Time.time + 1f / spawnRate; // �������������� ����� ���������� ������
    }

    void Update()
    {
        // ���������, ������ �� ����� ��� ���������
        if (Time.time >= nextSpawnTime)
        {
            Spawn();
            // ������������� ����� ���������� ���������
            nextSpawnTime = Time.time + 1f / spawnRate; // ���������, ��� ��� ���������� ������ ���
            Debug.Log("��������� ���������: " + nextSpawnTime); // �������
        }
    }

    private void Spawn()
    {
        FindSpawnPoints(); // ��������� ������ ����� ������ ����� ������ �������

        if (spawnPoints.Length > 0)
        {
            // �������� ��������� ����� ������
            int randomIndex = Random.Range(0, spawnPoints.Length);
            Vector3 spawnPosition = spawnPoints[randomIndex].transform.position;
            GameObject newOrange = Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);

            Debug.Log("������ ��������: " + newOrange.name + ", ���: " + newOrange.tag); // �������
        }
        else
        {
            Debug.LogError("��� ����� ������! ���������, ��� ������� � ����� 'SpawnPoint' ������������ �� �����.");
        }
    }

    // ������� ��� ������ � ���������� ������ ����� ������
    private void FindSpawnPoints()
    {
        spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");
        if (spawnPoints.Length == 0)
        {
            Debug.LogError("�� ������ �� ���� ������ � ����� SpawnPoint!");
            //����� ��������� �������, �� ����� ���������� ������� ������
            //enabled = false;
        }
        else
        {
            Debug.Log("������� ����� ������: " + spawnPoints.Length);
        }
    }
}

