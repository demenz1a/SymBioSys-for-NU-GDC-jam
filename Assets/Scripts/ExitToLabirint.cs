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
            StartCoroutine(DelayBeforeLava()); // запускаем задержку
        }
    }

    private IEnumerator DelayBeforeLava()
    {
        yield return new WaitForSeconds(1f); // ждём 1 секунду
        StartLava(); // вызываем сцену
    }

    public void StartLava()
    {
        SceneManager.LoadScene("LabirintScene");
    }
}