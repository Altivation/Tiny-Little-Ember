using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charcoal : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int bonus;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
            fuelManager.Instance.maxfuel += bonus;
		}
	}
}
