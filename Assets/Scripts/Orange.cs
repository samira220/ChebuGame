using UnityEngine;

public class Orange : MonoBehaviour
{
    // ������ ���������� � ��� ��� ��������� (��������, ������ � �.�.)

    void FixedUpdate()
    {
        if (GameManager.Instance.IsOrangeOutsideScreen(transform))
        {
            GameManager.Instance.TakeDamage();
            Destroy(gameObject); // ���������� �������� ����� ������ �����
        }
    }
}
