using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform : MonoBehaviour
{
    // Start is called before the first frame update
    customPhysics player;
    void Start()
    {
        player = FindObjectOfType<customPhysics>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("down") || Input.GetKeyDown("s"))
		{
            Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<CompositeCollider2D>());
            Debug.Log(player.GetComponent<Collider2D>());
            Debug.Log(GetComponent<Collider2D>());
        }

        if (Input.GetKeyUp("down") || Input.GetKeyUp("s"))
		{
            Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<CompositeCollider2D>(), false);
        }
    }
}
