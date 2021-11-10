using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lobbedBall : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float force;
    [SerializeField] int bounces;
    [SerializeField] float survivalTime;

    float currTime;
    bool direction;
    movement player;
    Rigidbody2D rb;

	private void Awake()
	{
        player = FindObjectOfType<movement>();
        rb = GetComponent<Rigidbody2D>();
        direction = !player.sr.flipX;
        currTime = 0;
	}
	void Start()
    {
        if (direction)
		{
            rb.AddForce(Vector2.left * force, ForceMode2D.Impulse);
		} else
		{
            rb.AddForce(Vector2.right * force, ForceMode2D.Impulse);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
        bounces--;
        if (collision.gameObject.tag == "ice" || collision.gameObject.tag == "breaks")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
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
