using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeOut : MonoBehaviour
{
    public float fadeDuration = 0.2f; // Время, за которое исчезает (в секундах)
    public SpriteRenderer spriteRenderer;
    public Animator animator;
    private float startAlpha;
    private float elapsedTime = 0f;
    private bool isFading = false;

    private void Start()
    {
        startAlpha = spriteRenderer.color.a;
    }

    private void Update()
    {
        if (isFading)
        {
            elapsedTime += Time.deltaTime;
            float newAlpha = Mathf.Lerp(startAlpha, 0f, elapsedTime / fadeDuration);
            Color color = spriteRenderer.color;
            color.a = newAlpha;
            spriteRenderer.color = color;

            if (elapsedTime >= fadeDuration)
            {
                isFading = false;
            }
        }
    }

    public void StartFade()
    {
        isFading = true;
        elapsedTime = 0f;
        startAlpha = spriteRenderer.color.a;
        animator.SetBool("Animation",true);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("RatScene");
    }
}

