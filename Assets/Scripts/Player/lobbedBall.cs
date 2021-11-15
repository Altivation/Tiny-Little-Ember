using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lobbedBall : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float force;
    [SerializeField] int bounces;

    bool direction;
    movement player;
    Rigidbody2D rb;
    SpriteRenderer sr;

	private void Awake()
	{
        player = FindObjectOfType<movement>();
        rb = GetComponent<Rigidbody2D>();
        direction = player.direction;
        Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());
        sr = FindObjectOfType<SpriteRenderer>();
    }
	void Start()
    {
        if (direction)
		{
            rb.AddForce(Vector2.right * force, ForceMode2D.Impulse);
		} else
		{
            rb.AddForce(Vector2.left * force, ForceMode2D.Impulse);
            transform.localScale = new Vector3(transform.localScale[0] * -1, transform.localScale[1], transform.localScale[2]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
        bounces--;
        if (bounces <= 0)
		{
            Destroy(gameObject);
		}
    }

	private void OnBecameInvisible()
	{
        Destroy(gameObject);
	}
}
