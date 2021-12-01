using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wood : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float regenTime;
    [SerializeField] int bonus;
    [SerializeField] float waitToShow;
    float currTime;
    bool collected;
    int setFuel;
    Respawn respawn;
    worldSpark ps;
    void Start()
    {
        respawn = GetComponent<Respawn>();
        currTime = 0;
        collected = false;
        setFuel = 0;
        ps = FindObjectOfType<worldSpark>();
    }

    // Update is called once per frame
    void Update()
    {
        if (collected)
		{
            currTime += Time.deltaTime;
            if (currTime > regenTime && fuelManager.fuel <= setFuel - bonus)    
			{
                currTime = 0;
                StartCoroutine(WaitToShow());
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
        ps.woodBurn();
        fuelManager.Instance.gain(bonus);
        collected = true;
        setFuel = fuelManager.fuel;
        if (setFuel < fuelManager.Instance.maxfuel + bonus)
		{
            setFuel = fuelManager.Instance.maxfuel + bonus;
		}
        respawn.Hide();
        musicManager.Instance.playSource("Eat");
    }

    IEnumerator WaitToShow()
	{
        float elapsed = 0f;
        while (elapsed <= waitToShow)
		{
            elapsed += Time.deltaTime;
            yield return null;
		}
        respawn.Show();
	}
}
