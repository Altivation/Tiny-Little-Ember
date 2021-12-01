using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Haystack : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int cost = 1;
    [SerializeField] float delay;
    Respawn respawn;
    Animator anim;
    bool inContact;
    float currTime;
    bool isCombusting;

    void Start()
    {
        inContact = false;
        isCombusting = false;
        respawn = GetComponent<Respawn>();
        anim = GetComponent<Animator>();
        currTime = 0;
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
                StartCoroutine(Combust());
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

	public IEnumerator Combust()
	{
        if (!isCombusting)
		{
            anim.SetTrigger("burn");
            fuelManager.Instance.lose(cost);
            musicManager.Instance.playSource("Haystack");
            isCombusting = true;
            while (anim.GetCurrentAnimatorStateInfo(0).IsName("Default"))
            {
                yield return null;
            }
            while (anim.GetCurrentAnimatorStateInfo(0).IsName("haystack") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime <= 1)
            {
                yield return null;
            }
            respawn.Hide();
            isCombusting = false;
        }
        
	}
    
}
