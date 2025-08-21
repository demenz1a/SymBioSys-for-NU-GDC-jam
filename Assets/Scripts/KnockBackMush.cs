using System.Data;
using UnityEngine;

public class BouncePad : MonoBehaviour
{
    public float bounceForce = 30f;
    private Animator animator;
    private Vector3 initialScale;

    private void Awake()
    {
        animator = GetComponent<Animator>(); // Получаем Animator на том же объекте
        initialScale = new Vector3(0.1991941f, 0.1936695f, 1f);
    }

    private void Update()
    {
        //transform.localScale = initialScale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    { 
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);

                rb.AddForce(Vector2.up * bounceForce, ForceMode2D.Impulse);
                animator.SetTrigger("Bounce");
            }
        }
    }
}


