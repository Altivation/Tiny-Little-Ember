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
		if (!direction) //if facing left
		{
			transform.localScale = new Vector3(transform.localScale[0] * -1, transform.localScale[1], transform.localScale[2]);
		}
	}

    // Update is called once per frame
    void Update()
    {
        if (direction)
		{
            transform.Translate(Vector3.right * speed * Time.deltaTime);
		} else
		{
            transform.Translate(Vector3.left * speed * Time.deltaTime);
		}
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
        Destroy(gameObject);
	}

	private void OnBecameInvisible()
	{
		Destroy(gameObject);
	}
}
