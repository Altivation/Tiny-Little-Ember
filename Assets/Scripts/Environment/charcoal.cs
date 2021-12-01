using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charcoal : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int bonus;
    [SerializeField] int newBonus;
    Respawn respawn;
    worldSpark ps;
    void Start()
    {
        respawn = GetComponent<Respawn>();
        if (fuelManager.Instance.maxfuel >= newBonus)
		{
            respawn.Hide();
		}
        ps = FindObjectOfType<worldSpark>();
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
            ps.charcoalBurn();
            GameManager.setSpawn(transform.position);
            musicManager.Instance.playSource("Eat");
		}
	}
}
