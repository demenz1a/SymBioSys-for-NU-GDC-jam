using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneStarter : MonoBehaviour
{
    public string sceneName = "MainMenu"; // ��� �����
    public float delay = 7f;              // �������� � ��������

    private bool sceneLoaded = false;

    private void Start()
    {
        StartCoroutine(WaitAndLoadScene());
    }

    private void Update()
    {
        if (!sceneLoaded && Input.GetKeyDown(KeyCode.Return))
        {
            LoadSceneNow();
        }
    }

    private IEnumerator WaitAndLoadScene()
    {
        yield return new WaitForSeconds(delay);
        LoadSceneNow();
    }

    private void LoadSceneNow()
    {
        if (sceneLoaded) return; // ����� �� ���������� ������
        sceneLoaded = true;
        SceneManager.LoadScene(sceneName);
    }
}

