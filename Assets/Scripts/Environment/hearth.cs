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
	ParticleSystem ps;
    void Start()
    {
		ps = GetComponentInChildren<ParticleSystem>();
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
			//musicManager.Instance.playSource("Heal");
			//musicManager.Instance.playSource("Hearth");
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
            musicManager.Instance.playSource("Heal");
            musicManager.Instance.playSource("Hearth");
			GameManager.setSpawn(transform.position);
			ps.Play();
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			ps.Stop();
			inContact = false;
			musicManager.Instance.pauseSource("Heal");
			musicManager.Instance.pauseSource("Hearth");
			currTime = 0f;
		}
	}
}
