using UnityEngine;

public class FreeMovement : MonoBehaviour
{
    public float moveSpeed = 10f; // �������� �����������
    public float upDownSpeed = 5f; // �������� �� ���������

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // ��������� ����������
        rb.gravityScale = 0;

        // ��������� ������������
        Collider2D col = GetComponent<Collider2D>();
        if (col != null)
        {
            col.isTrigger = true;
        }
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal"); // A/D ��� �������
        float moveY = Input.GetAxis("Vertical");   // W/S ��� �������

        // ������� ���������
        rb.linearVelocity = new Vector2(moveX * moveSpeed, moveY * upDownSpeed);
    }
}

