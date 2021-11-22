using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iceBlock : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int cost = 2;
    [SerializeField] float delay;
    Animator anim;
    Rigidbody2D rb;
    Collider2D hitbox;
    Respawn respawn;
    bool inContact;
    float currTime;
    bool isCombusting;
    int HP;
    
    void Start()
    {
        inContact = false;
        isCombusting = false;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        hitbox = GetComponent<Collider2D>();
        respawn = GetComponent<Respawn>();
        HP = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (inContact)
        {
            currTime += Time.deltaTime;
            if (currTime > delay)
            {
                if (!isCombusting)
                {
                    isCombusting = true;
                    fuelManager.Instance.lose(1);
                    StartCoroutine(Combust());
                    currTime = 0;
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            inContact = true;
        }
        if (collision.gameObject.tag == "fireball")
        {
            if (!isCombusting)
            {
                isCombusting = true;
                StartCoroutine(Combust());
                //Destroy(collision.gameObject);
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            inContact = false;
            currTime = 0;
        }
    }

    IEnumerator Combust()
    {
        anim.SetTrigger("burn");
        if (HP == 2)
        {
            musicManager.Instance.playSource("IceCrack");
            while (anim.GetCurrentAnimatorStateInfo(0).IsName("Default"))
            {
                yield return null;
            }
            while (anim.GetCurrentAnimatorStateInfo(0).IsName("iceBlock") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime <= 1)
            {
                yield return null;
            }
        } else if (HP == 1)
		{
            rb.isKinematic = true;
            hitbox.enabled = false;
            musicManager.Instance.playSource("Splat");
            while (anim.GetCurrentAnimatorStateInfo(0).IsName("iceBlock"))
            {
                yield return null;
			}
            while (anim.GetCurrentAnimatorStateInfo(0).IsName("iceBreak") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime <= 1)
			{
                yield return null;
			}
		}
        isCombusting = false;
        if (HP > 1)
		{
            HP--;
		} else
		{
            respawn.Hide();
            rb.isKinematic = false;
            HP = cost;
        }
    }
}
