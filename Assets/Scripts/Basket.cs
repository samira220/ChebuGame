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
//            Debug.LogWarning("TextMeshPro ������ �� �������� � Basket �������!");
//        }
//    }
//}
using UnityEngine;
using UnityEngine.UI; // �����������!

public class Basket : MonoBehaviour
{
    public int score = 0;
    public Text scoreText; // ������ �� ������ Text (Legacy)
    public string scorePrefix = "����: ";

    public string orangeName = "clipart298879";  // ��� ��������� (��� ����� �����)

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
            Debug.LogWarning("������ Text �� �������� � Basket �������!");
        }
    }
    //2D
    void OnTriggerEnter2D(Collider2D other)
    {
        // �������� �� ����� �������
        if (other.gameObject.name.StartsWith(orangeName))
        {
            score++;
            UpdateScoreText();
            Destroy(other.gameObject); // ���������� ��������
            return; // ����� �� ��������� ������ �������
        }

        // �������� ������� ���������� (��������, ������� OrangeController)
        OrangeController orangeController = other.GetComponent<OrangeController>();
        if (orangeController != null)
        {
            score++;
            UpdateScoreText();
            Destroy(other.gameObject); // ���������� ��������
        }

    }
}


