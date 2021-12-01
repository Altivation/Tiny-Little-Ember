using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAnims : MonoBehaviour
{
    // Start is called before the first frame update
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (fuelManager.fuel <= 0 && !anim.GetCurrentAnimatorStateInfo(0).IsName("fireDie"))
        {
            anim.SetTrigger("death");
            GetComponent<Collider2D>().enabled = false;
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            GetComponent<move>().enabled = false;
            GetComponent<jump>().enabled = false;
            musicManager.Instance.playSource("Dying");
        } else
		{
            if (fuelManager.fuel * 2 > fuelManager.Instance.maxfuel)
			{
                if (!anim.GetCurrentAnimatorStateInfo(0).IsName("fireHealthy"))
				{
                    anim.SetTrigger("high");
				}
			} else
			{
                if (!anim.GetCurrentAnimatorStateInfo(0).IsName("fireIdle"))
				{
                    anim.SetTrigger("low");
				}
			}
		}
    }
}
