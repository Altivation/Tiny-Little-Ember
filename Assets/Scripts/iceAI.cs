using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iceAI : MonoBehaviour
{
    // Start is called before the first frame update
    public string state; //null, move, between
    [SerializeField] float speed;
    [SerializeField] List<Vector2> Positions;

    [HideInInspector] public float alive; //checks if its alive

    int index;

    Rigidbody2D rb;
    public bool direction = true; //true = right, false = left


	private void Awake()
	{
        rb = GetComponent<Rigidbody2D>();
        index = 0;
	}
	void Start()
    {
        if (!direction) //if facing left
		{
            transform.localScale = new Vector3(transform.localScale[0] * -1, transform.localScale[1], transform.localScale[2]);
		}
    }

    // Update is called once per frame
    void Update()
    {
        if (state == "move")
		{
            Forward(direction);
		} else if (state == "between")
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
    }

    public void Forward(bool direction)
	{
        if (direction)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }

    public void SwitchDirections()
	{
        direction = !direction;
        transform.localScale = new Vector3(transform.localScale[0] * -1, transform.localScale[1], transform.localScale[2]);
    }

	
}
