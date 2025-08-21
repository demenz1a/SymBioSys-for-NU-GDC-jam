using UnityEngine;

public class FreeMovement : MonoBehaviour
{
    public float moveSpeed = 10f; // скорость перемещения
    public float upDownSpeed = 5f; // скорость по вертикали

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Отключаем гравитацию
        rb.gravityScale = 0;

        // Отключаем столкновения
        Collider2D col = GetComponent<Collider2D>();
        if (col != null)
        {
            col.isTrigger = true;
        }
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal"); // A/D или стрелки
        float moveY = Input.GetAxis("Vertical");   // W/S или стрелки

        // Двигаем персонажа
        rb.linearVelocity = new Vector2(moveX * moveSpeed, moveY * upDownSpeed);
    }
}

