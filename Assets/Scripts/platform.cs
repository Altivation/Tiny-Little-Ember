using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] PlatformEffector2D plat;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("down"))
		{
            plat.rotationalOffset = 180;
		}

        if (Input.GetKeyUp("down"))
		{
            plat.rotationalOffset = 0;
		}
    }
}
