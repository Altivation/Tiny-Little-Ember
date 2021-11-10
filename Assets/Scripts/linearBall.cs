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
<<<<<<< Updated upstream
<<<<<<< Updated upstream
=======
        player = FindObjectOfType<movement>();
>>>>>>> Stashed changes
=======
        player = FindObjectOfType<movement>();
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
<<<<<<< Updated upstream
            transform.Translate(speed * Vector2.left * Time.deltaTime);
		} else
		{
            transform.Translate(speed * Vector2.right * Time.deltaTime);
		}
=======
=======
>>>>>>> Stashed changes
            transform.Translate(Vector2.left * speed * Time.deltaTime);
		} else
		{
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
<<<<<<< Updated upstream
<<<<<<< Updated upstream
		if (collision.gameObject.tag == "ice" || collision.gameObject.tag == "breaks")
		{
            Destroy(collision.gameObject);
		}
        Destroy(gameObject);
	}

	private void OnBecameInvisible()
	{
		Destroy(gameObject);
=======
=======
>>>>>>> Stashed changes
        if (collision.gameObject.tag == "ice" || collision.gameObject.tag == "cracked")
        {
            Destroy(collision.gameObject);
        }
        Destroy(gameObject);
    }

    private void onBecameInvisible()
	{
        Destroy(gameObject);
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
	}
}
