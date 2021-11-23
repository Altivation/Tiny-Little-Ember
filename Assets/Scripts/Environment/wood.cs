using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wood : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float regenTime;
    [SerializeField] int bonus;
    float currTime;
    bool collected;
    Respawn respawn;
    void Start()
    {
        respawn = GetComponent<Respawn>();
        currTime = 0;
        collected = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (collected)
		{
            currTime += Time.deltaTime;
            if (currTime > regenTime)
			{
                currTime = 0;
                respawn.Show();
                collected = false;
			}
		}
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
            consumed();
		}
	}

    public void consumed()
	{
        fuelManager.Instance.gain(bonus);
        collected = true;
        respawn.Hide();
	}
}
