using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charcoal : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int bonus;
    Respawn respawn;
    void Start()
    {
        respawn = GetComponent<Respawn>();
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
            fuelManager.Instance.Reset();
            respawn.Hide();
		}
	}
}
