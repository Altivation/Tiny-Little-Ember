using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoyoteTime : MonoBehaviour
{
    // Start is called before the first frame update
    [HideInInspector] public bool coyoteReady;
    [SerializeField] float coyoteTime;
    float currTime;
    jump JUMP;
    customPhysics player;
    void Start()
    {
        currTime = 0;
        player = GetComponent<customPhysics>();
        JUMP = GetComponent<jump>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!player.onGround && Mathf.Abs(player.rb.velocity.y) < 0.01f && player.rb.gravityScale == 0f && !JUMP.hasJumped)
		{
            currTime += Time.deltaTime;
            if (currTime < coyoteTime)
			{
                JUMP.weirdJump = true;
			} else
			{
                player.rb.gravityScale = player.gravity;
                JUMP.weirdJump = false;
			}
		} else
		{
            currTime = 0;
		}
    }
}
