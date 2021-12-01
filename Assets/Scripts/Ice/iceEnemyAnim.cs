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
    [SerializeField] float timetoTakeDamage;
    Rigidbody2D rb;
    Collider2D hitbox;
    bool inContact;
    float currTime;
    [HideInInspector] public bool isCombusting;
    bool isAlive;
    void Start()
    {
        inContact = false;
        isCombusting = false;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        hitbox = GetComponent<BoxCollider2D>();
        parent = GetComponent<iceAI>();

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
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            inContact = false;
            currTime = 0;
        }
    }

    public IEnumerator Combust()
    {
        isCombusting = true;
        fuelManager.Instance.lose(1);
        
        if (iceHP == 2)
        {
            musicManager.Instance.playSource("IceCrack");
            float elapsed = 0f;
            while (elapsed <= timetoTakeDamage)
			{
                elapsed += timetoTakeDamage;
                yield return null;
			}
        }
        else if (iceHP == 1)
        {
            anim.SetTrigger("damage");
            rb.velocity = Vector2.zero;
            rb.isKinematic = true;
            parent.enabled = false;
            hitbox.enabled = false;
            musicManager.Instance.playSource("Splat");
            while (anim.GetCurrentAnimatorStateInfo(0).IsName("idle"))
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
            Debug.Log("ever called?");
            iceHP--;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
