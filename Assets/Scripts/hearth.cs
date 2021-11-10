using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hearth : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float ratePerSecond;
    bool inContact;
    void Start()
    {
        inContact = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (inContact)
		{
            heatManager.gainHeat(ratePerSecond * Time.deltaTime);
		}
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "player")
		{
            inContact = true;
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "player")
		{
			inContact = false;
		}
	}
}
