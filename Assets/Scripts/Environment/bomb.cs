using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int cost;
    [SerializeField] float burstDrag;
    [SerializeField] float basePower;
    [SerializeField] float upPower;
    [SerializeField] float sidePower;
    [SerializeField] float downPower;
    [SerializeField] float weakUpPower;
    [SerializeField] float veryWeakUpPower;
    [SerializeField] float weakSidePower;
    [SerializeField] float upGravity;
    [SerializeField] float xGravity;
    
    const float normal45 = 0.70710678118f;
    [HideInInspector] public bool keepsGoing;
    bool hasExploded;

    Animator anim;
    Respawn respawn;
    CircleCollider2D hitbox;

    void Start()
    {
        anim = GetComponent<Animator>();
        hasExploded = false;
        keepsGoing = true;
        respawn = GetComponent<Respawn>();
        hitbox = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !hasExploded)
        {
            StartCoroutine(CelesteExplode(collision.gameObject));
        }
    }

    IEnumerator CelesteExplode(GameObject Player)
    {
        anim.SetTrigger("explode");
        musicManager.Instance.playSource("Bomb");
        hasExploded = true;

        Player.GetComponent<jump>().hasJumped = false;

        Vector3 direction = (Player.transform.position - transform.position).normalized;

        float angle = Mathf.Atan(direction.y / direction.x) * 180 / Mathf.PI; //converting it to degrees

        if (direction.x < 0)
        {
            angle = (angle + 180) % 360;
        } else if (angle < 0)
        {
            angle = (angle + 360) % 360;
        }

        var bombs = FindObjectsOfType<bomb>();
        foreach (bomb obj in bombs) {
            if (obj != this && obj.hasExploded)
			{
                obj.keepsGoing = false;
            }
		}
        //prepares to launch in 8 directions

        if (angle < 22.5 || angle > 337.5)
        {
            StartCoroutine(Dash(Player, new Vector2(basePower + sidePower, veryWeakUpPower), false)); //E
            Debug.Log("E");
        } else if (angle < 67.5)
        {
            StartCoroutine(Dash(Player, new Vector2(normal45 * basePower + weakSidePower, normal45 * basePower + weakUpPower))); //NE
            Debug.Log("NE");
        } else if (angle < 112.5)
        {
            StartCoroutine(Dash(Player, new Vector2(0f, basePower + upPower))); //N
            Debug.Log("N");
        } else if (angle < 157.5)
        {
            StartCoroutine(Dash(Player, new Vector2(normal45 * -1 * basePower - weakSidePower, normal45 * basePower + weakUpPower))); //NW
            Debug.Log("NW");
        } else if (angle < 202.5)
        {
            StartCoroutine(Dash(Player, new Vector2(-1 * basePower - sidePower, veryWeakUpPower), false)); //W
            Debug.Log("W");
        } else if (angle < 247.5)
        {
            StartCoroutine(Dash(Player, new Vector2(-1 * basePower - sidePower, veryWeakUpPower), false)); //SW
            Debug.Log("SW");
        } else if (angle < 292.5)
        {
            StartCoroutine(Dash(Player, new Vector2(0f, -1 * downPower))); //S
            Debug.Log("S");
        } else if (angle < 337.5)
        {
            StartCoroutine(Dash(Player, new Vector2(basePower + sidePower, veryWeakUpPower), false)); //SE
            Debug.Log("SE");
        }

        while (anim.GetCurrentAnimatorStateInfo(0).IsName("Default"))
        {
            yield return null;
        }

        fuelManager.Instance.lose(cost);

        while (anim.GetCurrentAnimatorStateInfo(0).IsName("Explode") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime <= 1)
        {
            yield return null;
        }


        respawn.Hide();

    }

    IEnumerator Dash(GameObject Player, Vector2 force, bool up = true)
    {
        customPhysics player = Player.GetComponent<customPhysics>();

        player.AddBoostX(force.x, "bomb");
        player.SetX(force.x);
        player.GetComponent<move>().weird = true;

        Physics2D.IgnoreCollision(Player.GetComponent<Collider2D>(), FindObjectOfType<platform>().GetComponent<CompositeCollider2D>());

        player.SetY(force.y);


        if (up)
        {
            player.rb.gravityScale = upGravity;
        } else
		{
            player.rb.gravityScale = xGravity;
		}

        float drag = 0f;

        player.AddBoostX(0, "drag");
        
        while ((drag < Mathf.Abs(force.x) || player.rb.velocity.y > 0.1f) && !player.onGround && keepsGoing)
        {
            drag += Time.deltaTime * burstDrag;

            if (Mathf.Abs(player.rb.velocity.x) < player.GetComponent<move>().airSpeed || drag > Mathf.Abs(force.x))
            {
                player.GetComponent<move>().weird = false;
                drag = Mathf.Abs(force.x);
                
            }

            player.AddBoostX(drag * Mathf.Sign(force.x) * -1, "drag");

            for (int i = 0; i < player.GetComponent<customPhysics>().boostList.Count; i++)
            {
                Debug.Log(force.x + " " + player.GetComponent<customPhysics>().boostList[i].key + " " + player.GetComponent<customPhysics>().boostList[i].boost);
            }

            yield return null;
        }

        Physics2D.IgnoreCollision(Player.GetComponent<Collider2D>(), FindObjectOfType<platform>().GetComponent<CompositeCollider2D>(), false);

        if (keepsGoing)
		{
            Debug.Log(player.rb.gravityScale);
            player.rb.gravityScale = player.gravity;

            player.GetComponent<move>().weird = false;
            player.SubBoostX("drag");
            player.SubBoostX("bomb");
        } else
		{
            keepsGoing = true;
        }

        hasExploded = false;
    }

}
