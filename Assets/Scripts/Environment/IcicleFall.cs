using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcicleFall : MonoBehaviour
{
    Rigidbody2D rb;
    BoxCollider2D box;
    public float dist;
    bool isFalling = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        box = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        Physics2D.queriesStartInColliders = false;
        if (isFalling == false)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, dist);
            Debug.DrawRay(transform.position, Vector2.down * dist, Color.red);
            if (hit.transform != null)
            {
                if (hit.transform.tag == "Player")
                {
                    rb.gravityScale = 5;
                    isFalling = true;
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("HIT");
            fuelManager.Instance.lose(1);
            musicManager.Instance.playSource("Splat");
            Destroy(gameObject);
        }
        else
        {
            rb.gravityScale = 0;
            //box.enabled = false;
        }

        if (isFalling && (collision.gameObject.tag == "solid" || collision.gameObject.tag == "Untagged")) {
            musicManager.Instance.playSource("Splat");
            Destroy(gameObject);
        }

    }
}