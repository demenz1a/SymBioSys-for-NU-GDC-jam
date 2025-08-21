using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ExitToLabirint : MonoBehaviour
{
    [SerializeField] GameObject end;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Instantiate(end);
            StartCoroutine(DelayBeforeLava()); // ��������� ��������
        }
    }

    private IEnumerator DelayBeforeLava()
    {
        yield return new WaitForSeconds(1f); // ��� 1 �������
        StartLava(); // �������� �����
    }

    public void StartLava()
    {
        SceneManager.LoadScene("LabirintScene");
    }
}