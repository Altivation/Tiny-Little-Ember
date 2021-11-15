using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class icewalk : MonoBehaviour
{
    // Start is called before the first frame update
    iceAI parent;
	private void Awake()
	{
		parent = GetComponentInParent<iceAI>();
	}
	void Start()
    {
		
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (parent.state == "move" && collision.gameObject != parent.gameObject)
		{
			if (collision.gameObject.tag == "solid" || collision.gameObject.tag == "Player")
			{
				parent.SwitchDirections();
			}
		} 
	}
}
