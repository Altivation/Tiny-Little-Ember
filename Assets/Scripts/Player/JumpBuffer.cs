using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBuffer : MonoBehaviour
{
    // Start is called before the first frame update
    bool preHop;
    bool preJump;
    [SerializeField] float bufferTime;
    float currTime;
    customPhysics player;
    jump JUMP;
    void Start()
    {
        JUMP = GetComponent<jump>();
        player = GetComponent<customPhysics>();
        preHop = false;
        preJump = false;
        currTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!player.onGround)
		{
            if ((Input.GetKeyDown("up") || Input.GetKeyDown("w")) && !preJump)
            {
                preHop = true;
                currTime = bufferTime;
            }
            else if ((Input.GetKeyDown("space") || Input.GetKeyDown(KeyCode.RightShift)) && !preHop)
            {
                preJump = true;
                currTime = bufferTime;
            }
        }
        if (currTime > 0)
		{
            currTime -= Time.deltaTime;

            if (player.onGround)
			{
                if (preHop)
				{
                    preHop = false;
                    JUMP.Hop();

                    if (player.OnTopOf().GetComponent<Haystack>() != null )
					{
                        StartCoroutine(player.OnTopOf().GetComponent<Haystack>().Combust());
					} else if (player.OnTopOf().GetComponent<iceBlock>() != null)
					{
                        StartCoroutine(player.OnTopOf().GetComponent<iceBlock>().Combust());
                    } else if (player.OnTopOf().GetComponent<iceEnemyAnim>() != null)
					{
                        StartCoroutine(player.OnTopOf().GetComponent<iceEnemyAnim>().Combust());
					}

                }
                if (preJump)
				{
                    preJump = false;
                    JUMP.SuperJump();
				}
			}
		}
    }
}
