using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float dragSpeed = 10f;       // Smooth movement speed
    private Rigidbody2D rb;

    private bool isDragging = false;
    private Vector3 touchOffset;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        HandleTouchMovement();
    }

    void HandleTouchMovement()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchWorldPos = Camera.main.ScreenToWorldPoint(touch.position);
            touchWorldPos.z = 0;

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    // Check if player is touched
                    Collider2D hit = Physics2D.OverlapPoint(touchWorldPos);
                    if (hit != null && hit.transform == transform)
                    {
                        isDragging = true;
                        touchOffset = transform.position - touchWorldPos;
                    }
                    break;

                case TouchPhase.Moved:
                    if (isDragging)
                    {
                        Vector3 targetPos = touchWorldPos + touchOffset;

                        rb.linearVelocity = new Vector2(
                            (targetPos.x - transform.position.x) * dragSpeed,
                            rb.linearVelocity.y
                        );
                    }
                    break;

                case TouchPhase.Ended:
                case TouchPhase.Canceled:
                    isDragging = false;
                    rb.linearVelocity = Vector2.zero;
                    break;
            }
        }
    }
}
