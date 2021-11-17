using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float explodeForce;
    [SerializeField] float explodeRadius;
    [SerializeField] float playerUp;
    [SerializeField] float playerDirection;
    [SerializeField] float lastingTime;
    [SerializeField] bool doesRegen;
    [SerializeField] float regenTime;

    bool hasExploded;
    bool disabled;

    float currTime;

    Animator anim;
    CircleCollider2D hitbox;
    SpriteRenderer sr;
    void Start()
    {
        anim = GetComponent<Animator>();
        hasExploded = false;
        hitbox = GetComponent<CircleCollider2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (disabled)
        {
            currTime += Time.deltaTime;
            if (currTime > regenTime)
            {
                disabled = false;
                sr.enabled = true;
                hitbox.enabled = true;
            }
        }
    }

	private void OnTriggerStay2D(Collider2D collision)
	{
        if (hasExploded)
		{
            Vector3 direction = (collision.gameObject.transform.position - transform.position).normalized;
            if (collision.gameObject.tag == "Player")
			{
                collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                direction = new Vector2(direction.x * playerDirection, Mathf.Abs(direction.y) * playerUp);
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(direction, ForceMode2D.Impulse);
			} else if (collision.gameObject.tag == "solid")
			{
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(direction * explodeForce, ForceMode2D.Impulse);
            }
		} else
		{
            if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "fireball")
            {
                StartCoroutine(explode());
                fuelManager.Instance.lose(1);
            }
        }
	}
	IEnumerator explode() {
        anim.SetTrigger("explode");
        musicManager.Instance.playSource("Bomb");
        hitbox.radius = explodeRadius;
        hasExploded = true;

        while (anim.GetCurrentAnimatorStateInfo(0).IsName("Default"))
		{
            yield return null;
		}
        while (anim.GetCurrentAnimatorStateInfo(0).IsName("Explode") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime <= 1)
		{
            yield return null;
		}

        
        float elapsed = 0f;
        
        while (elapsed <= lastingTime)
		{
            elapsed += Time.deltaTime;
            yield return null;
		}

        sr.enabled = false;
        hitbox.enabled = false;
        disabled = true;
        hasExploded = false;
        anim.SetTrigger("return");
        currTime = 0;
    }
}
