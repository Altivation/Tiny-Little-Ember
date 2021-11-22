using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hearth : MonoBehaviour
{
	// Start is called before the first frame update
	[SerializeField] float rps;
	[SerializeField] float adjust;
    bool inContact;
	float currTime;
	float timeToRegenOne;
    void Start()
    {
        inContact = false;
		currTime = 0f;
		timeToRegenOne = 1.0f / rps;
    }

    // Update is called once per frame
    void Update()
    {
        if (inContact)
		{
			currTime += Time.deltaTime;
			if (currTime > timeToRegenOne)
			{
				fuelManager.Instance.capGain(1);
				currTime = 0f;
			}
		}
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
            inContact = true;
			GameManager.setSpawn(transform.position);
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			inContact = false;
			currTime = 0f;
		}
	}
}
