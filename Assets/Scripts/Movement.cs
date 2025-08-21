using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    public float speed;
    private float moveInput;
    private Rigidbody2D rb;

    public float jumpForce;
    public bool isGrounded = true;

    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    public int extraJumps;
    public int extraJumpsValue;

    private bool facingRight = true;

    [SerializeField] private Transform TeleportPoint;
    [SerializeField] private GameObject Player;

    //private float previousY;
    public Animator animator;

    private void Start()
    {
        //previousY = transform.position.y;
        //animator = GetComponent<Animator>();

        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;

        moveInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * speed, rb.linearVelocity.y);

        if (isGrounded == true)
        {
            extraJumps = extraJumpsValue;
        }

        if (Input.GetKeyDown(KeyCode.Space) && extraJumps > 0)
        {
            rb.linearVelocity = Vector2.up * jumpForce;
            extraJumps--;
            animator.SetTrigger("Jump");

        }
        else if (Input.GetKeyDown(KeyCode.Space) && extraJumps == 0 && isGrounded == true)
        {
            rb.linearVelocity = Vector2.up * jumpForce;
            animator.SetTrigger("Jump");
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartScene();
        }
        //if (facingRight == false && moveInput > 0)
        //{
        //    Rotation();
        //}
        //if (facingRight == true && moveInput < 0)
        //{
        //    Rotation();
        //}
    }
    public void RestartScene()
    {
        Player.transform.position = TeleportPoint.position;
    }

    private void Rotation()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
