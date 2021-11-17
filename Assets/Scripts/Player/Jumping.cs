using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : MonoBehaviour
{
    // Start is called before the first frame update
    movement move;
    float jumpforce;
    void Start()
    {
        move = GetComponentInParent<movement>();
        jumpforce = move.jumpforce;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("up") || Input.GetKey("w")) {
            
            if (move.onground && move.rb.velocity.y <= 0)
			{
                musicManager.Instance.playSource("Jump");
                move.rb.velocity = new Vector2(move.rb.velocity.x, 0);
                move.rb.AddForce(Vector3.up * jumpforce, ForceMode2D.Impulse);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "solid")
		{
            move.onground = true;
		}
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "solid")
		{
            move.onground = true;
		}
	}
	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "solid")
		{
            move.onground = false;
		}
	}
}
