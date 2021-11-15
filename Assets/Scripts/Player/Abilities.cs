using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abilities : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float dashDuration;
    [SerializeField] float dashSpeed;
    [SerializeField] float dashLoss;

    [SerializeField] float jumpForce;
    [SerializeField] float jumpLoss;

    [SerializeField] float abilityLag;

    bool isDashing;
    bool direction; //left is true
    float dashTime;
    movement player;
    Rigidbody2D rb;
    float currTime;
    void Start()
    {
        isDashing = false;
        player = GetComponent<movement>();
        rb = GetComponent<Rigidbody2D>();
        currTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        currTime += Time.deltaTime;

        if (currTime > abilityLag)
		{
            if (Input.GetKey("space") && heatManager.hasEnough(jumpLoss))
            {
                heatManager.loseHeat(jumpLoss);
                rb.velocity = new Vector2(rb.velocity.x, 0);
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                currTime = 0;
            } else if (Input.GetKey("left shift") && heatManager.hasEnough(dashLoss))
            {
                heatManager.loseHeat(dashLoss);
                isDashing = true;
                direction = player.direction;
                dashTime = 0;
                currTime = 0;
            }
        }
        

        if (isDashing)
		{
            dashTime += Time.deltaTime;
            if (dashTime <= dashDuration)
			{
                rb.gravityScale = 0;
                rb.velocity = new Vector2(rb.velocity.x, 0);
                if (direction)
				{
                    transform.Translate(Vector2.left * dashSpeed * Time.deltaTime);
				} else
				{
                    transform.Translate(Vector2.right * dashSpeed * Time.deltaTime);
				}
			} else
			{
                rb.gravityScale = 1;
                isDashing = false;
			}
		}
    }
}
