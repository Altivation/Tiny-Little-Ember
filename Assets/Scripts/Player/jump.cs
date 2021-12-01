using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jump : MonoBehaviour
{
    // Start is called before the first frame update
    public int jumpCost;
    public float hopSpeed;
    public float jumpSpeed;
    public float badJumpSpeed;
    [SerializeField] float fallBonus;
    [SerializeField] float returnSpeed;
    [SerializeField] float jumpSnap;
    [SerializeField] float hopSnap;
    [SerializeField] float fastfallGravity;
    public float maxFall;
    public float fastFall;
    float capFall;
    [HideInInspector] public bool hasJumped;
    [HideInInspector] public bool weirdJump;
    [HideInInspector] public bool wasGrounded;
    customPhysics player;
    void Start()
    {
        player = GetComponent<customPhysics>();
        hasJumped = false;
        weirdJump = false;
        wasGrounded = false;
        capFall = maxFall;
    }

    // Update is called once per frame
    void Update()
    {
        //controls jump motion
        if (!player.onGround)
		{
            if (hasJumped)
			{
                if (!(Input.GetKey("up") || Input.GetKey("w") || Input.GetKey("space") || Input.GetKey(KeyCode.RightShift)))
                {
                    player.rb.gravityScale = player.gravity + calculateFallModifier() * fallBonus;
                } else if (player.rb.velocity.y < 0 && (player.rb.gravityScale == player.gravity + jumpSnap || player.rb.gravityScale == player.gravity + hopSnap))
			    {   
                    player.rb.gravityScale = player.gravity;
			    }
            }
        } else
		{
            if (Mathf.Abs(player.rb.velocity.y) < 0.01f && !player.GetComponent<move>().weird)
			{
                hasJumped = false;
                player.rb.gravityScale = player.gravity;
                wasGrounded = true;
            }
		}


        //resets Gravity
        if (player.rb.velocity.y < capFall) //caps out max FallSpeed
        {
            player.SetY(capFall);
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
            Hop();
		}  

        if ((Input.GetKeyDown("space") || Input.GetKeyDown(KeyCode.RightShift)) && (player.onGround || weirdJump))
        {
            //big jump
            //play sound / feedback
            SuperJump();
		}

        if (Input.GetKey("s") || Input.GetKey("down"))
        {
            //fastFall
            if (!player.onGround)
			{
                capFall = fastFall;
                player.rb.gravityScale = fastfallGravity;
            }
        } else if (Input.GetKeyUp("s") || Input.GetKeyUp("down"))
		{
            capFall = maxFall;
		}
    }

    public void SuperJump()
	{
        musicManager.Instance.playSource("Jump");
        if (fuelManager.Instance.hasEnough(jumpCost))
		{
            fuelManager.Instance.lose(jumpCost);
            Jump(jumpSpeed);
            player.rb.gravityScale = player.gravity + jumpSnap;
        } else
		{
            Jump(badJumpSpeed);
            player.rb.gravityScale = player.gravity;
		}
	}
    public void Hop()
	{
        Jump(hopSpeed);
        
        player.rb.gravityScale = player.gravity + hopSnap;
	}
    public void Jump(float speed)
	{
        weirdJump = false;
        wasGrounded = false;
        hasJumped = true;
        
        player.SetY(speed);
	}

    float calculateFallModifier()
	{
        float val;
        val = (jumpSpeed + Mathf.Abs(player.rb.velocity.y)) / jumpSpeed;
        return Mathf.Abs(val);
	}
}
