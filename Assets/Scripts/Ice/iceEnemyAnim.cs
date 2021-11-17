using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iceEnemyAnim : MonoBehaviour
{
    // Start is called before the first frame update
    Animator anim;
    iceAI parent;
    [SerializeField] int iceHP = 2;
    [SerializeField] float delay;
    Rigidbody2D rb;
    Collider2D hitbox;
    bool inContact;
    float currTime;
    bool isCombusting;
    bool isAlive;
    void Start()
    {
        inContact = false;
        isCombusting = false;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        hitbox = GetComponent<BoxCollider2D>();
        parent = GetComponent<iceAI>();
        if (parent.state == "move" || parent.state == "motion")
		{
            anim.SetTrigger("run");
		}
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
        anim.SetTrigger("damage");
        if (iceHP == 2)
        {
            musicManager.Instance.playSource("IceCrack");
            while (anim.GetCurrentAnimatorStateInfo(0).IsName("idle") || anim.GetCurrentAnimatorStateInfo(0).IsName("run"))
            {
                yield return null;
            }
            while ((anim.GetCurrentAnimatorStateInfo(0).IsName("idleDamaged") || anim.GetCurrentAnimatorStateInfo(0).IsName("runDamaged")) && anim.GetCurrentAnimatorStateInfo(0).normalizedTime <= 1)
            {
                yield return null;
            }
        }
        else if (iceHP == 1)
        {
            rb.isKinematic = true;
            hitbox.enabled = false;
            parent.isAlive = false;
            musicManager.Instance.playSource("Splat");
            while (anim.GetCurrentAnimatorStateInfo(0).IsName("idleDamaged") || anim.GetCurrentAnimatorStateInfo(0).IsName("runDamaged"))
            {
                yield return null;
            }
            while (anim.GetCurrentAnimatorStateInfo(0).IsName("melt") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime <= 1)
            {
                yield return null;
            }
        }
        isCombusting = false;
        if (iceHP > 1)
        {
            iceHP--;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
