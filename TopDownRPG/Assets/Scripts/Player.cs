using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private RaycastHit2D hit;
    private Vector3 moveDelta;
    public float movementSpeed;

    void Start()
    {
        // Getting the boxCollider component for the player
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        // Reset moveDelta and normalize it, otherwise diagonal speed would exceed axial speed
        moveDelta = new Vector3(x, y, 0).normalized;

        // Swap sprite direction going right or left
        if (moveDelta.x > 0)
        {
            transform.localScale = Vector3.one;
        }
        else if (moveDelta.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        // Make sure we can move in this direction by casting a box there first, if the box returns null, we are free to move
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        if (hit.collider == null)
        {
            // Make this character move on the y-axis
            transform.Translate(0, moveDelta.y * Time.deltaTime * movementSpeed, 0);
        }

        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        if (hit.collider == null)
        {
            // Make this character move on the x-axis
            transform.Translate(moveDelta.x * Time.deltaTime * movementSpeed, 0, 0);
        }
    }
}
