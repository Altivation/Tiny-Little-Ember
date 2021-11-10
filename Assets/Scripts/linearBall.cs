using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class linearBall : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float speed;
    bool direction; //true = left
    movement player;

	private void Awake()
	{
        direction = player.sr.flipX;
	}
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (direction)
		{
            transform.Translate(speed * Vector2.left * Time.deltaTime);
		} else
		{
            transform.Translate(speed * Vector2.right * Time.deltaTime);
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
