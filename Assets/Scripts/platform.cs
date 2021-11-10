using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform : MonoBehaviour
{
    // Start is called before the first frame update
        PlatformEffector2D plat;
    void Start()
    {
        plat = GetComponent<PlatformEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("down") || Input.GetKeyDown("s"))
		{
            plat.rotationalOffset = 180;
		}

        if (Input.GetKeyUp("down") || Input.GetKeyUp("s"))
		{
            plat.rotationalOffset = 0;
		}
    }
}
