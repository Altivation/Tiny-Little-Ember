using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public float airSpeed;
    public float bonus;
    public float sub;

    [HideInInspector] public bool weird;

    [HideInInspector] public bool direction; //facing right is true

    customPhysics player;
    void Start()
    {
        player = GetComponent<customPhysics>();
        transform.localScale = new Vector3(transform.localScale[0] * -1, transform.localScale[1], transform.localScale[2]);
        direction = false;
        weird = false;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKey("a") || Input.GetKey("left")) && !(Input.GetKey("d") || Input.GetKey("right")))
        {
            SwitchDirectionTo(false);
            if (player.onGround)
			{
                player.SetX(speed * -1);
                musicManager.Instance.playSource("Walk");
			} else
			{
                if (weird)
                {
                    if (player.rb.velocity.x <= 0)
                    {
                        player.AddBoostX(bonus * -1, "move");
                    }
                    else
                    {
                        player.AddBoostX(sub, "move");
                    }
                }
                else
                {
                    player.AddBoostX(airSpeed * -1, "move");
                }
            }
        } else if ((Input.GetKey("d") || Input.GetKey("right")) && !(Input.GetKey("a") || Input.GetKey("left")))
        {
            SwitchDirectionTo(true);
            if (player.onGround)
            {
                player.SetX(speed);
                musicManager.Instance.playSource("Walk");
            }
            else
            {
                if (weird)
				{
                    if (player.rb.velocity.x >= 0)
					{
                        player.AddBoostX(bonus, "move");
					} else
					{
                        player.AddBoostX(sub * -1, "move");
					}
				} else
				{
                    player.AddBoostX(airSpeed, "move");
                }
                
            }
        } else if (player.onGround)
        {
            player.SetX(0);
        }

        if (Input.GetKeyUp("a") || Input.GetKeyUp("left"))
		{
            player.SubBoostX("move");
            //musicManager.Instance.playSource("Walk");
		}

        if (Input.GetKeyUp("d") || Input.GetKeyUp("right"))
		{
            player.SubBoostX("move");
          // musicManager.Instance.playSource("Walk");
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


}
