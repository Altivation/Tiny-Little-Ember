using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class icewalk : MonoBehaviour
{
    // Start is called before the first frame update
    iceAI parent;
	iceEnemyAnim parentAnim;
	private void Awake()
	{
		parent = GetComponentInParent<iceAI>();
		parentAnim = GetComponentInParent<iceEnemyAnim>();
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
			if (collision.gameObject.layer == LayerMask.NameToLayer("Solid") || collision.gameObject.tag == "IceCube" || collision.gameObject.tag == "Player")
			{
				parent.SwitchDirections();

				if (collision.gameObject.tag == "Player")
				{
					if (!parentAnim.isCombusting)
					{
						StartCoroutine(parent.GetComponent<iceEnemyAnim>().Combust());
					}
				}
			}
		} 
	}
}
