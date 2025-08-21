using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Exit : MonoBehaviour
{
    [SerializeField] GameObject cutscene;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Instantiate(cutscene);
        }
    }

    public void StartEnd()
    {
        SceneManager.LoadScene("EndScene");
    }

    public void StartLava()
    {
        SceneManager.LoadScene("LabirintScene");
    }
}