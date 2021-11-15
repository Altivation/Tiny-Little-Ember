using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class linearBall : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float speed;
    bool direction;
    movement player;
	SpriteRenderer sr;
	private void Awake()
	{
        player = FindObjectOfType<movement>();
		direction = player.direction;
		Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());
		sr = FindObjectOfType<SpriteRenderer>();
	}
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (direction)
		{
            transform.Translate(Vector3.left * speed * Time.deltaTime);
			sr.flipX = true;
		} else
		{
            transform.Translate(Vector3.right * speed * Time.deltaTime);
			sr.flipX = true;
		}
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "ice" || collision.gameObject.tag == "breaks")
		{
            Destroy(collision.gameObject);
		}
        Destroy(gameObject);
	}

	private void OnBecameInvisible()
	{
		Destroy(gameObject);
	}
}
