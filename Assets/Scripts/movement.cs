using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float speed;
    [SerializeField] float fastfall;
    public float airspeed;
    public float jumpforce;
    [HideInInspector] public bool onground;
    [HideInInspector] public bool direction; //right is true
    [HideInInspector] public Rigidbody2D rb;

	private void Awake()
	{
        rb = GetComponent<Rigidbody2D>();
        onground = false;
	}
	void Start()
    {
        direction = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("a") || Input.GetKey("left"))
		{
            SwitchDirectionTo(false);
            if (onground)
			{
                transform.Translate(Vector2.left * speed * Time.deltaTime);
            } else
			{
                transform.Translate(Vector2.left * airspeed * Time.deltaTime);
            }
            
        } 
        if (Input.GetKey("d") || Input.GetKey("right"))
		{
            SwitchDirectionTo(true);
            if (onground)
            {
                transform.Translate(Vector2.right * speed * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector2.right * airspeed * Time.deltaTime);
            }
            
        }
        if (Input.GetKey("s") || Input.GetKey("down") || rb.velocity.y <= fastfall)
		{
            rb.velocity = Vector2.up * fastfall;
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
