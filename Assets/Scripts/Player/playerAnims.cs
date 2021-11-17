using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAnims : MonoBehaviour
{
    // Start is called before the first frame update
    Animator anim;

    bool movingLeft;
    bool movingRight;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("a") || Input.GetKeyDown("left"))
		{
            movingLeft = true;
		} else if (Input.GetKeyUp("a") || Input.GetKeyUp("left"))
		{
            movingLeft = false;
		}

        
        if (Input.GetKeyDown("d") || Input.GetKeyDown("right"))
		{
            movingRight = true;
		} else if (Input.GetKeyUp("d") || Input.GetKeyUp("right"))
		{
            movingRight = false;
		}
        
        if (fuelManager.fuel <= 0 && !anim.GetCurrentAnimatorStateInfo(0).IsName("fireDie"))
        {
            anim.SetTrigger("death");
        } else if (movingLeft || movingRight)
		{
            if (!anim.GetCurrentAnimatorStateInfo(0).IsName("fireRun"))
			{
                anim.SetTrigger("run");
            }
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
