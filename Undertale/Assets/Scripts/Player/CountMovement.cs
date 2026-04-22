using UnityEngine;

public class CountMovement : MonoBehaviour
{
    public static int movementCount = 0;

    private Rigidbody2D rb;
    private bool wasMovingBefore = false;
    private bool isMovingNow = false;
    private float minimumSpeed = 0.01f;

    void Start()
    {
        movementCount = 0;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (rb.velocity.magnitude > minimumSpeed)
        {
            isMovingNow = true;
        }
        else
        {
            isMovingNow = false;
        }

        if (isMovingNow == true && wasMovingBefore == false)
        {
            movementCount = movementCount + 1;
        }

        wasMovingBefore = isMovingNow;
    }
}