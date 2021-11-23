using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public float airSpeed;
    
    [HideInInspector] public bool direction; //facing right is true

    customPhysics player;
    void Start()
    {
        player = GetComponent<customPhysics>();
        transform.localScale = new Vector3(transform.localScale[0] * -1, transform.localScale[1], transform.localScale[2]);
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKey("a") || Input.GetKey("left")) && !(Input.GetKey("d") || Input.GetKey("right")))
        {
            SwitchDirectionTo(false);
            MoveTo();
        } else if ((Input.GetKey("d") || Input.GetKey("right")) && !(Input.GetKey("a") || Input.GetKey("left")))
        {
            SwitchDirectionTo(true);
            MoveTo();
        } else if (player.onGround)
        {
            player.SetX(0);
        }
        
    }

    public void SwitchDirectionTo(bool newDirection)
    {
        if (direction != newDirection)
        {
            direction = newDirection;
            transform.localScale = new Vector3(transform.localScale[0] * -1, transform.localScale[1], transform.localScale[2]);
        }
    }

    public void MoveTo()
	{
        if (direction)
		{
            //moving right
            if (player.onGround)
			{
                player.SetX(speed);
			} else
			{
                if(player.rb.velocity.x < -1 * airSpeed)
                {
                    player.AddX(airSpeed * Time.deltaTime);
                } else
                {
                    player.SetX(airSpeed);
                }
            }
		} else
		{
            //moving left
            if (player.onGround)
            {
                player.SetX(-1 * speed);
            }
            else
            {
                if (player.rb.velocity.x > airSpeed)
                {
                    player.AddX(-1 * airSpeed * Time.deltaTime);
                }
                else
                {
                    player.SetX(-1 * airSpeed);
                }
            }
        }
	}

}
