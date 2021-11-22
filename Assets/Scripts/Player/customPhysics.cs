using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class customPhysics : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] BoxCollider2D box;
    public bool onGround;
    public float gravity;
    [SerializeField] float airResistance;
    [SerializeField] float dragMultiplier;
    [SerializeField] LayerMask solid;
    [HideInInspector] public Rigidbody2D rb;
    move MOVE;
    void Start()
    {
        box = GetComponent<BoxCollider2D>();
        MOVE = GetComponent<move>();
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = gravity;
    }

    // Update is called once per frame
    void Update()
    {
        onGround = IsGrounded();
        Drag();
    }

    public void SetX(float x)
	{
        rb.velocity = new Vector2(x, rb.velocity.y);
	}

    public void SetY(float y)
	{
        rb.velocity = new Vector2(rb.velocity.x, y);
	}

    public void SetVector(Vector2 vector)
	{
        rb.velocity = vector;
	}
    public void AddX(float x)
	{
        rb.velocity = new Vector2(rb.velocity.x + x, rb.velocity.y);
	}

    public void AddY(float y)
	{
        rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y + y);
	}

    public void AddVector(Vector2 vector)
	{
        rb.velocity += vector;
	}
    public void Drag()
	{
        if (rb.velocity.x > 0)
		{
            if (rb.velocity.x > MOVE.airSpeed)
			{
                AddX(-1 * airResistance * Time.deltaTime);
			} else if (!(Input.GetKey("d") || Input.GetKey("right")))
			{
                AddX(-1 * dragMultiplier * Time.deltaTime);
			}
		} else if (rb.velocity.x < 0)
		{
            if (rb.velocity.x < -1 * MOVE.airSpeed)
            {
                AddX(airResistance * Time.deltaTime);
            }
            else if (!(Input.GetKey("a") || Input.GetKey("left")))
            {
                AddX(dragMultiplier * Time.deltaTime);
            }
        }
	}

    public bool IsGrounded()
    {
        RaycastHit2D ray = Physics2D.Raycast(transform.position + new Vector3(box.offset.x, box.offset.y), Vector2.down, box.size.y / 2 + 0.02f, solid); 
        return ray.collider != null;
    }

	private void OnDrawGizmos()
	{
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position + new Vector3(box.offset.x, box.offset.y), transform.position + new Vector3(box.offset.x, box.offset.y) + (Vector3.down * (0.02f + box.size.y / 2)));
	}
}
