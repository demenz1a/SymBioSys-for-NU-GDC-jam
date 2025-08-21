using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ExitToLava : MonoBehaviour
{
    [SerializeField] GameObject end;
    [SerializeField] GameObject dialoug;

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
        SceneManager.LoadScene("LavaScene");
    }

    public void StartDialoug()
    {
        Instantiate(dialoug);
    }
}

