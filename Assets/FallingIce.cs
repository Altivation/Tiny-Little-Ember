using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingIce : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    float moveX;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveX * speed, rb.velocity.y);
        FlipPlayer();
    }

    void FlipPlayer() {
        if (moveX < 0) {
            transform.rotation = Quaternion.Euler(new Vector2(0, 100));
        }
        if (moveX > 0) {
            transform.rotation = Quaternion.Euler(new Vector2(0, 0));
        }
    }
}
