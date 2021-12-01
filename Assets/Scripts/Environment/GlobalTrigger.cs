using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalTrigger : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] float DPS;
    float currTime;
    float timeToInflict;
	private void Awake()
	{

	}
	void Start()
    {
        currTime = 0;
        timeToInflict = 1 / DPS;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.startStorm && !GameManager.endOfStorm)
		{
            currTime += Time.deltaTime;
            if (currTime > timeToInflict)
			{
                fuelManager.Instance.lose(1);
                currTime = 0;
			}
		}
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
        if (collision.gameObject.tag == "Player")
		{
            GameManager.startStorm = true;
        }
        
	}
}
