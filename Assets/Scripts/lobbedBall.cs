using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lobbedBall : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float force;
    [SerializeField] float survivalTime;
    [SerializeField] int bounces;

    bool direction; //left is true
    movement player;
    Rigidbody2D rb;

	private void Awake()
	{
        rb = GetComponent<Rigidbody2D>();
        player = GetComponent<movement>();
        direction = player.sr.flipX;
	}
	void Start()
    {
        if (direction)
		{
            rb.AddForce(Vector3.left * force, ForceMode2D.Impulse);
		} else
		{
            rb.AddForce(Vector3.right * force, ForceMode2D.Impulse);
		}
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
        bounces--;
        if (collision.gameObject.tag == "ice" || collision.gameObject.tag == "break")
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
