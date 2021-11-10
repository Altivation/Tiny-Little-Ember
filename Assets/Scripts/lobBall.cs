using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lobBall : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float force;
    bool direction; //true = left
    movement player;
    Rigidbody2D rb;
    [SerializeField] int bounce;

    [SerializeField] float survivalTime;
    float currTime;

	private void Awake()
	{
        player = FindObjectOfType<movement>();
        rb = FindObjectOfType<Rigidbody2D>();

        direction = player.sr.flipX;
	}
	void Start()
    {
        if (direction)
		{
            rb.AddForce(Vector3.left * force, ForceMode2D.Force);
		} else
		{
            rb.AddForce(Vector3.right * force, ForceMode2D.Force);
		}
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
        bounce--;
        if (collision.gameObject.tag == "ice" || collision.gameObject.tag == "breaks")
		{
            Destroy(collision.gameObject);
            Destroy(gameObject);
		}
        if (bounce <= 0)
		{
            Destroy(gameObject);
		}
	}

    private void onBecameInvisible()
	{
        Destroy(gameObject);
	}
}
