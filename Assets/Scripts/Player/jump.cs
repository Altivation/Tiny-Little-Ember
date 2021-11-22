using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jump : MonoBehaviour
{
    // Start is called before the first frame update
    public int jumpCost;
    public float hopSpeed;
    public float jumpSpeed;
    [SerializeField] float fallBonus;
    [SerializeField] float returnSpeed;
    [SerializeField] float jumpSnap;
    public float maxFall;
    public bool hasJumped;
    public bool weirdJump;
    
    customPhysics player;
    void Start()
    {
        player = GetComponent<customPhysics>();
        hasJumped = false;
        weirdJump = false;
    }

    // Update is called once per frame
    void Update()
    {
        //controls jump motion
        if (!player.onGround && hasJumped)
		{
            if (!(Input.GetKey("up") || Input.GetKey("w") || Input.GetKey("space") || Input.GetKey(KeyCode.RightShift)))
            {
                player.rb.gravityScale = player.gravity + calculateFallModifier() * fallBonus;
            } else if (player.rb.velocity.y < 0 && player.rb.gravityScale == player.gravity + jumpSnap)
			{
                player.rb.gravityScale = player.gravity;
			}
        } else
		{
            if (Mathf.Abs(player.rb.velocity.y) < 0.01f)
			{
                hasJumped = false;
                player.rb.gravityScale = 0; //slows down if on Ground, enables coyote time
            }
		}


        //resets Gravity
        if (player.rb.velocity.y < maxFall) //caps out max FallSpeed
        {
            player.SetY(maxFall);
            player.rb.gravityScale = 0f;
            hasJumped = false;
        } else if (player.rb.velocity.y < returnSpeed) //slows down from snapping
		{
            player.rb.gravityScale = player.gravity;
            hasJumped = false;
		}

        if ((Input.GetKeyDown("up") || Input.GetKeyDown("w")) && (player.onGround || weirdJump))
		{
            //small jump
            Jump(hopSpeed);
		}  

        if ((Input.GetKeyDown("space") || Input.GetKeyDown(KeyCode.RightShift)) && (player.onGround || weirdJump))
        {
            //big jump
            //play sound / feedback
            SuperJump();
		}

        
    }

    public void SuperJump()
	{
        if (fuelManager.Instance.hasEnough(jumpCost))
		{
            fuelManager.Instance.lose(jumpCost);
            Jump(jumpSpeed);
            player.rb.gravityScale += jumpSnap;
        }
	}
    public void Jump(float speed)
	{
        player.rb.gravityScale = player.gravity;
        weirdJump = false;
        hasJumped = true;
        player.SetY(speed);
	}

    float calculateFallModifier()
	{
        float val;
        if (player.rb.velocity.y > 0f)
        {
            val = (jumpSpeed + player.rb.velocity.y) / jumpSpeed;
        } else
		{
            val = (jumpSpeed + player.rb.velocity.y) / jumpSpeed;
		}
        return Mathf.Abs(val);
	}
}
