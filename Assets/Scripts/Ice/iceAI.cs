using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iceAI : MonoBehaviour
{
    // Start is called before the first frame update
    public string state; //null, move, between
    [SerializeField] float speed;
    [SerializeField] List<Vector2> Positions;
    [SerializeField] float switchDelay;
    float currTime;

    [HideInInspector] public float alive; //checks if its alive

    int index;
    public bool isAlive;

    [HideInInspector] public Rigidbody2D rb;
    public bool direction = true; //true = right, false = left


	private void Awake()
	{
        rb = GetComponent<Rigidbody2D>();
        isAlive = true;
        index = 0;
	}
	void Start()
    {
        if (!direction) //if facing left
		{
            transform.localScale = new Vector3(transform.localScale[0] * -1, transform.localScale[1], transform.localScale[2]);
		}

        currTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (state == "move" && isAlive)
		{
            Forward(direction);
		} else if (state == "between" && isAlive)
		{
            Vector2 destination = Positions[index];
            Forward(direction);

            if (transform.position.x < destination.x && !direction)
			{   
                SwitchDirections();
			} else if (transform.position.x > destination.x && direction)
			{
                SwitchDirections();
            }

            if (Mathf.Abs(destination.x - transform.position.x) < 0.1f)
			{
                index = (index + 1) % Positions.Count;
			}

		}

        if (currTime <= switchDelay)
        {
            currTime += Time.deltaTime;
        }
    }

    public void Forward(bool direction)
	{
        rb.velocity = new Vector2(0, rb.velocity.y);
        if (direction)
        {
            transform.Translate(Vector2.right * Time.deltaTime * speed);
            
        }
        else
        {
            transform.Translate(Vector2.left * Time.deltaTime * speed);
        }
    }

    public void SwitchDirections()
	{
        if (currTime > switchDelay)
		{
            direction = !direction;
            transform.localScale = new Vector3(transform.localScale[0] * -1, transform.localScale[1], transform.localScale[2]);
            currTime = 0;
        }
        
    }
}
