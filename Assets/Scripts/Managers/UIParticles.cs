using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIParticles : MonoBehaviour
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
        if (fuelManager.fuel == 0)
		{
            anim.SetTrigger("grow");
		}
    }
}
