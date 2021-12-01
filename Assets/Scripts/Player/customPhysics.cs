using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class customPhysics : MonoBehaviour
{
    // Start is called before the first frame update

    BoxCollider2D hitbox;
    public bool onGround;
    public float gravity;
    [SerializeField] LayerMask solid;
    [HideInInspector] public Rigidbody2D rb;
    move MOVE;

    int debug;
    public struct boosts
	{
        public float boost;
        public string key;
	}

    [HideInInspector] public List<boosts> boostList;

    float currXSpeed;
    void Start()
    {
        hitbox = GetComponent<BoxCollider2D>();
        MOVE = GetComponent<move>();
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = gravity;
        boostList = new List<boosts>();
        debug = -1;
    }
    
    // Update is called once per frame
    void Update()
    {
        onGround = IsGrounded();

        if (onGround)
		{
            DeleteBoosts();
		}

        if (!onGround)
		{
            SetX(currXSpeed);
        }
        
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

    public bool AddBoostX(float x, string key)
	{
        for (int i = 0; i < boostList.Count; i++)
		{
            if (boostList[i].key == key)
			{
                if (boostList[i].boost != x)
				{
                    SubBoostX(key);
                    AddBoostX(x, key);
                    return true;
				} else
				{
                    return false;
                }
			}
		}
        boosts temp;
        temp.boost = x;
        temp.key = key;
        boostList.Add(temp);

        UpdateSpeed();
        return true;
	}

    public bool SubBoostX(string key)
	{
        for (int i = 0; i < boostList.Count; i++)
		{
            if (boostList[i].key == key)
			{
                boostList.RemoveAt(i);
                UpdateSpeed();
                return true;
			}
		}
        return false;
	}

    public void UpdateSpeed()
	{
        float val = 0;
        for (int i = 0; i < boostList.Count; i++)
		{
            val += boostList[i].boost;
		}
        currXSpeed = val;
	}

    public void DeleteBoosts()
	{
        boostList.Clear();
        currXSpeed = 0;
	}
    public void AddVector(Vector2 vector)
	{
        rb.velocity += vector;
	}
 

    public bool IsGrounded()
    {
        RaycastHit2D ray = Physics2D.BoxCast(transform.position + new Vector3(hitbox.offset.x, hitbox.offset.y), hitbox.size, 0f, Vector2.down, 0.02f, solid);
        return ray.collider != null;
    }

    public GameObject OnTopOf()
	{
        RaycastHit2D ray = Physics2D.BoxCast(transform.position + new Vector3(hitbox.offset.x, hitbox.offset.y), hitbox.size, 0f, Vector2.down, 0.02f, solid);

        if (ray.collider != null)
		{
            return ray.collider.gameObject;
        } else
		{
            return null;
		}
        
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
        Debug.Log(collision.gameObject.tag);
		if (collision.gameObject.tag == "solid")
		{
            Debug.Log("called");
            musicManager.Instance.playSource("Land");
		}
	}
}
