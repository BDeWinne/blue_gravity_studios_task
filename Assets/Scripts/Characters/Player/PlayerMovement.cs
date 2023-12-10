using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    private Rigidbody2D rb;
    private PlayerAnimation playerAnimation;
    private Vector2 lastDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnimation = GetComponent<PlayerAnimation>();
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        if (UI_Manager.Instance.PanelOpen)
        {
            rb.velocity = new Vector2(0, 0);
            playerAnimation.UpdateAnimation(new Vector2(0, 0), lastDirection);
            return;
        }
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(horizontalInput, verticalInput);

        if (horizontalInput != 0f && verticalInput != 0f)
        {
            if (Mathf.Abs(horizontalInput) > Mathf.Abs(verticalInput))
            {
                verticalInput = 0f;
            }
            else
            {
                horizontalInput = 0f;
            }
        }

        movement = new Vector2(horizontalInput, verticalInput).normalized;
        rb.velocity = movement * speed;

        if (movement != Vector2.zero)
        {
            lastDirection = movement;
        }
        playerAnimation.UpdateAnimation(movement, lastDirection);
    }
}

